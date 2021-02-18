var app = new Vue({
    el: '#app',

    data: {
            loading: false,
            objectIndex: 0,
            editing: false,
            productModel: {
                id: 0,
                name: "Product Name",
                description: "Product Description",
                price: "$2.99"
            },
            products: [],
    },
    mounted() {
        this.getProducts();
    },
    methods: {
        getProduct(id) {
            this.loading = true;
            axios.get('/Admin/products/' + id)
                .then(res => {
                    console.log(res);
                    var product = res.data;
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        price: product.price,
                    };
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getProducts() {
            this.loading = true;
            axios.get('/Admin/products')
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
        createProduct() {
            axios.post('/Admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    if(res.data)
                        this.products.push(res.data);
                    else 
                        alert("Please enter valid price");
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        updateProduct() {
            axios.put('/Admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    if(res.data)
                        this.products.splice(this.objectIndex, 1, res.data);
                    else
                        alert("Please enter valid price");
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        deleteProduct(id, index) {
            this.loading = true;
            axios.delete('/Admin/products/' + id)
                .then(res => {
                    console.log(res);
                    this.products.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        editProduct(product, index) {
            this.objectIndex = index;
            this.editing = true;
            this.productModel = {
                id: product.id,
                name: product.name,
                description: product.description,
                price: product.price,
            }
        },
        newProducts() {
            this.editing = true;
            this.productModel.id = 0;
        },
        cancel() {
            this.editing = false;
        }
    },
    computed: {

    }
});