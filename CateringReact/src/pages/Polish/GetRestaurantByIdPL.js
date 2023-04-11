import axios from "axios";
import { useEffect, useRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Card from "react-bootstrap/Card";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Button } from "react-bootstrap";

const GetRestaurantByIdPL = (props) => {
  let navigate = useNavigate();
  const { restaurantId } = useParams();
  const [restaurant, setRestaurant] = useState({});

  console.log(restaurantId);

  // const [lang, setLang] = useState(() => {
  //   if (localStorage.getItem("lang")) {
  //     let language = JSON.parse(localStorage.getItem("lang"));
  //     return language;
  //   }
  //   return null;
  // });

  //const {id} = useParams(); -> do useEffect(`URL cały/${id}`)
  //https://localhost:5001/api/product/getProducts?language=" + lang
  useEffect(() => {
    axios
      .get("https://localhost:5001/api/restaurant/" + restaurantId)
      .then((response) => {
        setRestaurant(response.data);
      });
  }, []);

  return (
    restaurant && (
      <Card key={restaurant.id} style={{ width: "18rem" }}>
        <CardHeader title={restaurant.id}></CardHeader>
        <Card.Body>
          <Card.Text>Nazwa restauracji: {restaurant.companyName}</Card.Text>
          <Card.Text>Adres email: {restaurant.email}</Card.Text>
          <Card.Text>Numer kontaktowy: {restaurant.phoneNumber}</Card.Text>
          <Card.Text>NIP: {restaurant.nip}</Card.Text>
          <Card.Text>Adres strony: {restaurant.urlAddress}</Card.Text>
          <Button
            variant="primary"
            onClick={() => {
              navigate("menus");
            }}
          >
            Zobacz dostępne menu
          </Button>
        </Card.Body>
      </Card>
    )
  );
};

export default GetRestaurantByIdPL;
