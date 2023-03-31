import axios from "axios";
import { useEffect, useRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Card from "react-bootstrap/Card";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Button } from "react-bootstrap";

const GetRestaurantByIdEN = (props) => {
  let navigate = useNavigate();
  const { restaurantId } = useParams();
  const [restaurant, setRestaurant] = useState({});

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
      <Card key={restaurant.Id} style={{ width: "18rem" }}>
        <CardHeader title={restaurant.Id}></CardHeader>
        <Card.Body>
          <Card.Text>Restaurant name: {restaurant.CompanyName}</Card.Text>
          <Card.Text>Email address: {restaurant.Email}</Card.Text>
          <Card.Text>Phone number: {restaurant.PhoneNumber}</Card.Text>
          <Card.Text>Nip: {restaurant.NIP}</Card.Text>
          <Card.Text>Url address: {restaurant.UrlAddress}</Card.Text>
          <Button
            variant="primary"
            onClick={() => {
              navigate("menus");
            }}
          >
            Go to menus
          </Button>
        </Card.Body>
      </Card>
    )
  );
};

export default GetRestaurantByIdEN;
