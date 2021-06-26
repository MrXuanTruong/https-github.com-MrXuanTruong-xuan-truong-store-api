Vue.component('product-selling-item', {
    template: `
                                <div class="item">
                                    <div class="item-inner">
                                        <div class="item-img">
                                            <div class="item-img-info">
                                                <div class="link-quickview"><a :href="productDetailUrl" class="quick-view"><i class="fa fa-eye"></i></a></div>
                                                <div class="product-cartitem">1</div>
                                                <a class="product-image" title="Retis lapen casen" :href="productDetailUrl"> <img :src="product.thumnailUrl" alt=""> </a>


                                                
                                            </div>
                                        </div>
                                        <div class="item-info">
                                            <div class="info-inner" id="selling-product">
                                                <div class="item-title"> <a title="Retis lapen casen" :href="productDetailUrl">{{product.productName}}</a> </div>
                                                <div class="rating rateit-small"></div>
                                                <div class="product-item-description"> Với thiết kế hiện đại-{{product.productName}} được đánh giá là mẫu xe hot nhất hiện nay
                                                </div>
                                                <div class="item-content">
                                                    <div class="item-price">
                                                        <div class="price-box">
                                                            <p class="special-price"> <span class="price-label"></span> <span class="price">Giá bán: {{product.price | currency}} đ</span> </p>
                                                            
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
    `,
    props: {
        product: Object,
    },
    data: function () {
        return {

        };
    },
    components: {

    },
    methods: {

    },
    computed: { 
        productDetailUrl: function () {
            let url = '/product/detail?id=' + this.product.id;
            return url;
        }
    },
    mounted: function () {

    },
    created: function () {

    }
})