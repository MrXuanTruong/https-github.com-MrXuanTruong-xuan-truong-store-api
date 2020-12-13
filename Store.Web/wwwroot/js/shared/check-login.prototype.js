Vue.prototype.$checkLogin = function () {
    var token = localStorage.getItem('customer_token');
    var token_expired = localStorage.getItem('customer_token_expired');
    if (token === undefined || token_expired === null) {
        //gotoLoginPage();
    }
    else {

        let token_expired_date = moment(token_expired);
        let now = moment();

        let isValidExpired = token_expired_date.isAfter(now);
        if (isValidExpired) {

        }
        else {
            localStorage.removeItem('customer_token');
            localStorage.removeItem('customer_token_expired');
            localStorage.removeItem('customer_info');
        }
    }
}


Vue.prototype.$checkLogin();