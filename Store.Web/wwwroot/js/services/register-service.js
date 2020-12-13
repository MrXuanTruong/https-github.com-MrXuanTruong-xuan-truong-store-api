class RegisterService {
    constructor() {

    }

    save(register) {
        return base_axios.post(`${API_REGISTER_ACCOUNT}`, register);
    }
}