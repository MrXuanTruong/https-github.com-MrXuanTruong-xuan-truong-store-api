class PopulateService {
    constructor() {

    }
    
    getUserStatuses() {
        return base_axios.get(`${API_POPULAR_USER_STATUSES}`);
    }
    getAccountTypes() {
        return base_axios.get(`${API_POPULAR_ACCOUNT_TYPES}`);
    }
    getBranches() {
        return base_axios.get(`${API_POPULAR_BRANCHES}`);
    }
    getProductStatuses() {
        return base_axios.get(`${API_POPULAR_PRODUCT_STATUSES}`);
    }
    getColors() {
        return base_axios.get(`${API_POPULAR_COLORS}`);
    }
    colorsByProductId(productId) {
        return base_axios.get(`${API_POPULAR_ColorsByProductId}?productId=` + productId);
    }
    getBrands() {
        return base_axios.get(`${API_POPULAR_BRANDS}`);
    }
    getCatagories() {
        return base_axios.get(`${API_POPULAR_CATEGORIES}`);
    }
    getProducts() {
        return base_axios.get(`${API_POPULAR_PRODUCTS}`);
    }
    
    getOrderStatuses() {
        return base_axios.get(`${API_POPULAR_ORDER_STATUSES}`);
    }

    getOrderConfirmeds() {
        return base_axios.get(`${API_POPULAR_ORDER_CONFIRMED}`);
    }

    
}