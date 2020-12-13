function getUserInfo() {
    let json = localStorage.getItem('customer_info');
    let operatorInfo = null;
    if (json) {
        operatorInfo = JSON.parse(json);
    }
    return operatorInfo;
}
Vue.prototype.$getUserInfo = getUserInfo;

function setUserInfo(value) {
    localStorage.setItem('customer_info', JSON.stringify(value));
}

Vue.prototype.$setUserInfo = setUserInfo;