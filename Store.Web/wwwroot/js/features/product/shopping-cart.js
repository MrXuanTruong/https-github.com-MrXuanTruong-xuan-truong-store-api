Vue.component('shopping-cart', {
    template: `
        
    `,
    props: {
        shoppingcart: Object,
    },
    data: function () {
        return {

        };
    },
    components: {

    },
    methods: { 

    },
    computed: {
        productDetailUrl: function () {
            let url = '/product/detail?id=' + this.product.id;
            return url;
        }
    },
    mounted: function () {

    },
    created: function () {

    }
})