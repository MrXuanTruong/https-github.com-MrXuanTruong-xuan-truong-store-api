var vue = new Vue({
    el: '#page-content',
    data: {
        newestProducts: [],
        featureProducts: [],
        productService: new ProductService(),
    },
    components: {

    },
    methods: {
        getNewestProducts: function () {
            let self = this;
            this.productService.getNewestProducts()
                .then(function (response) {
                    let products = response.data;
                    self.newestProducts = products;
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

        getFeatureProducts: function () {
            let self = this;
            this.productService.getFeatureProducts()
                .then(function (response) {
                    let products = response.data;
                    self.featureProducts = products;
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
        }
    },
    mounted: function () {

    },
    created: function () {
        this.getNewestProducts();
        this.getFeatureProducts();
    }
});