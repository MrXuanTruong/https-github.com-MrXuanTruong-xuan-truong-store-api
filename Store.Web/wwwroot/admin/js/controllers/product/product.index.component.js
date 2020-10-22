var vue = new Vue({
    el: '#page-content',
    data: {
        dataTable: null,
        filter: {
            username: '',
            email: '',
            statusId: '',
        },
        urls: {
            edit: '/admin/product/add',
        },
        userStatuses: [{ StatusId: '', StatusName: 'Tất cả'}],
        operatorService: new OperatorService(),
        populateService: new PopulateService(),
    },
    components: {
        'v-select': VueSelect.VueSelect,
    },
    methods: {
        onClickSearch: function (e) {
            this.dataTable.ajax.url(this.getDatatableAjax()).load();
        },

        onClickCreateUser: function (e) {
            location.href = this.urls.edit + '/';
        },

        editItem: function (operatorId) {
            location.href = this.urls.edit + '/' + operatorId;
        },

        loadUserStatuses: function () {
            var self = this;

            this.populateService.getUserStatuses()
                .then(function (response) {
                    response.data.forEach((value) => {
                        self.userStatuses.push(value);
                    });
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        deleteItem: function (operatorId) {
            var self = this;
            this.$showDeleteConfirmMessage()
            .then(
                function (isComfirm) {
                    if (isComfirm === true) {
                        self.operatorService.delete(operatorId)
                            .then(function (response) {
                                if (response.data.result) {
                                    self.dataTable.ajax.reload();
                                    self.$showSuccessToast("Deleted");
                                }
                                else {
                                    self.$showDangerToast(response.data.messages[0]);
                                }
                            })
                            .catch(function (error) {
                                console.log(error);
                            })
                            .finally(function () {

                            });
                    }
                }
            )
        },

        getDatatableAjax: function () {
            var query = this.$serializeJsonToQueryString(this.filter);
            var url = this.$baseAPIURL + API_PRODUCT_SEARCH + '?' + query;

            return url;
        },

        initDataTable: function () {
            var self = this;
            this.dataTable = $('#product-table').DataTable({
                ajax: self.$getAjaxSource(self.getDatatableAjax()),
                columns: [
                    {
                        data: "ProductId", name: "ProductId", "width": "10%", searchable: false, sortable: false, render: function (data, type, row) {
                            var html = '';
                            html += `<a class="btn btn-primary btn-sm" href="/admin/product/edit/${data}"><i class="mdi mdi-file-document-edit-outline"></i></a> `;
                            html += '<button class="btn btn-danger btn-sm" onclick="vue.deleteItem(' + data + ')"><i class="mdi mdi-trash-can-outline"></i></button> ';
                            return html;
                        }
                    },
                    { data: "ProductName", name: "ProductName" },
                    { data: "ProductCategoryId", name: "ProductCategoryId" },
                    { data: "ProductBranchId", name: "ProductBranchId" },
                    { data: "Description", name: "Description" },
                    { data: "Price", name: "Price" },
                ],
                "order": [[1, "asc"]],
                ...self.$defaultTableSettings
            });
        }
    },
    mounted() {
        this.loadUserStatuses();
        this.initDataTable();
    },
    created: function () {
    }
});