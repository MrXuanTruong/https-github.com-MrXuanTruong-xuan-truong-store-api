class ProductService{
    constructor() {

    }

    getById(id) {
        var url = `${API_PRODUCT_CRUD}/${id}`;
        return base_axios.get(url);
    }

    save(product) {
        return base_axios.post(`${API_PRODUCT_CRUD}`, product);
    }

    update(id, product) {
        return base_axios.put(`${API_PRODUCT_CRUD}/${id}`, product);
    }

    delete(id) {
        return base_axios.delete(`${API_PRODUCT_CRUD}/${id}`);
    }

    getNewestProducts() {
        return base_axios.get(API_PRODUCT_NEWEST);
    }

    getFeatureProducts() {
        return base_axios.get(API_PRODUCT_FEATURE);
    }
    instock(product) {
        return base_axios.post(`${API_PRODUCT_CRUD}/inStocks`, product);
    }
    outstock(orderId) {
        return base_axios.post(`${API_PRODUCT_CRUD}/outStocks?orderId=` + orderId);
    }
    tranferStock(product) {
        return base_axios.post(`${API_PRODUCT_CRUD}/tranferStock`, product);
    }
    getProductDetail(id) {
        return base_axios.get(API_PRODUCT_DETAIL + '?id=' + id);
    }
}