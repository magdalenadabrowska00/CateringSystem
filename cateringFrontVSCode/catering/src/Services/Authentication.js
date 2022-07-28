import axios from "axios";
import { useEffect } from "react";
import {createAccountEndpoint, ENDPOINTS} from '../api';


const api_url = 'https://localhost:5001/api/account/login';//createAccountEndpoint(ENDPOINTS.LOGIN)

const login = (email, password) => {
    return axios
    .post(api_url, {
        email,
        password,
    })
    .then(response => {
        if(response.data.accessToken) {
            localStorage.setItem("email", JSON.stringify(response.data));
        }
        return response.data;
    });
};

const logout = () => {
    localStorage.removeItem("email");
}

const getCurrentUser = () => {
    return JSON.parse(localStorage.getItem("email"));
}

const AuthService = {
    login,
    logout,
    getCurrentUser
}

export default AuthService;