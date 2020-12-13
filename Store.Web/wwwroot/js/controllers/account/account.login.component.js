var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        email: null,
        password: null,
        isRemember: false,
        isSubmit: false,
        operatorService: new OperatorService(),
        errors: [],
        urls: {
            home: "/home",
        },
        errorMessages: {
            email: {
                required: "Chưa nhập Email"
            },
            password: {
                required: "Chưa nhập Mật khẩu"
            }
        }
    },
    methods: {

        getUserInfo: function () {
            var self = this;
            this.operatorService.getCurrentUser()
                .then(function (res) {
                    self.operatorInfo = res.data;
                    self.$setUserInfo(res.data);
                    if (isNullOrEmpty(self.model.ReturnUrl)) {
                        location.href = self.urls.home;
                    }
                    else {
                        location.href = self.model.ReturnUrl;
                    }
                })
                .catch(function (error) {
                    self.errors = ['Có lỗi trong quá trình thao tác.'];
                })
                .finally(function () {
                    self.isSubmit = false;
                });
        },

        onClickBtnLogin: function () {
            var self = this;
            this.errors = [];

            if (isNullOrEmpty(this.email)) {
                this.errors.push(this.errorMessages.email.required);
            }
            if (isNullOrEmpty(this.password)) {
                this.errors.push(this.errorMessages.password.required);
            }

            if (this.errors.length == 0) {
                self.isSubmit = true;
                var request = {
                    UserName: this.email,
                    Password: this.password,
                };

                this.operatorService.loginUser(request)
                    .then(function (response) {
                        if (response.data.result) {
                            localStorage.setItem('customer_token', response.data.accessToken);
                            localStorage.setItem('customer_token_expired', response.data.expiredDate);

                            base_axios.defaults.headers.Authorization = `Bearer ${response.data.accessToken}`;
                            self.getUserInfo();
                        }
                        else {
                            self.errors = response.data.messages;
                        }
                    })
                    .catch(function (error) {
                        console.log(error)
                        self.errors = ['Có lỗi trong quá trình thao tác.'];
                    })
                    .finally(function () {
                        self.isSubmit = false;
                    });
            }
        },
    },

    mounted() {
        this.$closePageLoading();

        setTimeout(this.redirectToLoginPage, 2000)
        
    },

    created: function () {

    }
});