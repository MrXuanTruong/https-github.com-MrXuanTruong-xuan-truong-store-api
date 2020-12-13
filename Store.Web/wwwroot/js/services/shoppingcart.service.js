class ShoppingCartService{
    constructor() {

    }

    getShoppingCart() {
        return base_axios.get(API_GET_SHOPPINGCART);
    }
}