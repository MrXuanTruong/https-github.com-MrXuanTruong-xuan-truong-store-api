var vue = new Vue({
    el: '#page-content',
    data: {
        dataTable: null,
        filter: {
            voucherCode: '',
            fromStartDate: '',
            toStartDate: '',
            fromEndDate: '',
            toEndDate: '',
        },
        urls: {
            edit: '/admin/voucher/edit',
        },
        voucherService: new VoucherService(),
        populateService: new PopulateService(),
    },
    components: {
        'v-select': VueSelect.VueSelect,
        'flat-pickr': VueFlatpickr,
    },
    methods: {

        onClickSearch: function (e) {
            this.dataTable.ajax.url(this.getDatatableAjax()).load();
        },

        onClickCreateVoucher: function (e) {
            location.href = this.urls.edit + '/';
        },

        editItem: function (productVoucherId) {
            location.href = this.urls.edit + '/' + productVoucherId;
        },

        deleteItem: function (voucherId) {
            var self = this;
            this.$showDeleteConfirmMessage()
            .then(
                function (isComfirm) {
                    if (isComfirm === true) {
                        self.voucherService.delete(voucherId)
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
            var url = this.$baseAPIURL + API_VOUCHER_CRUD + '?' + query;

            return url;
        },

        initDataTable: function () {
            var self = this;
            this.dataTable = $('#voucher-table').DataTable({
                ajax: self.$getAjaxSource(self.getDatatableAjax()),
                columns: [
                    { data: "voucherId", name: "VoucherId"},
                    {
                        data: "voucherId", name: "VoucherId",
                        render: function (data, type, row) {
                            var html = '';
                            html += `<a class="btn btn-primary btn-sm" href="/admin/voucher/edit/${data}"><i class="mdi mdi-file-document-edit-outline"></i></a> `;
                            html += '<button class="btn btn-danger btn-sm" onclick="vue.deleteItem(' + data + ')"><i class="mdi mdi-trash-can-outline"></i></button> ';
                            return html;
                        }
                    },
                    {
                        data: "voucherCode", name: "VoucherCode", searchable: false, sortable: false
                    },
                    {
                        data: "startDate", name: "StartDate", searchable: false, sortable: false,
                        render: function (data, type, row) {
                            var html = data;
                            return html;
                        }
                    },
                    {
                        data: "endDate", name: "EndDate", searchable: false, sortable: false,
                        render: function (data, type, row) {
                            var html = data;
                            return html;
                        }
                    },
                    {
                        data: "price", name: "Price", searchable: false, sortable: false,
                        render: function (data, type, row) {
                            return vue.$options.filters.currency(data);
                        }
                    },
                    { data: "customerName", name: "CustomerName", searchable: true, sortable: true, },
                    { data: "email", name: "Email", searchable: true, sortable: true, },
                    
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