import axios from "axios"
import type { LoginCreate } from "../types/Logins"

const URL_BASE ="https://localhost:7290/"

const login = async (data:LoginCreate) => {
    const res = await axios.post(`${URL_BASE}api/Login`,data)
    const token = res.data.token
    return token
}
