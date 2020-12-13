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

            let productMenus = {
                name: 'Sản phẩm ',
                subMenus: [
                    { icon: 'mdi mdi-format-list-checks', name: 'Danh sách sản phẩm', code: null, url: '/admin/product' },      
                    { icon: 'mdi mdi-arrow-left-bold-circle', name: 'Nhập kho', code: null, url: '/admin/Stock/inStock' },
                    { icon: 'mdi mdi-arrow-right-bold-circle', name: 'Xuất kho', code: null, url: '/admin/Stock/outStock' },
                    { icon: 'mdi mdi mdi-repeat', name: 'Luân chuyển kho', code: null, url: '/admin/Stock/transferStock' },
                    { icon: 'mdi mdi-format-align-left', name: 'Nhãn hiệu', code: null, url: '/admin/brand' },
                    { icon: 'mdi mdi-format-list-bulleted-type', name: 'Loại xe', code: null, url: '/admin/category' },
                    { icon: 'mdi mdi-source-branch', name: 'Chi nhánh', code: null, url: '/admin/branch' },
                ]
            };
            menuOrigin.push(productMenus);
            
            var systemMenus = {
                name: 'Hệ thống',
                subMenus: [
                    { icon: 'mdi mdi-account-group', name: 'Quản lý người dùng', code: null, url: '/admin/operator' },// PERMISSIONS.MANAGE_OPERATOR
                ]
            };
            menuOrigin.push(systemMenus);
            
            var orderMenus = {
                name: 'Đơn hàng',
                subMenus: [
                    { icon: 'mdi mdi-format-list-bulleted', name: 'Quản lý đơn hàng', code: null, url: '/admin/order' },// PERMISSIONS.MANAGE_OPERATOR
                ]
            };
            menuOrigin.push(orderMenus);

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