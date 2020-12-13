var vue = new Vue({
    el: '#page-content',
    data: {
        urls: {
            login: "/admin/login",
        },
    },
    methods: {
        redirectToLoginPage: function () {
            location.href = this.urls.login;
        }
    },
    mounted() {
        this.$closePageLoading();

        setTimeout(this.redirectToLoginPage, 2000)
    },
    created: function () {
    }
});