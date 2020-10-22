var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        operator: null,
        errors: [],
        urls: {
            list: '/admin/product/',
            edit: '/admin/product/add/',
        },
        errorMessages: {
            username: {
                required: "Chưa nhập tên đăng nhập"
            },
            email: {
                required: "Chưa nhập email",
                validate: "Email chưa đúng định dạng"
            },
            password: {
                required: "Chưa nhập mật khẩu"
            },
            confirmedPassword: {
                required: "Chưa nhập xác nhận mật khẩu",
                match: "Xác nhận mật khẩu không chính xác"
            },
            statusId: {
                required: "Chưa nhập Trạng thái"
            },
            operatorTypeId: {
                required: "Operator type is requried"
            },
        },
        privileges: [],
        operatorStatuses: [],
        operatorService: new OperatorService(),
        popularService: new PopularService(),
        loading: true,
    },
    components: {
        'v-select': VueSelect.VueSelect,
    },
    computed: {
        isEdit: function () {
            return this.model.Id > 0;
        },
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
            if (isNullOrEmpty(this.operator.UserName)) {
                this.errors.push(this.errorMessages.username.required);
            }

            if (isNullOrEmpty(this.operator.Email)) {
                this.errors.push(this.errorMessages.email.required);
            }
            else if (!validEmail(this.operator.Email)) {
                this.errors.push(this.errorMessages.email.validate);
            }

            if (isNullOrEmpty(this.operator.Password)) {
                if (this.operator.OperatorId <= 0) {
                    this.errors.push(this.errorMessages.password.required);
                }
            }

            if (isNullOrEmpty(this.operator.ConfirmedPassword)) {
                if (this.operator.OperatorId <= 0 || !isNullOrEmpty(this.operator.Password)) {
                    this.errors.push(this.errorMessages.confirmedPassword.required);
                }
            }

            if (!isNullOrEmpty(this.operator.Password) && !isNullOrEmpty(this.operator.ConfirmedPassword)) {
                if (this.operator.ConfirmedPassword != this.operator.Password) {
                    this.errors.push(this.errorMessages.confirmedPassword.match);
                }
            }

            if (!this.operator.OStatusId) {
                this.errors.push(this.errorMessages.statusId.required);
            }

            return this.errors.length == 0;
        },

        

        getOperator: function () {
            var self = this;
            this.loading = true;
            this.operatorService.getById(this.model.Id)
                .then(function (response) {
                    self.operator = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                    self.loading = false;
                });
        },

        loadOperatorStatuses: function () {
            var self = this;

            this.popularService.getOperatorStatus()
                .then(function (response) {
                    self.operatorStatuses = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        getRequestData: function () {
            var request = {
                OperatorId: this.operator.OperatorId,
                FullName: this.operator.FullName,
                UserName: this.operator.UserName,
                Email: this.operator.Email,
                Phone: this.operator.Phone,
                Password: this.operator.Password,
                OStatusId: this.operator.OStatusId,
                OperatorTypeId: this.operator.OperatorTypeId,
            };

            return request;
        },
       
        saveOrUpdate: function () {
            if (this.validate()) {
                var self = this;
                this.loading = true;
                if (this.model.Id == 0) {
                    var request = this.getRequestData();
                    this.operatorService.save(request)
                        .then(function (response) {
                            if (response.data.Result) {
                                self.$showSuccessToast("Thao tác thành công");
                                setTimeout(function () {
                                    location.href = self.urls.edit + response.data.RefObjectId
                                }, 5000);
                            }
                            else {
                                self.$showDangerToast(response.data.Messages[0]);
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

                    this.operatorService.update(this.model.Id, request)
                        .then(function (response) {
                            if (response.data.Result) {
                                self.$showSuccessToast("Thao tác thành công");
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

        getPrivileges: function () {
            var self = this;
            this.operatorService.getPrivileges(this.model.Id)
                .then(function (response) {
                    if (response.data.Result) {
                        
                        response.data.Privileges.map(function (privilege, index) {
                            privilege.Checked = privilege.Assigned;
                            privilege.Id = privilege.PrivilegeId;
                            privilege.Text = privilege.PrivilegeName;
                        });

                        self.privileges = response.data.Privileges;
                    }
                })
                .catch(function (error) {
                    console.error(error);
                })
                .finally(function () {

                });
        },

        onClickUpdatePrivilege: function () {
            let privileges = this.privileges.filter((value, index) => {
                return value.Checked;
            });

            var self = this;
            this.operatorService.applyPrivileges(this.model.Id, privileges)
                .then(function (response) {
                    if (response.data.Result) {
                        self.$showSuccessToast("Thao tác thành công");
                    }
                    else {
                        self.$showDangerToast(response.data.messages[0]);
                    }
                })
                .catch(function (error) {
                    console.error(error);
                })
                .finally(function () {

                });
        }

    },
    
    mounted() {
        this.loadOperatorStatuses();
        if (this.model.Id > 0) {
            this.getPrivileges();
        }

        this.$closePageLoading();
    },
    created: function () {
        this.getOperator();
    }
});