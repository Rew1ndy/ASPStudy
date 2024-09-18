import {React, useState} from "react";
import "./products.css";

function CurrencyConverter({ priceInUAH, exchangeRate }) {
    exchangeRate = 41;
    const priceInUSD = (priceInUAH / exchangeRate).toFixed(2); 

    return (
        <>
            {console.log(priceInUSD)}
            <p>Price in USD: {priceInUSD} $</p>
        </>
    );
}

function ProductsInfo(props) {
    const [products, setProducts] = useState([]); 
    const [comment, setComment] = useState('');    
    const [newProductName, setNewProductName] = useState(''); 
    const [newProductPrice, setNewProductPrice] = useState('');

    const { prodName, prodPrice, prodDescription, exchangeRate } = props; 

    const addProduct = () => {
        const newProduct = {
            id: products.length + 1, 
            name: newProductName,
            price: newProductPrice,
        };
        setProducts([...products, newProduct]);
        setNewProductName('');  
        setNewProductPrice('');
    };

    const deleteProduct = (productId) => {
        setProducts(products.filter((product) => product.id !== productId));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(comment);
        alert(`Ваш відгук: "${comment}" додано успішно!`);
        setComment(''); 
    };

    return (
        <>
            <div className="addProductsFeed">
                
                <form onSubmit={handleSubmit}>
                    <div className="comments">
                        <textarea
                            value={comment}
                            onChange={(e) => setComment(e.target.value)}
                            placeholder="Leave a comment"
                        />
                        <button type="submit">Submit comment</button>
                    </div>
                </form>

                <div className="productsAddFeed">
                    <input
                        type="text"
                        placeholder="Product name"
                        value={newProductName}
                        onChange={(e) => setNewProductName(e.target.value)}
                    />
                    <input
                        type="number"
                        placeholder="Product price"
                        value={newProductPrice}
                        onChange={(e) => setNewProductPrice(e.target.value)}
                    />
                    <button onClick={addProduct}>Add Product</button>
                </div>
            </div>

            <div className="productsFeed">
                <h2>Product List</h2>
                <ul>
                    {products.map((product) => (
                        <li key={product.id}>
                            {product.name} - {product.price} UAH
                            <CurrencyConverter priceInUAH={product.price} exchangeRate={exchangeRate} />
                            <button onClick={() => deleteProduct(product.id)}>Delete</button>
                        </li>
                    ))}
                </ul>
            </div>
        </>
    );
}

export {ProductsInfo};
