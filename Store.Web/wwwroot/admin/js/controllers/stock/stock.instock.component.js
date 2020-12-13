

var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        instock: {
            branchId: null,
            details: [
                {
                    productId: null,
                    colorId: null,
                    quantity: 0,
                    price: 0
                }
            ],
            note: null
        },
        errors: [],
        urls: {
            list: '/admin/product/',
        },
        errorMessages: {
            productId: {
                required: "Chưa chọn sản phẩm"
            },
            branchId: {
                required: "Chưa chọn Chi nhánh"
            },
            colorId: {
                required: "Chưa chọn Màu sắc"
            },
            quantity: {
                required: "Chưa nhập Số lượng",
                validate: "Nhập kho tối thiểu 1 sản phẩm"
            },
            price: {
                required: "Chưa nhập Giá",
            }
        },
        privileges: [],
        productStatuses: [],
        products :[],
        colors: [],
        branches: [],
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
        onClickInstock: function () {
            this.saveOrUpdate();
        },

        validate: function () {
            this.errors = [];

            if (isNullOrEmpty(this.instock.branchId) || this.instock.branchId === 0) {
                this.errors.push(this.errorMessages.branchId.required);
            }

            let self = this;
            this.instock.details.forEach(
                function (productColor) {
                    if (isNullOrEmpty(productColor.productId) || productColor.productId === 0) {
                        self.errors.push(self.errorMessages.productId.required);
                    }
                    if (isNullOrEmpty(productColor.colorId) || productColor.colorId === 0) {
                        self.errors.push(self.errorMessages.colorId.required);
                    }
                    if (isNullOrEmpty(productColor.quantity) || productColor.quantity === 0) {
                        self.errors.push(self.errorMessages.quantity.required);
                    }
                    if (isNullOrEmpty(productColor.price) || productColor.price === 0) {
                        self.errors.push(self.errorMessages.price.required);
                    }
                }
            );


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
                    self.branches = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
        loadColors: function () {
            var self = this;

            this.populateService.getColors()
                .then(function (response) {
                    self.colors = response.data;
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
                this.productService.instock(this.instock)
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
            this.instock.details.push(
                {
                    productId: null,
                    colorId: null,
                    quantity: 0,
                    price: 0
                }
            );
        },

        deleteColor: function (item) {
            const index = this.instock.details.indexOf(item);
            if (index > -1) {
                this.instock.details.splice(index, 1);
            }
        },
    },

    mounted() {
        this.loadProductStatuses();
        this.loadBranches();
        this.loadColors();
        this.loadProducts();

        this.$closePageLoading();
    },
    created: function () {
    }
});