import { Table, TableHead, TableBody, TableRow, TableCell } from "@mui/material";
import React, { useEffect, useState} from "react";
import { createEndpoint, ENDPOINTS } from "../../api";

export default function RestaurantForm() {

    const [restaurants, setRestaurants] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        createEndpoint(ENDPOINTS.RESTAURANT)
        .fetchAll()
        .then(response => {
            setRestaurants(response.data);
        },
        error => {
            setError(error);
        })
        //.catch(error => {
        //    if(error.response) console.log(error.response.data);
        //})

    }, [])


    



    if(error) {
        return <div>Error: {error.message}</div>;
    } else {
        return (          
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Restaurant id</TableCell>
                        <TableCell>NIP</TableCell>
                        <TableCell>Company name</TableCell>
                        <TableCell>Email</TableCell>
                        <TableCell>Phone number</TableCell>
                        <TableCell>Url address</TableCell>
                        <TableCell></TableCell>
                    </TableRow>
                </TableHead>

                <TableBody>
                    {
                        restaurants.map((item) => (
                            <TableRow key={item.Id}>
                                <TableCell>
                                    {item.Id}
                                </TableCell>
                                <TableCell>
                                    {item.NIP}
                                </TableCell>
                                <TableCell>
                                    {item.CompanyName}
                                </TableCell>
                                <TableCell>
                                    {item.Email}
                                </TableCell>
                                <TableCell>
                                    {item.PhoneNumber}
                                </TableCell>
                                <TableCell>
                                    {item.UrlAddress}
                                </TableCell>
                                <TableCell></TableCell>
                            </TableRow>
                        ))
                    }
                </TableBody>
            </Table>
            
            
            /*
            <ul>
                {restaurants.map((item) =>               
                    <li key={item.Id}>
                        {item.Id}
                        {item.NIP}
                        {item.CompanyName}
                        {item.Email}
                        {item.PhoneNumber}
                        {item.UrlAddress}
                    </li> 
                )}
            </ul> 
            */
        )
    }



    
}