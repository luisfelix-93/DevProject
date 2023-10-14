import axios from "axios";

export const api = axios.create({
    baseURL: 'https://localhost:7196/api',
});
// Chamada da API para criar sessão, e logar no sistema

export const createSession = async (userName, password) => {
 return api.post("/auth", { userName, password })

}