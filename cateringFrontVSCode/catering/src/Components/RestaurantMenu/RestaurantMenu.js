import { Table, TableHead, TableBody, TableRow, TableCell, Button, Link } from "@mui/material";
import React, { useEffect, useState} from "react";
import { createEndpoint, ENDPOINTS } from "../../api";
import { useNavigate } from "react-router-dom";
import { FaceRetouchingNaturalOutlined } from "@mui/icons-material";

export default function RestaurantMenu() {

    const [menu, setMenus] = useState([]);
    const [error, setError] = useState(null);
    let navigate = useNavigate();
//"https://localhost:5001/api/restaurant/2/menu"
//createEndpoint(ENDPOINTS.RESTAURANT + id + '/' + ENDPOINTS.MENU + '/')

//        createEndpoint(ENDPOINTS.RESTAURANT + { id }+ '/' + ENDPOINTS.MENU + '/')
//.fetchById()

//fetch(`https://localhost:5001/api/restaurant/`+{id}`+/menu`)   działa
    useEffect((id) => {
        createEndpoint(ENDPOINTS.RESTAURANT + { id }+ '/' + ENDPOINTS.MENU + '/')
        .fetchById()
        .then(response => {
            setMenus(response.data);
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
                        Menu id
                        </TableCell>
                        <TableCell>Menu type</TableCell>
                        <TableCell>Restaurant</TableCell>
                        <TableCell>Total price for one day</TableCell>
                        <TableCell>Phone number</TableCell>
                        <TableCell>Date</TableCell>
                        <TableCell></TableCell>
                    </TableRow>
                </TableHead>

                <TableBody>
                    {
                        menu.map((item) => (
                            <TableRow key={item.Id}>
                                <TableCell>
                                    {item.Id}
                                </TableCell>
                                <TableCell>
                                    {item.MenuTypeName}
                                </TableCell>
                                <TableCell>
                                    {item.RestaurantName}
                                </TableCell>
                                <TableCell>
                                    {item.TotalPriceForOneDay}
                                </TableCell>
                                <TableCell>
                                    {item.Date}
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