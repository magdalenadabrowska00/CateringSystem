import axios from "axios";


const BASE_URL = 'https://localhost:5001/api/';

export const ENDPOINTS = {
    RESTAURANT: 'restaurant',
    MEAL: 'meal',
    MENU: 'menu',
    ORDER: 'order',
    ACCOUNT: 'account'
};

export const createEndpoint = endpoint => {
    let url = BASE_URL + endpoint + '/';
    return {
        fetchAll: () => axios.get(url),
        fetchById: id => axios.get(url + id),
        create: newRecord => axios.post(url, newRecord),
        update: (id, updatedRecord) => axios.put(url + id, updatedRecord),
        delete: id => axios.delete(url + id)
    }
}

export const createRestaurantEndpoint = endpoint => {
    let url = BASE_URL + ENDPOINTS.RESTAURANT + '/' + endpoint;
    return {
        fetchAll: () => axios.get(url),
        fetchById: id => axios.get(url + id),
        create: newRecord => axios.post(url, newRecord),
        update: (id, updatedRecord) => axios.put(url + id, updatedRecord),
        delete: id => axios.delete(url + id)
    }
}