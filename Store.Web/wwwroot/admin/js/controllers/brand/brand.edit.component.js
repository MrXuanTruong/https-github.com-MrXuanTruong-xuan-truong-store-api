var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        brand: null,
        errors: [],
        urls: {
            list: '/admin/brand/',
            edit: '/admin/brand/edit/',
        },
        errorMessages: {
            brandName: {
                required: "Vui lòng nhập Tên nhãn hiệu"
            },
        },
        brandService: new brandService(),
        populateService: new PopulateService(),
        loading: true,
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

        validate: function () {
            this.errors = [];
            if (isNullOrEmpty(this.brand.brandName)) {
                this.errors.push(this.errorMessages.brandName.required);
            }
            return this.errors.length == 0;
        },

        

        getBrand: function () {
            var self = this;
            this.loading = true;
            this.brandService.getById(this.model.Id)
                .then(function (response) {
                    self.product = response.data;
                    // log thông tin brand từ api lúc get xem 
                    console.info(self.product);
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                    self.loading = false;
                });
        },
        loadBrandStatuses: function () {
            var self = this;

            this.populateService.getUserStatuses()
                .then(function (response) {
                    self.brandStatuses = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },

        getRequestData: function () {
            
            var request = {
                Id: this.brand.id,
                Fullname: this.brand.fullname,
                Username: this.brand.username,
                DateOfBirth: this.brand.dateOfBirth,
                Email: this.brand.email,
                Phone: this.brand.phone,
                Address: this.brand.address,
                AccountTypeId: this.brand.accountTypeId,
                BranchId: this.brand.branchId,
                AccountStatusId: this.brand.accountStatusId,
                Password: this.brand.password,
                ConfirmedPassword: this.brand.confirmedPassword,
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
                    this.brandService.save(request)
                        .then(function (response) {
                            if (response.data.result) {
                                self.$showSuccessToast("Thao tác thành công");
                                setTimeout(function () {
                                    location.href = '/admin/brand'
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

                    this.brandService.update(this.model.Id, request)
                        .then(function (response) {
                            if (response.data.result) {
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
            this.brandService.getPrivileges(this.model.Id)
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
            this.brandService.applyPrivileges(this.model.Id, privileges)
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
        this.loadbrandStatuses();
        
        this.loadbrandBranches();
        
        this.loadbrandTypes();

        if (this.model.Id > 0) {
            this.getPrivileges();
        }

        this.$closePageLoading();
    },
    created: function () {
        this.getbrand();
    }
});