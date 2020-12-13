var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        operator: {
            fullname: null,
            phone: null,
            dateOfBirth: null,
            email: null,
            address: null,
            password: null,
            confirmedPassword: null,
        },
        errors: [],
        urls: {
            login: '/account/login/',
        },
        errorMessages: {
            
            fullName: {
                required: "Chưa nhập Họ và tên",
            },
            phone: {
                required: "Chưa nhập Số điện thoại",
            },

            dateofbirth: {
                required: "Chưa nhập Ngày tháng năm sinh",
            },
            email: {
                required: "Chưa nhập Email",
                validate: "Email chưa đúng định dạng"
            },
            
            address: {
                required: "Chưa nhập Địa chỉ",
            },
            password: {
                required: "Chưa nhập Mật khẩu"
            },
            confirmedPassword: {
                required: "Chưa nhập lại mật khẩu xác nhận",
                match: "Xác nhận mật khẩu không chính xác"
            }
        },
        registerService: new RegisterService(),
        populateService: new PopulateService(),
        loading: true,
        dateOptions: {
            dateOfBirth: {
                dateFormat: 'd/m/Y',
            },
        }
    },
    components: {
        'flat-pickr': VueFlatpickr,//note
    },
    computed: {
    },
    methods: {
        onClickUpdate: function () {
            this.save();
        },
        validate: function () {
            //debugger
            this.errors = [];
            if (isNullOrEmpty(this.operator.dateOfBirth)) {
                this.errors.push(this.errorMessages.dateofbirth.required);
            }

            if (isNullOrEmpty(this.operator.fullname)) {
                this.errors.push(this.errorMessages.fullName.required);
            }

            if (isNullOrEmpty(this.operator.email)) {
                this.errors.push(this.errorMessages.email.required);
            }
            else if (!validEmail(this.operator.email)) {
                this.errors.push(this.errorMessages.email.validate);
            }

            if (isNullOrEmpty(this.operator.phone)) {
                this.errors.push(this.errorMessages.phone.required);
            }

            if (isNullOrEmpty(this.operator.address)) {
                this.errors.push(this.errorMessages.address.required);
            }

            if (isNullOrEmpty(this.operator.password)) {
                this.errors.push(this.errorMessages.password.required);
            }

            if (!isNullOrEmpty(this.operator.password) && !isNullOrEmpty(this.operator.confirmedPassword)) {
                if (this.operator.confirmedPassword !== this.operator.password) {
                    this.errors.push(this.errorMessages.confirmedPassword.match);
                }
            }

            if (isNullOrEmpty(this.operator.confirmedPassword)) {
                if (!isNullOrEmpty(this.operator.password)) {
                    this.errors.push(this.errorMessages.confirmedPassword.required);
                }
            }
            return this.errors.length === 0;
        },
        getRequestData: function () {

            var request = {
                Id: this.operator.id,
                Fullname: this.operator.fullname,
                Username: this.operator.username,
                DateOfBirth: this.operator.dateOfBirth,
                Email: this.operator.email,
                Phone: this.operator.phone,
                Address: this.operator.address,
                Password: this.operator.password,
                ConfirmedPassword: this.operator.confirmedPassword,
            };

            request.DateOfBirth = moment(request.DateOfBirth, 'DD/MM/YYYY').format('YYYY-MM-DDTHH:mm:ss');

            return request;
        },
        
        save: function () {
            if (this.validate()) {
                var self = this;
                this.loading = true;
                var request = this.getRequestData();
               
                console.log(request);
                this.registerService.save(request)
                    .then(function (response) {
                        if (response.data.result) {
                            self.$showSuccessMessage("Tạo tài khoản thành công")
                                .then(
                                    function () {
                                        location.href = '/account/login';
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
                        self.loading = false;
                    });
            }
        },

    },

    mounted() {
        this.$closePageLoading();
    },
    created: function () {
    }
});