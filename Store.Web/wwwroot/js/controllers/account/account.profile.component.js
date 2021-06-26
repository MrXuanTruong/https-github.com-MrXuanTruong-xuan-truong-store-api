var vue_menus = new Vue({
    el: '#profile-user',

    data: {
        operatorInfo: null,
        avatarText: '',
    },

    methods: {
        onClickBtnLogin: function () {
            location.href = '/home/account/login';
        },
        onClickBtnLogout: function () {
            localStorage.setItem('client_token', null);
            localStorage.setItem('client_token_expired', null);
            location.href = '/home/account/login';
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
                    result = name.substring(0, 2);
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