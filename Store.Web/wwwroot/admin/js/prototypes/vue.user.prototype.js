function getUserInfo() {
    let json = localStorage.getItem('admin_info');
    let operatorInfo = null;
    if (json) {
        operatorInfo = JSON.parse(json);
    }
    return operatorInfo;
}
Vue.prototype.$getUserInfo = getUserInfo;

function setUserInfo(value) {
    localStorage.setItem('admin_info', JSON.stringify(value));
}

Vue.prototype.$setUserInfo = setUserInfo;

function checkPermission(permissionCode) {
    if (isNullOrEmpty(permissionCode)) {
        return true;
    }

    let operator = getUserInfo();

    if (!operator) {
        return false
    }

    let result = operator.permissions.filter((value, index) => {
        return value === permissionCode;
    });

    return result.length;
}

Vue.prototype.$checkPermission = checkPermission;