class PopulateService {
    constructor() {

    }

    getUserStatuses() {
        return base_axios.get(`${API_POPULAR_USER_STATUSES}`);
    }
}