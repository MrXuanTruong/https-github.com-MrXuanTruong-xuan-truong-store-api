var vue = new Vue({
    el: '#page-content',
    data: {
        model: vueDataJson,
        order: null,
        orderService: new OrderService(),
    },
    components: {

    },
    methods: {
        getOrderDetail: function () {
            let self = this;
            this.orderService.getOrderDetail(this.model.Id)
                .then(function (response) {
                    self.order = response.data;

                })
                .catch(function (error) {
                    console.log(error);
                })
                .finally(function () {
                });
        },
    },

    computed: {
    },
    mounted: function () {
    },
    created: function () {
        this.getOrderDetail();
    }
});