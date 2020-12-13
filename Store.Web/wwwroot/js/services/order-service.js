class OrderService {
    constructor() {

    }
    getById(id) {
        var url = `${API_ORDERS_CRUD}/${id}`;
        return base_axios.get(url);
    }

    save(order) {
        return base_axios.post(`${API_ORDERS_CRUD}`, order);
    }

    update(id, order) {
        return base_axios.put(`${API_ORDERS_CRUD}/${id}`, order);
    }

    delete(id) {
        return base_axios.delete(`${API_ORDERS_CRUD}/${id}`);
    }

    getOrderDetail(id) {
        var url = `${API_ORDERS_CRUD}/detail/${id}`;
        return base_axios.get(url);
    }
}