class BrandService{
    constructor() {

    }
    getById(id) {
        return base_axios.get(`${API_BRANDS_SEARCH}/${id}`);
    }

    save(productBrand) {
        return base_axios.post(`${API_BRANDS_SEARCH}`, productBrand);
    }

    update(id, productBrand) {
        return base_axios.put(`${API_BRANDS_SEARCH}/${id}`, productBrand);
    }

    delete(id) {
        return base_axios.delete(`${API_BRANDS_SEARCH}/${id}`);
    }
}