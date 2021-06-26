var vue = new Vue({
    el: '#page-content',
    data: {
        dataTable: null,
        filter: {
            productName: '',
            ProductBrandName: '',
            ProductStatusId: '',
        },
        urls: {
            edit: '/admin/product/edit',
        },
        productStatuses: [{ ProductStatusId: '', ProductStatusName: 'Tất cả'}],
        productService: new ProductService(),
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

        editItem: function (productId) {
            location.href = this.urls.edit + '/' + productId;
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

        deleteItem: function (productId) {
            var self = this;
            this.$showDeleteConfirmMessage()
            .then(
                function (isComfirm) {
                    if (isComfirm === true) {
                        self.productService.delete(productId)
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
                    { data: "id", name: "Id", searchable: false, sortable: false },
                    { data: "id", name: "Id", searchable: false, sortable: false,
                        render: function (data, type, row) {
                            var html = '';
                            html += `<a class="btn btn-primary btn-sm" href="/admin/product/edit/${data}"><i class="mdi mdi-file-document-edit-outline"></i></a> `;
                            html += '<button class="btn btn-danger btn-sm" onclick="vue.deleteItem(' + data + ')"><i class="mdi mdi-trash-can-outline"></i></button> ';
                            return html;
                        }
                    },
                    {
                        data: "productImageUrl", name: "ProductImageUrl", searchable: false, sortable: false,
                        render: function (data, type, row) {
                            var html = '<img src="' + data + '"/>';
                            return html;
                        }
                    },
                    { data: "productName", name: "ProductName", searchable: true, sortable: true, },
                    { data: "categoryName", name: "CategoryName", searchable: false, sortable: false, },
                    { data: "productBrandName", name: "ProductBrandName", searchable: false, sortable: false, },
                    { data: "colorNames", name: "ColorNames", searchable: false, sortable: false, },
                    { data: "price", name: "Price", searchable: false },
                    //{ data: "stock", name: "Stock", searchable: false, sortable: false,},
                    //{ data: "branchNames", name: "BranchNames", searchable: false, sortable: false, },
                    { data: "productStatusName", name: "ProductStatusName", searchable: false, sortable: false, },
                    { data: "createdDate", name: "CreatedDate", searchable: false, sortable: true, },
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