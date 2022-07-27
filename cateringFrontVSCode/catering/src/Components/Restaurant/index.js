import React from "react";
import RestaurantForm from "./RestaurantForm";


const OgolnygetFreshModelObject = () => ({
    Id: 0,
    NIP: 0,
    CompanyName: '',
    Email: '',
    PhoneNumber: '',
    UrlAddress: '',
    PasswordHash: '',
    Meals: []
})

const restaurantDtoGetFreshModelObject = () => ({
    Id: 0,
    NIP: 0,
    CompanyName: '',
    Email: '',
    PhoneNumber: '',
    UrlAddress: '',
})

const updateRestaurantDtoGetFreshModelObject = () => ({
    NIP: 0,
    PhoneNumber: '',
    UrlAddress: '',
})

export default function Restaurant() {
    
    return (
        <div>
            <RestaurantForm />
        </div>
    )






}