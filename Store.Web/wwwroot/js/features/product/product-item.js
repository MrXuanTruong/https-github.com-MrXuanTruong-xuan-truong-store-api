Vue.component('product-item', {
    template: `
        <div class="products">
            <div class="product">
                <div class="product-image">
                    <div class="image"> <a :href="productDetailUrl"><img :src="product.thumnailUrl" alt=""></a> </div>

                    <div v-if="product.isNew === true" class="tag new"><span>new</span></div>
                </div>

                <div class="product-info text-left">
                    <h3 class="name"><a :href="productDetailUrl">{{product.productName}}</a></h3>
                    <div class="rating rateit-small"></div>
                    <div class="description"></div>
                    <div class="product-price"> <span class="price"> {{product.price | currency}} đ</span> <!--<span class="price-before-discount">{{product.oldPrice | currency}}</span>--> <span class="product-detail"> <a :href="productDetailUrl">Xem chi tiết</a></span></div>
                </div>

                <!--<div class="cart clearfix animate-effect">
                    <div class="action">
                        <ul class="list-unstyled">
                            <li class="add-cart-button btn-group">
                                <button data-toggle="tooltip" class="btn btn-primary icon" type="button" title="Đặt hàng"> <i class="fa fa-shopping-cart"></i> </button>
                                <button class="btn btn-primary cart-btn" type="button">Add to cart</button>
                            </li>
                            <!--<li class="lnk wishlist"> <a data-toggle="tooltip" class="add-to-cart" :href="productDetailUrl" title="Yêu Thích"> <i class="icon fa fa-heart"></i> </a> </li>
                            <li class="lnk"> <a data-toggle="tooltip" class="add-to-cart"  title="So Sánh"> <i class="fa fa-signal" aria-hidden="true"></i> </a> </li>-->
                        </ul>
                    </div>
                </div>-->
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