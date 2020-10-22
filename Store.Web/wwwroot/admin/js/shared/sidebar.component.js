var vue_menus = new Vue({
    el: '#sidebar',

    data: {
        operatorInfo: null,
        avatarText: '',
        menus: [],
    },

    methods: {
        onClickBtnLogout: function () {
            localStorage.setItem('admin_token', null);
            localStorage.setItem('admin_token_expired', null);
            location.href = '/admin/login';
        },

        getUserInfo: function () {
            this.operatorInfo = this.$getUserInfo();
            if (this.operatorInfo) {
                this.avatarText = this.getAvatarText(this.operatorInfo.fullname);
                this.initMenus();
            }
            else {
                this.onClickBtnLogout();
            }
        },
        initMenus: function () {
            let menuOrigin = [];

            let bookingMenus = {
                name: '',
                subMenus: [
                    { icon: 'mdi mdi-format-list-bulleted-type', name: 'Quản lý danh mục', code: null, url: '/admin/category' },
                ]
            };
            menuOrigin.push(bookingMenus);
            var systemMenus = {
                name: '',
                subMenus: [
                    { icon: 'mdi mdi-format-list-checks',name: 'Quản lý sản phẩm', code: null, url: '/admin/product' },
                  
                    // PERMISSIONS.MANAGE_OPERATOR
                ]
            };
            menuOrigin.push(systemMenus);
            
            var systemMenus = {
                name: '',
                subMenus: [
                    { icon: 'mdi mdi-account-group', name: 'Quản lý người dùng', code: null, url: '/admin/operator' },// PERMISSIONS.MANAGE_OPERATOR
                ]
            };
            menuOrigin.push(systemMenus);
            var systemMenus = {
                name: '',
                subMenus: [
                    { icon: 'mdi mdi-account-multiple', name: 'Quản lý nhân viên', code: null, url: '/admin/employee' },// PERMISSIONS.MANAGE_OPERATOR
                ]
            };
            menuOrigin.push(systemMenus);
            var systemMenus = {
                name: '',
                subMenus: [
                    { icon: 'mdi mdi-format-list-bulleted', name: 'Quản lý đơn hàng', code: null, url: '/admin/order' },// PERMISSIONS.MANAGE_OPERATOR
                ]
            };
            menuOrigin.push(systemMenus);
            var systemMenus = {
                name: '',
                subMenus: [
                    { icon: 'mdi mdi-poll', name: 'Báo cáo ', code: null, url: '/admin/chart' },// PERMISSIONS.MANAGE_OPERATOR
                ]
            };
            menuOrigin.push(systemMenus);
            var systemMenus = {
                name: '',
                subMenus: [
                    { icon: 'mdi mdi-wrench', name: 'Thiết lập ', code: null, url: '/admin/setting' },// PERMISSIONS.MANAGE_OPERATOR
                ]
            };
            menuOrigin.push(systemMenus);

            var self = this;
            menuOrigin.forEach((menu) => {
                var menus = [];
                menu.subMenus.forEach((subMenu) => {
                    let hasPermission = self.checkPermission(subMenu.code);
                    if (hasPermission) {
                        menus.push(subMenu);
                    }
                });

                if (menus.length) {
                    menus.splice(0, 0, { icon: '', name: menu.name, code: '' });
                };

                self.menus.push(...menus);
            });
        },

        isActive: function (href) {
            let path = window.location.pathname + window.location.search;
            return path.toLowerCase() == href.toLowerCase();
        },

        checkPermission: function (permissionCode) {
            return this.$checkPermission(permissionCode);
        },

        getAvatarText: function (name) {
            name = name.trim();
            var result = '';
            var arrays = name.split(' ');

            if (arrays.length >= 2) {
                result = arrays[0][0] + arrays[arrays.length - 1][0];
            }

            if (result.length <= 1) {
                if (name.length >= 2) {
                    result = name.substring(0,2);
                }
                else {
                    result = name;
                }
            }

            return result.toUpperCase();
        }
    },

    computed: {
       
    },

    mounted() {
        
    },

    created() {
        this.getUserInfo();
    }
});