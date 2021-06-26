var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        voucher: null,
        accounts: [],
        errors: [],
        urls: {
            list: '/admin/voucher/',
            edit: '/admin/voucher/edit/',
        },
        errorMessages: {
            startDate: {
                required: "Vui lòng nhập Ngày bắt đầu hiệu lực"
            },
            endDate: {
                required: "Vui lòng nhập Ngày kết thúc"
            },
            price: {
                required: "Vui lòng nhập Giá"
            },
            accountId: {
                required: "Vui lòng nhập Khách hàng"
            },
        },
        voucherService: new VoucherService(),
        populateService: new PopulateService(),
        loading: true,
        dateOptions: {
            startDate: {
                dateFormat: 'd/m/Y',
            },
            endDate: {
                dateFormat: 'd/m/Y',
            },
        }
    },
    components: {
        'v-select': VueSelect.VueSelect,
        'flat-pickr': VueFlatpickr,//note
    },
    computed: {
        isEdit: function () {
            return this.model.Id > 0;
        },
    },
    methods: {

        onClickBtnGotoList: function () {
            location.href = this.urls.list;
        },
        onClickUpdate: function () {
            this.saveOrUpdate();
        },
        onClickAddNew: function (e) {
            location.href = this.urls.edit;
        },

        validate: function () {
            this.errors = [];
            if (isNullOrEmpty(this.voucher.startDate)) {
                this.errors.push(this.errorMessages.startDate.required);
            }
            if (isNullOrEmpty(this.voucher.endDate)) {
                this.errors.push(this.errorMessages.endDate.required);
            }
            if (isNullOrEmpty(this.voucher.price)) {
                this.errors.push(this.errorMessages.price.required);
            }
            if (isNullOrEmpty(this.voucher.accountId)) {
                this.errors.push(this.errorMessages.accountId.required);
            }
            return this.errors.length == 0;
        },

        

        getVoucher: function () {
            var self = this;
            this.loading = true;
            this.voucherService.getById(this.model.Id)
                .then(function (response) {
                    let voucher = response.data;
                    voucher.startDate = moment(voucher.startDate).format('DD/MM/YYYY');
                    voucher.endDate = moment(voucher.endDate).format('DD/MM/YYYY');
                    self.voucher = voucher;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                    self.loading = false;
                });
        },
        loadAccounts: function () {
            var self = this;

            this.populateService.getAccounts()
                .then(function (response) {
                    self.accounts = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        getRequestData: function () {
            
            var request = {
                Id: this.voucher.id,
                startDate: moment(this.voucher.startDate, 'DD/MM/YYYY').format('YYYY-MM-DDTHH:mm:ss'),
                endDate: moment(this.voucher.endDate, 'DD/MM/YYYY').format('YYYY-MM-DDTHH:mm:ss'),
                price: this.voucher.price,
                accountId: this.voucher.accountId,
            };

            return request;
        },
       
        saveOrUpdate: function () {
            if (this.validate()) {
                var self = this;
                this.loading = true;
                if (this.model.Id === 0) {
                    var request = this.getRequestData();
                    console.log(request);
                    this.voucherService.save(request)
                        .then(function (response) {
                            if (response.data.result) {
                                self.$showSuccessToast("Thao tác thành công");
                                setTimeout(function () {
                                    location.href = '/admin/voucher'
                                }, 5000);
                            }
                            else {
                                self.$showDangerToast(response.data.messages[0]);
                            }
                        })
                        .catch(function (error) {
                            console.log(error);
                        })
                        .finally(function () {
                            self.loading = false;
                        });
                }
                else {
                    var request = this.getRequestData();

                    this.voucherService.update(this.model.Id, request)
                        .then(function (response) {
                            if (response.data.result) {
                                self.$showSuccessToast("Thao tác thành công");
                            }
                            else {
                                self.$showDangerToast(response.data.messages[0]);
                            }
                        })
                        .catch(function (error) {
                            console.log(error);
                        })
                        .finally(function () {
                            self.loading = false;
                        });
                }
            }
        },

    },
    
    mounted() {
        this.$closePageLoading();
    },
    created: function () {
        this.loadAccounts();
        this.getVoucher();
    }
});