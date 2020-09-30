﻿var vue = new Vue({
    el: '#page-content',
    data: {
        urls: {
            login: "/admin",
        },
    },
    methods: {
        redirectToLoginPage: function () {
            location.href = this.urls.login;
        }
    },
    mounted() {
        this.$closePageLoading();

        setTimeout(this.redirectToLoginPage, 4000)
    },
    created: function () {
    }
});