var vue = new Vue({
    el: '#page-content',
    data: {
        productService: new ProductService(),
        orderService: new OrderService(),
        vouccherService: new VoucherService(),
        shoppingCarts: [],
        contactInformation: {
            contactName: null,
            phone: null,
            email: null,
            address: null,
            note: null,
        },
        voucherCode: null,
        discount: 0,
        errors: [],
    },
    components: {

    },
    methods: {
        validate: function () {
            if (this.$getUserInfo() == null) {
                this.$showErrorMessage("Vui lòng đăng nhập để tiếp tục")
                    .then(
                        function () {
                            location.href = '/account/login';
                        }
                );
                return false;
            }
            else {
                this.errors = [];
                if (isNullOrEmpty(this.contactInformation.contactName)) {
                    this.errors.push('Vui lòng nhập Tên đầy đủ');
                }

                if (isNullOrEmpty(this.contactInformation.phone)) {
                    this.errors.push('Vui lòng nhập Số điện thoại');
                }

                if (isNullOrEmpty(this.contactInformation.email)) {
                    this.errors.push('Vui lòng nhập Email');
                }
                else if (!validEmail(this.contactInformation.email)) {
                    this.errors.push('Email không hợp lệ');
                }

                if (isNullOrEmpty(this.contactInformation.address)) {
                    this.errors.push('Vui lòng nhập Địa chỉ');
                }

                if (this.errors.length) {
                    this.$showErrorMessage('Vui lòng kiểm tra lại thông tin');
                }

                return this.errors.length === 0;
            }
        },

        onClickBtnCreateOrder: function () {
            if (this.validate()) {
                let request = {
                    contactName: this.contactInformation.contactName,
                    phone: this.contactInformation.phone,
                    email: this.contactInformation.email,
                    address: this.contactInformation.address,
                    note: this.contactInformation.note,
                    orderDetails: [],
                    voucherCode: this.voucherCode,
                };

                this.shoppingCarts.forEach(function (item, index) {
                    let orderDetailItem = {
                        productId: item.id,
                        colorId: item.colorId,
                        quantity: item.quantity,
                        branchId: null,
                    };

                    request.orderDetails.push(orderDetailItem);
                });

                let self = this;
                this.orderService.save(request)
                    .then(function (response) {
                        if (response.data.result) {
                            localStorage.removeItem('shoppingCarts');

                            self.$showSuccessMessage(response.data.messages[0])
                                .then(
                                    function () {
                                        location.href = '/product/order/' + response.data.orderId;
                                    }
                                );
                        }
                        else {
                            self.$showErrorMessage(response.data.messages[0]);
                        }
                    })
                    .catch(function (error) {
                        console.log(error);
                    })
                    .finally(function () {
                    });
            }
        },

        getProductDetail: function (productId) {
            let self = this;
            
            this.productService.getProductDetail(productId)
                .then(function (response) {
                    let product = response.data;
                    
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
        onClickCancelCart: function () {
            localStorage.removeItem('shoppingCarts');
            location.href = '/product/shoppingcart';
        },
        remove: function (id) {
            var index = 0;
            for (var i = 0; i < this.shoppingCarts.length; i++) {
                if (this.shoppingCarts[i].id === id) {
                    index = i;
                    break;
                }
            }
            this.shoppingCarts.splice(index, 1);

            var json = JSON.stringify(this.shoppingCarts);
            localStorage.setItem('shoppingCarts', json);
        },
        decrement: function (id) {
            for (var i = 0; i < this.shoppingCarts.length; i++) {
                if (this.shoppingCarts[i].id === id && this.shoppingCarts[i].quantity > 1) {
                    this.shoppingCarts[i].quantity--;
                    break;
                }
            }

            var json = JSON.stringify(this.shoppingCarts);
            localStorage.setItem('shoppingCarts', json);
        },
        increment: function (id) {
            for (var i = 0; i < this.shoppingCarts.length; i++) {
                if (this.shoppingCarts[i].id === id) {
                    this.shoppingCarts[i].quantity++;
                }
            }

            var json = JSON.stringify(this.shoppingCarts);
            localStorage.setItem('shoppingCarts', json);
        },

        applyVoucherCode: function (e) {
            if (isNullOrEmpty(this.voucherCode)) {
                this.$showErrorMessage("Vui lòng nhập mã voucher");
                return;
            }

            let self = this;

            this.vouccherService.getByVoucherCode(self.voucherCode)
                .then(function (response) {
                    if (response.data.result) {
                        self.$showSuccessMessage("Đã sử dụng voucher");
                        self.discount = response.data.price;
                    }
                    else {
                        self.$showErrorMessage(response.data.messages[0]);
                    }
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        getTotalPrice: function () {
            let total = 0;
            for (var i = 0; i < this.shoppingCarts.length; i++) {
                total += this.shoppingCarts[i].product.price * this.shoppingCarts[i].quantity;
            }
            return total;
        }
    },
    computed: {
        totalPrice: function () {
            return this.getTotalPrice();
        },
        totalPriceAfterDiscount: function () {
            let total = this.getTotalPrice();
            total -= this.discount;
            return total;
        }
    },
    mounted: function () {
        var jsonString = localStorage.getItem('shoppingCarts');
        if (jsonString !== null) {
            let shoppingCarts = JSON.parse(jsonString);

            this.shoppingCarts = shoppingCarts;
        }
    },
    created: function () {
        let userInfo = this.$getUserInfo();
        if (userInfo != null) {
            this.contactInformation.contactName = userInfo.fullname;
            this.contactInformation.email = userInfo.email;
            this.contactInformation.phone = userInfo.phone;
            this.contactInformation.address = userInfo.address;
        }
    }
});