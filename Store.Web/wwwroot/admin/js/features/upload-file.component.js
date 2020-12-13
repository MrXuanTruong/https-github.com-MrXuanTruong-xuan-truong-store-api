Vue.component("upload-file", {
    template:
    `<div>
        <input type="file" accept="image/*" v-on:change="onloadImage" ref="fileInput">
        <img v-if="avatarUrl" class="img-thumbnail w-100 mt-3" v-bind:src="avatarUrl" />
    </div>
    `,
    props: {
        originUrl: String,
        objectType: String
    },
    data: function () {
        return {
            avatarFile: null,
            avatarUrl: null,
        }
    },
    methods: {
        onloadImage(e) {
            this.avatarFile = e.target.files[0];
            var self = this;
            let uploadFileService = new UploadFileService(this.objectType);
            uploadFileService.upload(this.avatarFile)
                .then(function (response) {
                    if (response.data.result) {
                        self.avatarUrl = response.data.fileNames[0];
                        self.$emit("on-upload-completed", response.data.fileNames[0]);
                    }
                    else {
                        self.$showDangerToast(response.data.messages[0]);
                    }
                    
                }).catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                    const input = self.$refs.fileInput;
                    input.value = '';
                });
        },
    },
    mounted: function () {

    },
    created: function () {
        this.avatarUrl = this.originUrl;
    },
});