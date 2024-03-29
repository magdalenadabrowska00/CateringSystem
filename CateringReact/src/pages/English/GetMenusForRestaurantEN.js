import axios from "axios";
import { useContext, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Card from "react-bootstrap/Card";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Button, Row } from "react-bootstrap";
import AddMenusContext from "../../components/shared/AddMenusContext";

const GetMenusForRestaurantEN = (props) => {
  let language = JSON.parse(localStorage.getItem("lang"));
  let navigate = useNavigate();
  const { restaurantId } = useParams();
  console.log(restaurantId);
  const { menuId } = useParams();
  const [menus, setMenus] = useState([]);
  const { handleAdd } = useContext(AddMenusContext);

  const LoadDetail = (id) => {
    navigate(id + "/meals");
  };

  useEffect(() => {
    axios
      .get(
        "https://localhost:5001/api/restaurant/" +
          restaurantId +
          "/menu?language=" +
          language
      )
      .then((response) => {
        console.log(response.data);
        setMenus(response.data);
      });
  }, []);

  return (
    <Row xs={4} md={2} className="g-4">
      {menus.map((item) => (
        <Card
          key={item.Id}
          style={{
            width: "20rem",
            marginLeft: "30px",
            marginRight: "30px",
            marginTop: "60px",
          }}
        >
          <CardHeader title={item.id}>{item.menuTypeName}</CardHeader>
          <Card.Body>
            <Card.Text>Restaurant: {item.restaurantName}</Card.Text>
            <Card.Text>
              Total price for a day: {item.totalPriceForOneDay}
            </Card.Text>
            <Card.Text>Date: {item.date}</Card.Text>
            <Button
              variant="primary"
              onClick={() => {
                LoadDetail(item.id);
              }}
            >
              Go to menu
            </Button>{" "}
            <Button variant="primary" onClick={(e) => handleAdd(item)}>
              Add to a cart
            </Button>
          </Card.Body>
        </Card>
      ))}
    </Row>
  );
};
export default GetMenusForRestaurantEN;
