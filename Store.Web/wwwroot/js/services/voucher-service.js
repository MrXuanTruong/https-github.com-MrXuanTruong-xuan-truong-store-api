class VoucherService{
    constructor() {

    }
    getById(id) {
        var url = `${API_VOUCHER_CRUD}/${id}`;
        return base_axios.get(url);
    }

    save(voucher) {
        return base_axios.post(`${API_VOUCHER_CRUD}`, voucher);
    }

    update(id, voucher) {
        return base_axios.put(`${API_VOUCHER_CRUD}/${id}`, voucher);
    }

    delete(id) {
        return base_axios.delete(`${API_VOUCHER_CRUD}/${id}`);
    }

    getByVoucherCode(voucherCode) {
        return base_axios.get(`${API_VOUCHER_CRUD}/getByVoucherCode?voucherCode=${voucherCode}`);
    }
}