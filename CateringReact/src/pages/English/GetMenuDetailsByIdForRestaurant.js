import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Card from "react-bootstrap/Card";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Button, Row } from "react-bootstrap";

const GetMenuDetailsByIdForRestaurant = (props) => {
  let language = JSON.parse(localStorage.getItem("lang"));
  console.log(language);

  const { menuId } = useParams();
  const { restaurantId } = useParams();
  console.log("Id restauracji:" + restaurantId);

  const [menuMeals, setMenuMeals] = useState([]);

  useEffect(() => {
    axios
      .get(
        "https://localhost:5001/api/restaurant/" +
          restaurantId +
          "/menu/" +
          menuId +
          "/meals?language=" +
          language
      )
      .then((response) => {
        console.log(response.data);
        setMenuMeals(response.data);
      });
  }, []);

  return (
    <Row xs={4} md={2} className="g-4">
      {menuMeals.map((item) => (
        <Card
          key={item.id}
          style={{
            width: "20rem",
            marginLeft: "30px",
            marginRight: "30px",
            marginTop: "60px",
          }}
        >
          <CardHeader title={item.Id}>{item.name}</CardHeader>
          <Card.Body>
            <Card.Text>Way of giving: {item.wayOfGiving}</Card.Text>
            <Card.Text>Description: {item.description}</Card.Text>
            <Card.Text>Price: {item.price}</Card.Text>
          </Card.Body>
        </Card>
      ))}
    </Row>
  );
};
export default GetMenuDetailsByIdForRestaurant;
