class BrandService{
    constructor() {

    }
    getById(id) {
        var url = `${API_BRANDS_CRUD}/${id}`;
        return base_axios.get(url);
    }

    save(productBrand) {
        return base_axios.post(`${API_BRANDS_CRUD}`, productBrand);
    }

    update(id, productBrand) {
        return base_axios.put(`${API_BRANDS_CRUD}/${id}`, productBrand);
    }

    delete(id) {
        return base_axios.delete(`${API_BRANDS_CRUD}/${id}`);
    }
}