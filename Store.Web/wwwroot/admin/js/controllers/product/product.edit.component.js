
var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        product: null,
        errors: [],
        urls: {
            list: '/admin/product/',
            edit: '/admin/product/edit/',
        },
        errorMessages: {
            productName: {
                required: "Chưa nhập Tên sản phẩm"
            },
            price: {
                required: "Chưa nhập Giá sản phẩm",
                validate: "Giá sản phẩm phải lớn hơn 0"
            },
            categoryId: {
                required: "Chưa chọn Loại sản phẩm",
            },
            productBrandId: {
                required: "Chưa chọn Nhãn hiệu"
            },
            colorId: {
                required: "Chưa chọn Màu sắc"
            },
            productStatusId: {
                required:"Chưa chọn Trạng thái sản phẩm"
            },
            productImage: {
                required: "Chưa upload file Ảnh sản phẩm"
            },
            description: {
                required: "Chưa nhập Mô tả"
            },
        },
        privileges: [],
        productStatuses: [],
        colors: [],
        productCatagories: [],
        productBrands: [],
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
        }
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
            if (isNullOrEmpty(this.product.productName)) {
                this.errors.push(this.errorMessages.productName.required);
            }

            if (isNullOrEmpty(this.product.price)) {
                this.errors.push(this.errorMessages.price.required);
            }
            else if ((this.product.price<=0)) {
                this.errors.push(this.errorMessages.price.validate);
            }
            if (isNullOrEmpty(this.product.categoryId) || this.product.categoryId === 0) {
                this.errors.push(this.errorMessages.categoryId.required);
            }

            if (isNullOrEmpty(this.product.productBrandId) || this.product.productBrandId === 0) {
                this.errors.push(this.errorMessages.productBrandId.required);
            }
            if (isNullOrEmpty(this.product.productStatusId) || this.product.productStatusId === 0) {
                this.errors.push(this.errorMessages.productStatusId.required);
            }
            this.product.productColors.forEach(function (productColor) {
                if (isNullOrEmpty(productColor.colorId) || productColor.colorId === 0) {
                    this.errors.push(this.errorMessages.colorId.required);
                }
            });
            return this.errors.length == 0;
        },

        

        getProduct: function () {
            var self = this;
            this.loading = true;
            this.productService.getById(this.model.Id)
                .then(function (response) {
                    self.product = response.data;

                    // log thông tin product từ api lúc get xem 
                    console.info(self.product);
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                    self.loading = false;
                });
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
        loadProductCatagories: function () {
            var self = this;

            this.populateService.getCatagories()
                .then(function (response) {
                    self.productCatagories = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
        loadProductBrands: function () {
            var self = this;

            this.populateService.getBrands()
                .then(function (response) {
                    self.productBrands = response.data;
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


        getRequestData: function () {
            return this.product;
        },
       
        saveOrUpdate: function () {
            if (this.validate()) {
                var self = this;
                this.loading = true;
                if (this.model.Id == 0) {
                    var request = this.getRequestData();

                    console.info(request);

                    this.productService.save(request)
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
                else {
                    var request = this.getRequestData();

                    console.info(request);

                    this.productService.update(this.model.Id, request)
                        .then(function (response) {
                            if (response.data.result) {
                                self.$showSuccessToast("Thao tác thành công");
                                /*setTimeout(function () {
                                    location.href = self.urls.list
                                }, 5000);*/
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

        addNewColor: function () {
            this.product.productColors.push(
                {
                    colorId: null,
                    price: 0,
                }
            );
        },

        deleteColor: function (item) {
            const index = this.product.productColors.indexOf(item);
            if (index > -1) {
                this.product.productColors.splice(index, 1);
            }
        },
        onUploadedThumbnailImage(fileName) {
            this.product.thumnailUrl = fileName;
        },
        onUploadedSliderImages(images) {
            this.product.sliderImages = images;
            console.info(this.product.sliderImages);
        }

    },
    
    mounted() {
        this.loadProductStatuses();
        this.loadProductBrands();
        this.loadProductCatagories();
        this.loadColors();
        this.$closePageLoading();
    },
    created: function () {
        this.getProduct();
    }
});