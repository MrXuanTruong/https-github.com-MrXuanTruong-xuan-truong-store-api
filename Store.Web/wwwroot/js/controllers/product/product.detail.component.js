var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        productDetail: null,
        similarProducts: [],
        branches: [],
        productService: new ProductService(),
        shoppingCarts: [],
        selectedColorId: null,
    },
    components: {

    },
    methods: {
        onSelectColor: function (colorId) {
            this.selectedColorId = colorId;
        },

        shoppingCart: function () {
            var isExisted = false;
            for (var i = 0; i < this.shoppingCarts.length; i++) {
                if (this.shoppingCarts[i].id === this.productDetail.id && this.shoppingCarts[i].colorId === this.selectedColorId) {
                    isExisted = true;
                }
            }

            if (isExisted === false) {
                var shoppingCart = {
                    id: this.productDetail.id,
                    quantity: 1,
                    colorId: this.selectedColorId,
                    product: this.productDetail
                };

                this.shoppingCarts.push(shoppingCart);
            }
            else {
                for (var j = 0; j < this.shoppingCarts.length; j++) {
                    if (this.shoppingCarts[j].id === this.productDetail.id && this.shoppingCarts[i].colorId === this.selectedColorId) {
                        this.shoppingCarts[j].quantity += 1;
                    }
                }
            }

            var json = JSON.stringify(this.shoppingCarts);
            localStorage.setItem('shoppingCarts', json);

            location.href = '/product/shoppingcart';
        },
        getProductDetail: function () {
            let self = this;
            this.productService.getProductDetail(this.model.Id)
                .then(function (response) {
                    let product = response.data;
                    self.productDetail = product;

                    setTimeout(function () {
                        $('.flexslider').flexslider({
                            animation: "fade",
                            controlNav: false,
                            animationLoop: false,
                            slideshow: false
                        });
                    }, 100);
                    self.getGetProductBranchesByProductId();
                    self.getSimilarProducts();
                    
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        getSimilarProducts: function () {
            let self = this;
            this.productService.getSimilarProducts(this.productDetail.id)
                .then(function (response) {
                    let products = response.data;
                    self.similarProducts = products;
                    setTimeout(function () {
                        self.initSlider();
                    }, 1);
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
        getGetProductBranchesByProductId: function () {
            let self = this;
            this.productService.getGetProductBranchesByProductId(this.productDetail.id)
                .then(function (response) {
                    let branches = response.data;
                    //debugger
                    self.branches = branches;
                    setTimeout(function () {
                    }, 1);
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        initSlider: function () {
            jQuery('.home-owl-carousel').each(function () {

                var owl = $(this);
                var itemPerLine = owl.data('item');
                if (!itemPerLine) {
                    itemPerLine = 6;
                }
                owl.owlCarousel({
                    items: itemPerLine,
                    itemsTablet: [768, 2],
                    navigation: true,
                    pagination: false,

                    navigationText: ["", ""]
                });
            });
        },
        clickButtonColor: function (colorId) {
            this.selectedColorId = colorId;
        }
    },

    computed: {
    },
    mounted: function () {
        var jsonString = localStorage.getItem('shoppingCarts');
        if (jsonString !== null) {
            this.shoppingCarts = JSON.parse(jsonString);
        }
    },
    created: function () {
        this.getProductDetail();
    }
});