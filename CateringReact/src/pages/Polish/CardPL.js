import { useContext } from "react";
import Card from "react-bootstrap/Card";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Row } from "react-bootstrap";
import AddMenusContext from "../../components/shared/AddMenusContext";

const CardPL = (props) => {
  const { menuCard } = useContext(AddMenusContext);

  return (
    <Row xs={4} md={2} className="g-4">
      {menuCard.map((item) => (
        <Card
          key={item.id}
          style={{
            width: "20rem",
            marginLeft: "30px",
            marginRight: "30px",
            marginTop: "60px",
          }}
        >
          <CardHeader title={item.id}>{item.menuName}</CardHeader>
          <Card.Body>
            <Card.Text>Cena menu: {item.totalPrice}</Card.Text>
          </Card.Body>
        </Card>
      ))}
    </Row>
  );
};
export default CardPL;
