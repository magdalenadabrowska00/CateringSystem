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
          <Card.Text>Restaurant name: {restaurant.companyName}</Card.Text>
          <Card.Text>Email address: {restaurant.email}</Card.Text>
          <Card.Text>Phone number: {restaurant.phoneNumber}</Card.Text>
          <Card.Text>Nip: {restaurant.nip}</Card.Text>
          <Card.Text>Url address: {restaurant.urlAddress}</Card.Text>
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
