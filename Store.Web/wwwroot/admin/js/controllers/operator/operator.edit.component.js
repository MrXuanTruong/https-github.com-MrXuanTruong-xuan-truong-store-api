var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        operator: null,
        errors: [],
        urls: {
            list: '/admin/operator/',
            edit: '/admin/operator/edit/',
        },
        errorMessages: {
            username: {
                required: "Chưa nhập Tên đăng nhập"
            },
            dateofbirth: {
                required: "Chưa nhập Ngày tháng năm sinh",
            },
            fullName: {
                required: "Chưa nhập Họ và tên",
            },
            email: {
                required: "Chưa nhập Email",
                validate: "Email chưa đúng định dạng"
            },
            phone: {
                required:"Chưa nhập Số điện thoại",
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
            },
            
            accountTypeId: {
                required: "Chưa chọn Chức vụ",
            },
            branch: {
                required: "Chưa chọn Chi nhánh",
            },
            accountStatusId: {
                required: "Chưa nhập Trạng thái",
            },
            discount: {
                required: "Chưa nhập chiết khấu",
            },
        },
        privileges: [],
        operatorStatuses: [],
        operatorTypes: [],
        operatorBranches: [],
        operatorService: new OperatorService(),
        populateService: new PopulateService(),
        loading: true,
        dateOptions: {
            dateOfBirth: {
                dateFormat: 'd/m/Y',
            },
        }
    },
    components: {
        'v-select': VueSelect.VueSelect,
        'flat-pickr': VueFlatpickr,//note
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
        onClickCreateVoucher: function () {
            this.createVoucher();
        },
        validate: function () {
            this.errors = [];
            if (isNullOrEmpty(this.operator.username)) {
                this.errors.push(this.errorMessages.username.required);
            }

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
                if (this.operator.id <= 0) {
                    this.errors.push(this.errorMessages.password.required);
                }
            }

            if (!isNullOrEmpty(this.operator.password) && !isNullOrEmpty(this.operator.confirmedPassword)) {
                if (this.operator.confirmedPassword != this.operator.password) {
                    this.errors.push(this.errorMessages.confirmedPassword.match);
                }
            }

            if (isNullOrEmpty(this.operator.confirmedPassword)) {
                if (this.operator.id <= 0 || !isNullOrEmpty(this.operator.password)) {
                    this.errors.push(this.errorMessages.confirmedPassword.required);
                }
            }
            
            if (isNullOrEmpty(this.operator.accountTypeId) || this.operator.accountTypeId === 0) {
                this.errors.push(this.errorMessages.accountTypeId.required);
            }
            if (isNullOrEmpty(this.operator.branchId) || this.operator.branchId===0) {
                this.errors.push(this.errorMessages.branch.required);
            }
            if (isNullOrEmpty(this.operator.accountStatusId) || this.operator.accountStatusId===0) {
                this.errors.push(this.errorMessages.accountStatusId.required);
            }
            if (isNullOrEmpty(this.operator.discount)) {
                this.errors.push(this.errorMessages.discount.required);
            }
            return this.errors.length == 0;
        },

        

        getOperator: function () {
            var self = this;
            this.loading = true;
            this.operatorService.getById(this.model.Id)
                .then(function (response) {
                    response.data.dateOfBirth = moment(response.data.dateOfBirth).format('DD/MM/YYYY');
                    self.operator = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                    self.loading = false;
                });
        },
        loadOperatorTypes: function () {
            var self = this;

            this.populateService.getAccountTypes()
                .then(function (response) {
                    self.operatorTypes = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
        loadOperatorStatuses: function () {
            var self = this;

            //start loading
            this.populateService.getUserStatuses()
                .then(function (response) {
                    self.operatorStatuses = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                    //close loading
                });
        },
        loadOperatorBranches: function () {
            var self = this;

            this.populateService.getBranches()
                .then(function (response) {
                    self.operatorBranches = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
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
                AccountTypeId: this.operator.accountTypeId,
                BranchId: this.operator.branchId,
                AccountStatusId: this.operator.accountStatusId,
                Password: this.operator.password,
                ConfirmedPassword: this.operator.confirmedPassword,
            };

            request.DateOfBirth = moment(request.DateOfBirth, 'DD/MM/YYYY').format('YYYY-MM-DDTHH:mm:ss');

            return request;
        },
       
        saveOrUpdate: function () {
            if (this.validate()) {
                var self = this;
                this.loading = true;
                if (this.model.Id === 0) {
                    var request = this.getRequestData();
                    console.log(request);
                    this.operatorService.save(request)
                        .then(function (response) {
                            if (response.data.result) {
                                self.$showSuccessToast("Thao tác thành công");
                                setTimeout(function () {
                                    location.href = '/admin/operator'
                                }, 5000);
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
                else {
                    var request = this.getRequestData();

                    this.operatorService.update(this.model.Id, request)
                        .then(function (response) {
                            if (response.data.result) {
                                self.$showSuccessToast("Thao tác thành công");
                                setTimeout(function () {
                                    location.href = '/admin/operator'
                                }, 5000);
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
    /*Voucher */
        createVoucher: function () {
            if (this.validate()) {
                var self = this;
                this.loading = true;
                if (this.model.Id === 0) {
                    var request = this.getRequestData();
                    console.log(request);
                    this.operatorService.save(request)
                        .then(function (response) {
                            if (response.data.result) {
                                self.$showSuccessToast("Tạo voucher thành công");
                                setTimeout(function () {
                                    location.href = '/admin/operator/edit'
                                }, 5000);
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
                else {
                    var request = this.getRequestData();

                    this.operatorService.update(this.model.Id, request)
                        .then(function (response) {
                            if (response.data.result) {
                                self.$showSuccessToast("Thao tác thành công");
                                setTimeout(function () {
                                    location.href = '/admin/operator/edit'
                                }, 5000);
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
        
        this.loadOperatorBranches();
        
        this.loadOperatorTypes();

        if (this.model.Id > 0) {
            this.getPrivileges();
        }

        this.$closePageLoading();
    },
    created: function () {
        this.getOperator();
    }
});