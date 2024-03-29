import { Table, TableHead, TableBody, TableRow, TableCell } from "@mui/material";
import React, { useEffect, useState} from "react";
import { createEndpoint, ENDPOINTS } from "../../api";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";

export default function RestaurantForm() {

    const [restaurant, setRestaurants] = useState([]);
    const [error, setError] = useState(null);
    let navigate = useNavigate();

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
                        <TableCell>
                        Restaurant id
                        </TableCell>
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
                        restaurant.map((item) => (
                            <TableRow key={item.Id}>
                                <TableCell>
                                    <Link to={ `${item.Id}/` + ENDPOINTS.MENU } activeClassName="current">{item.Id}</Link>
                                </TableCell>
                                <TableCell>
                                    {item.NIP}
                                </TableCell>
                                <TableCell>
                                    <Link to={`/restaurant/${item.Id}/menus`} activeClassName="active">{item.CompanyName}</Link>
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

        )
    }



    
}