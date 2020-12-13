//import { eventBus } from 'product.detail.component.js';
var headerComponent = new Vue({
    el: '#header',
    props: {
    },
    data: function () {
        return {
            currentUser: null,
            //shoppingCarts: null
        }
    },

    methods: {
        onClickBtnLogout: function () {
            localStorage.removeItem('customer_token');
            localStorage.removeItem('customer_token_expired');
            localStorage.removeItem('customer_info');
            location.reload();
        },

    },

    computed: {
        isLogin: function () {
            return this.currentUser !== null;
        },
        isCart: function () {
            return this.shoppingCart !== null;
        }
    },

    created: function () {
        this.currentUser = this.$getUserInfo();
        //this.localStorage();
    },

    mounted: function () {
    }
});