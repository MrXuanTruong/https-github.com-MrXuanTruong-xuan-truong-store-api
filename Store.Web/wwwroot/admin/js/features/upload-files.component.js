Vue.component("upload-files", {
    template:
    `<div class="slide-images">
        <div class="form-group">
            <input type="file" accept="image/*" name='files[]' multiple v-on:change="onloadImages" ref="fileInput">
        </div>
        <div class="row">
            <div class="slide-images-item" :class="itemClass" v-for="(url, index) in imageUrls" :key="index">
                <img v-bind:src="url" class="img-thumbnail w-100"/>
                <button class="btn btn-light btn-sm btn-remove" @click="onClickBtnRemove(url)"><i class="fa fa-remove"></i></button>
            </div>
        </div>
    </div>
    `,
    props: {
        originUrls: Array,
        objectType: String,
        itemClass: String,
    },
    data: function () {
        return {
            imageUrls: [],
        }
    },
    methods: {
        onloadImages(e) {
            var self = this;
            let uploadFileService = new UploadFileService(this.objectType);
            uploadFileService.uploads(e.target.files)
                .then(function (response) {
                    if (response.data.result) {
                        self.imageUrls = self.imageUrls.concat(response.data.fileNames);
                        self.$emit("on-upload-completed", self.imageUrls);
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

        onClickBtnRemove: function (slideImage) {
            var self = this;
            self.imageUrls.map(function (item, index) {
                if (item == slideImage) {
                    self.imageUrls.splice(index, 1);
                    return;
                }
            });

            self.$emit("on-upload-completed", self.imageUrls);
        }

    },
    mounted: function () {

    },
    created: function () {
        this.imageUrls = this.originUrls;
    },
});