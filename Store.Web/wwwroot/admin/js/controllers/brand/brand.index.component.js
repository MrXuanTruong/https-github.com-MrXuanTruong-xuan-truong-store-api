var vue = new Vue({
    el: '#page-content',
    data: {
        dataTable: null,
        urls: {
            edit: '/admin/brand/edit',
        },
        brandService: new BrandService(),
        populateService: new PopulateService(),
    },
    components: {
        'v-select': VueSelect.VueSelect,
    },
    methods: {

        onClickCreateBrand: function (e) {
            location.href = this.urls.edit + '/';
        },

        editItem: function (productBrandId) {
            location.href = this.urls.edit + '/' + productBrandId;
        },

        deleteItem: function (productBrandId) {
            var self = this;
            this.$showDeleteConfirmMessage()
            .then(
                function (isComfirm) {
                    if (isComfirm === true) {
                        self.brandService.delete(productBrandId)
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
            var url = this.$baseAPIURL + API_BRANDS_SEARCH + '?' + query;

            return url;
        },

        initDataTable: function () {
            var self = this;
            this.dataTable = $('#brand-table').DataTable({
                ajax: self.$getAjaxSource(self.getDatatableAjax()),
                columns: [
                    { data: "id", name: "id"},
                    { data: "id", name: "id",
                        render: function (data, type, row) {
                            var html = '';
                            html += `<a class="btn btn-primary btn-sm" href="/admin/brand/edit/${data}"><i class="mdi mdi-file-document-edit-outline"></i></a> `;
                            html += '<button class="btn btn-danger btn-sm" onclick="vue.deleteItem(' + data + ')"><i class="mdi mdi-trash-can-outline"></i></button> ';
                            return html;
                        }
                    },
                    { data: "brandcode", name: "brandcode", searchable: false, sortable: false, },
                    { data: "productBrandName", name: "productBrandName", searchable: false, sortable: false,},
                ],
                "order": [[1, "asc"]],
                ...self.$defaultTableSettings
            });
        }
    },
    mounted() {
        //this.loadUserStatuses();
        this.initDataTable();
    },
    created: function () {
    }
});