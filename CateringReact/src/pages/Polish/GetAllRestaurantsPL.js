import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate, BrowserRouter as Router } from "react-router-dom";
import Card from "react-bootstrap/Card";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Button } from "react-bootstrap";

const GetAllRestaurantsPL = (props) => {
  let navigate = useNavigate();
  const [restaurants, setRestaurants] = useState([]);

  const LoadDetail = (id) => {
    navigate("/restaurantsPL/" + id);
  };

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
    axios.get("https://localhost:5001/api/restaurant/").then((response) => {
      setRestaurants(response.data);
    });
  }, []);

  console.log(restaurants);
  return restaurants.map((item) => (
    <Card
      key={item.Id}
      style={{
        width: "20rem",
        marginLeft: "30px",
        marginRight: "30px",
        marginTop: "60px",
      }}
    >
      <CardHeader title={item.id}></CardHeader>
      <Card.Body>
        <Card.Text>Nazwa restauracji: {item.companyName}</Card.Text>
        <Card.Text>Adres email: {item.email}</Card.Text>
        <Card.Text>Numer kontaktowy: {item.phoneNumber}</Card.Text>
        <Card.Text>NIP: {item.nip}</Card.Text>
        <Card.Text>Adres strony: {item.urlAddress}</Card.Text>
        <Button
          variant="primary"
          onClick={() => {
            LoadDetail(item.id);
          }}
        >
          Idź do menu {item.companyName}
        </Button>
      </Card.Body>
    </Card>
  ));
};

export default GetAllRestaurantsPL;
