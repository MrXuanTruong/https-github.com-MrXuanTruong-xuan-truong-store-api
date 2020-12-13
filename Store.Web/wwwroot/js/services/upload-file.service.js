class UploadFileService {
    constructor(objectType) {
        this.objectType = objectType
    }

    getUploadRequest() {
        const upload_axios = axios.create({
            baseURL: Vue.prototype.$baseAPIURL,
            timeout: 60 * 1000,
            headers: {
                "Content-Type": `application/jsonmultipart/form-data; Access-Control-Allow-Origin: *`,
                'Authorization': "Bearer " + Vue.prototype.$getToken()
            }
        });

        return upload_axios;
    }

    upload(file) {
        const formData = new FormData();
        formData.append('files', file, file.name);
        formData.append('objectType', this.objectType);
        
        return this.getUploadRequest().post(`${API_UPLOAD_FILES}`, formData);
    }

    uploads(files) {
        const formData = new FormData();
        formData.append('objectType', this.objectType);
        for (var i = 0; i < files.length; i++) {
            let file = files[i];
            formData.append('files', file, file.name);
        }

        return this.getUploadRequest().post(`${API_UPLOAD_FILES}`, formData);
    }
}