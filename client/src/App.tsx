import { useEffect, useState } from "react"
import { Product } from "./Product";

function App() {
  const [products, setProducts] = useState<Product[]>([])

  useEffect(
    () => {
      fetch('https://localhost:7262/api/Products')
      .then(response => response.json())
      .then(data => setProducts(data))
    }, []
  );

  const addProduct = () => {
    setProducts(prevState => [... prevState, 
      {
        id: (prevState.length +1),
        name: 'product ' + (prevState.length+1), 
        price: (prevState.length*100)+100,
        description: '',
        pictureUrl: '',
        type: '',
        brand: '',
        quantityInStock: 1
      }
    ])
  }

  return (
    <div>
      <h1>Re-store</h1>
      <ul>
        {
          products.map((item, index) => (<li key={index}>{item.name} - {item.price}</li>))
        }
      </ul>
      <button onClick={addProduct}>Add Product</button>
    </div>
  )
}

export default App
