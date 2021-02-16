var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        products: [],
        selectedProduct: null,
        newStock: {
            productId: 0,
            description: "Size",
            qty: 10
        }
    },
    mounted() {
        this.getStock();
    },
    methods: {
        getStock() {
            this.loading = true;
            axios.get('/Admin/stocks')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateStock() {
            this.loading = true;
            var vm = {
                stocks: this.selectedProduct.stocks.map(x => {
                    return {
                        id: x.id,
                        description: x.description,
                        qty: x.qty,
                        productId: x.productId,
                    }
                })
            };
            axios.put('/Admin/stocks/', vm)
                .then(res => {
                    console.log(res);
                    if (!res.data)
                        alert("Please enter valid stock quantity");
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        deleteStock(id, index) {
            this.loading = true;
            axios.delete('/Admin/stocks/' + id)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stocks.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        addStock() {
            this.loading = true;
            axios.post('/Admin/stocks', this.newStock)
                .then(res => {
                    console.log(res);
                    if(res.data)
                        this.selectedProduct.stocks.push(res.data);
                    else
                        alert("Please enter valid stock quantity");
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = product.id;
        },
    }
})