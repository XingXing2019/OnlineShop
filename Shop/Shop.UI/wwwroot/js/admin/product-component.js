Vue.component('product-manager',
    {
        template: `<div>
                <div v-if="!editing">
                    <button class="button" v-on:click="newProducts">Add New Products</button>
                    <table class="table">
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Price</th>
                        </tr>
                        <tr v-for="(product, index) in products">
                            <td>{{product.id}}</td>
                            <td>{{product.name}}</td>
                            <td>{{product.description}}</td>
                            <td>{{product.price}}</td>
                            <td><a @click="editProduct(product, index)">Edit</a></td>
                            <td><a @click="deleteProduct(product.id, index)">Delete</a></td>
                        </tr>
                    </table>
                </div>

                <div v-else>
                    <div class="field">
                        <label class="label">Product Name</label>
                        <div class="control">
                            <input class="input" v-model="productModel.name" />
                        </div>
                    </div>
                    <div class="field">
                        <label class="label">Product Description</label>
                        <div class="control">
                            <input class="input" v-model="productModel.description" />
                        </div>
                    </div>
                    <div class="field">
                        <label class="label">Price</label>
                        <div class="control">
                            <input class="input" v-model="productModel.price" />
                        </div>
                    </div>
                    <button class="button is-success" @click="createProduct" v-if="!productModel.id">Create Product</button>
                    <button class="button is-warning" @click="updateProduct" v-else>Update Product</button>
                    <button class="button" @click="cancel">Cancel</button>
                </div>
            </div>`,

        data() {
            return {
                loading: false,
                objectIndex: 0,
                editing: false,
                productModel: {
                    id: 0,
                    name: "Product Name",
                    description: "Product Description",
                    price: "2.99"
                },
                products: [],
            }
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
                        this.products.push(res.data);
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
                        this.products.splice(this.objectIndex, 1, res.data);
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