
var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        outstock: {
            details: [
                {
                    orderCode: null,
                    productId: null,
                    colorId: null,
                    quantity: 0,
                }
            ],
        },
        errors: [],
        urls: {
            list: '/admin/product/',
        },
        errorMessages: {
            orderCode: {
                required: "Chưa chọn Đơn hàng để xuất kho"
            }
        },
        order: null,
        products: [],
        orders: [],
        selectedOrderId: null,
        productService: new ProductService(),
        populateService: new PopulateService(),
        orderService: new OrderService(),
        loading: true,
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
        onClickOutstock: function () {
            this.saveOrUpdate();
        },

        validate: function () {
            this.errors = [];
            if (this.order == null) {
                this.errors.push(this.errorMessages.orderCode.required);
            }
            return this.errors.length == 0;
        },

        loadOrderStatuses: function () {
            var self = this;

            this.populateService.getOrderStatuses()
                .then(function (response) {
                    self.productStatuses = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        loadBranches: function () {
            var self = this;

            this.populateService.getBranches()
                .then(function (response) {
                    self.fromBanches = response.data;
                    self.toBranches = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
        colorsByProductId: function () {
            var self = this;

            if (this.outstock.productId !== null) {
                this.populateService.colorsByProductId(this.outstock.productId)
                    .then(function (response) {
                        self.colors = response.data;
                    })
                    .catch(function (error) {
                        console.log(error);
                    })
                    .finally(function () {
                    });
            }

        },
        loadOrders: function () {
            var self = this;

            this.populateService.getOrderPaids()
                .then(function (response) {
                    self.orders = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
        loadProducts: function () {
            var self = this;

            this.populateService.getProducts()
                .then(function (response) {
                    self.products = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },


        getRequestData: function () {


            return this.product;
        },

        saveOrUpdate: function () {
            if (this.validate()) {
                var self = this;
                this.loading = true;
                this.productService.outstock(this.order.orderId)
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

        addNewColor: function () {
            this.outstock.colors.push(
                {
                    productId:null,
                    colorId: null,
                    price: 0,
                }
            );
        },

        deleteColor: function (item) {
            const index = this.outstock.colors.indexOf(item);
            if (index > -1) {
                this.outstock.colors.splice(index, 1);
            }
        },

        onSelectedOrder: function () {
            let self = this;

            this.orderService.getById(this.selectedOrderId)
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

        onSelectedProduct: function () {
            this.colorsByProductId();
        }

    },

    mounted() {
        this.loadBranches();
        this.loadProducts();
        this.loadOrders();

        this.$closePageLoading();
    },
    created: function () {
    }
});