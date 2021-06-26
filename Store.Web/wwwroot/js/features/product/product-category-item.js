Vue.component('product-category-item', {
    template: `
        <div class="item-inner">
           <div class="item-img">
              <a class="product-image" title="Retis lapen casen" :href="productDetailUrl"> <img :src="product.thumnailUrl" alt=""> </a>
           </div>
                <div class="item-info">
                    <div class="info-inner">
                      <div class="item-title"> <a title="Retis lapen casen" :href="productDetailUrl">{{product.productName}}</a> </div>
                         <div class="item-content">
                             <div class="item-price">
                                <div class="price-box">
                                <p class="special-price"> <span class="price-label"></span> <span class="price">{{product.price | currency}} đ</span> </p>
                                
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