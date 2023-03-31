import axios from "axios";
import { useEffect, useRef, useState } from "react";
import {
  useNavigate,
  Link,
  BrowserRouter as Router,
  generatePath,
  Switch,
  Route,
  useHistory,
  useParams,
} from "react-router-dom";
import Card from "react-bootstrap/Card";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Button, Row } from "react-bootstrap";

const GetAllRestaurantsEN = (props) => {
  let navigate = useNavigate();
  const [restaurants, setRestaurants] = useState([]);

  const LoadDetail = (id) => {
    navigate("/restaurantsEN/" + id);
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
      <CardHeader title={item.Id}></CardHeader>
      <Card.Body>
        <Card.Text>Restaurant name: {item.CompanyName}</Card.Text>
        <Card.Text>Email address: {item.Email}</Card.Text>
        <Card.Text>Phone number: {item.PhoneNumber}</Card.Text>
        <Card.Text>Nip: {item.NIP}</Card.Text>
        <Card.Text>Url address: {item.UrlAddress}</Card.Text>
        <Button
          variant="primary"
          onClick={() => {
            LoadDetail(item.Id);
          }}
        >
          Go to menu {item.CompanyName}
        </Button>
      </Card.Body>
    </Card>
  ));
};

export default GetAllRestaurantsEN;
