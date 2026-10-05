import { Link } from "react-router-dom"


function Home() {
  return (
    <nav>
    <h1>Bienvenido a la tienda de productos Leva</h1>

        <Link to="/carrito">Carrito</Link>
        <Link to="/Login">Login</Link>
        <Link to="/">Home</Link>
    </nav>

  )
}

export default Home