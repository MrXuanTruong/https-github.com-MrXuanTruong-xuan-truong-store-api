var vue = new Vue({
    el: '#page-content',
    data: {
        dataTable: null,
        filter: {
            orderStatusId: '',
        },
        urls: {
            edit: '/admin/order/add',
        },
        orderStatuses: [{ orderStatusId: '', orderStatusName: 'Tất cả' }],
        orderService: new OrderService(),
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

        editItem: function (orderId) {
            location.href = this.urls.edit + '/' + orderId;
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

        deleteItem: function (orderId) {
            var self = this;
            this.$showDeleteConfirmMessage()
                .then(
                    function (isComfirm) {
                        if (isComfirm === true) {
                            self.orderService.delete(orderId)
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
            var url = this.$baseAPIURL + API_ORDERS_SEARCH + '?' + query;

            return url;
        },

        initDataTable: function () {
            var self = this;
            this.dataTable = $('#order-table').DataTable({
                ajax: self.$getAjaxSource(self.getDatatableAjax()),
                columns: [
                    {
                        data: "orderId", name: "orderId", "width": "10%", searchable: false, sortable: false, render: function (data, type, row) {
                            var html = '';
                            html += `<a class="btn btn-primary btn-sm" href="/admin/order/edit/${data}"><i class="mdi mdi-file-document-edit-outline"></i></a> `;
                            html += '<button class="btn btn-danger btn-sm" onclick="vue.deleteItem(' + data + ')"><i class="mdi mdi-trash-can-outline"></i></button> ';
                            return html;
                        }
                    },
                    { data: "orderCode", name: "OrderCode", searchable: true, sortable: false },
                    { data: "contactName", name: "ContactName", searchable: true, sortable: false },
                    { data: "phone", name: "Phone", searchable: true, sortable: false },
                    { data: "email", name: "Email", searchable: true, sortable: false },
                    { data: "address", name: "Address", searchable: true, sortable: false },
                    { data: "totalPrice", name: "TotalPrice", searchable: false, sortable: true },
                    { data: "createdDate", name: "CreatedDate", searchable: false, sortable: true },
                    { data: "note", name: "Note" },
                    { data: "orderStatusName", name: "OrderStatusName", searchable: false, sortable: true },
                    
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