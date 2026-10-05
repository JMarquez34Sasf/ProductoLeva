import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Home from './pages/Home'
import Carrito from './pages/carrito'
import Login from './pages/Login'

function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Home></Home>} />
      <Route path="/carrito" element={<Carrito></Carrito>} />
      <Route path="/Login" element={<Login></Login>} />
    </Routes>
    </BrowserRouter>
  )
}

export default App