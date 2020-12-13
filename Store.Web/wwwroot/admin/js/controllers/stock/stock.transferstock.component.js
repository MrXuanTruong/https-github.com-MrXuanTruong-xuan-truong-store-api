
var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        outstock: {
            productId: null,
            fromBranchId: null,
            toBranchId: null,
            colorId: null,
            quantity: 0
        },
        errors: [],
        urls: {
            list: '/admin/product/',
        },
        errorMessages: {
            productId: {
                required: "Chưa chọn Sản phẩm"
            },
            fromBranchId: {
                required: "Chưa chọn Chi nhánh xuất"
            },
            toBranchId: {
                required: "Chưa chọn Chi nhánh nhận"
            },
            colorId: {
                required: "Chưa chọn Màu sắc"
            },
            quantity: {
                required: "Chưa nhập Số lượng",
                validate: "Số lượng sản phẩm xuất kho chưa đúng yêu cầu"
            },
        },
        privileges: [],
        products: [],
        colors: [],
        fromBanches: [],
        toBranches: [],
        productService: new ProductService(),
        populateService: new PopulateService(),
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
            if (isNullOrEmpty(this.outstock.productId)) {
                this.errors.push(this.errorMessages.productId.required);
            }

            if (isNullOrEmpty(this.outstock.fromBranchId) || this.outstock.fromBranchId === 0) {
                this.errors.push(this.errorMessages.fromBranchId.required);
            }
            if (isNullOrEmpty(this.outstock.toBranchId) || this.outstock.toBranchId === 0) {
                this.errors.push(this.errorMessages.toBranchId.required);
            }
            if (isNullOrEmpty(this.outstock.colorId) || this.outstock.colorId === 0) {
                this.errors.push(this.errorMessages.colorId.required);
            }
            if (isNullOrEmpty(this.outstock.quantity) || this.outstock.quantity === 0) {
                this.errors.push(this.errorMessages.quantity.required);
            }

            return this.errors.length == 0;
        },

        loadProductStatuses: function () {
            var self = this;

            this.populateService.getProductStatuses()
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
                this.productService.outstock(this.outstock)
                    .then(function (response) {
                        if (response.data.result) {
                            self.$showSuccessToast("Thao tác thành công");
                            setTimeout(function () {
                                location.href = self.urls.list
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
        },

        addNewColor: function () {
            this.outstock.colors.push(
                {
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

        onSelectedFromBranch: function () {
            let self = this;
            let listBranchs  = [];
            this.fromBanches.forEach(function (item, index) {
                if (self.outstock.fromBranchId !== item.id) {
                    listBranchs.push(item);
                }
            });

            this.toBranches = listBranchs;
        },

        onSelectedProduct: function () {
            this.colorsByProductId();
        }

    },

    mounted() {
        //this.loadProductStatuses();
        this.loadBranches();
        //this.colorsByProductId();
        this.loadProducts();

        this.$closePageLoading();
    },
    created: function () {
    }
});