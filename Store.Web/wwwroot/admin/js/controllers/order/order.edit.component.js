var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        order: null,
        errors: [],
        urls: {
            list: '/admin/order/',
            edit: '/admin/order/edit/',
        },
        errorMessages: {
            contactName: {
                required: "Chưa nhập tên liên hệ"
            },
            phone: {
                required: "Chưa nhập số điện thoại"
            },
            address: {
                required: "Chưa nhập địa chỉ"
            },
            email: {
                required: "Chưa nhập email",
                validate: "Email chưa đúng định dạng"
            },
            orderStatusId: {
                required: "Chưa nhập Trạng thái"
            },
        },
        orderStatuses: [],
        branches: [],
        paymentMethods: [{id: 1, name: 'Thanh toán tại cửa hàng'}],
        orderService: new OrderService(),
        populateService: new PopulateService(),
        loading: true,
    },
    components: {
        'v-select': VueSelect.VueSelect,
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
            if (isNullOrEmpty(this.order.contactName)) {
                this.errors.push(this.errorMessages.contactName.required);
            }

            if (isNullOrEmpty(this.order.phone)) {
                this.errors.push(this.errorMessages.phone.required);
            }

            if (isNullOrEmpty(this.order.email)) {
                this.errors.push(this.errorMessages.email.required);
            }
            else if (!validEmail(this.order.email)) {
                this.errors.push(this.errorMessages.email.validate);
            }

            if (isNullOrEmpty(this.order.address)) {
                this.errors.push(this.errorMessages.address.required);
            }

            if (!this.order.orderStatusId) {
                this.errors.push(this.errorMessages.orderStatusId.required);
            }

            return this.errors.length == 0;
        },

        

        getOrder: function () {
            var self = this;
            this.loading = true;
            this.orderService.getById(this.model.Id)
                .then(function (response) {
                    self.order = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                    self.loading = false;
                });
        },

        loadOrderStatuses: function () {
            var self = this;

            this.populateService.getOrderStatuses()
                .then(function (response) {
                    self.orderStatuses = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        loadPaymentMethods: function () {
            var self = this;

            this.populateService.getPaymentMethods()
                .then(function (response) {
                    self.paymentMethods = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        loadBranches:function() {
            var self = this;

            this.populateService.getBranches()
                .then(function (response) {
                    self.branches = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
       
        saveOrUpdate: function () {
            if (this.validate()) {
                var self = this;
                this.loading = true;
               
                var request = this.order;

                this.orderService.update(this.model.Id, request)
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
        },

    },
    
    mounted() {
        this.loadOrderStatuses();
        this.loadBranches();
        //this.loadPaymentMethods();

        this.$closePageLoading();
    },
    created: function () {
        this.getOrder();
    }
});