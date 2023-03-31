import axios from "axios";
import { Button } from "react-bootstrap";
import { useContext, useEffect, useRef, useState } from "react";
import Card from "react-bootstrap/Card";
import CardHeader from "react-bootstrap/esm/CardHeader";
import ListGroup from "react-bootstrap/ListGroup";
import Container from "react-bootstrap/Container";

export default function MenusListEN() {
  const [menus, setMenus] = useState([]);

  //`URL cały/${id}`
  useEffect(() => {
    axios
      .get(`https://localhost:5001/api/restaurant/${id}/menu`)
      .then((response) => {
        setMenus(response.data);
      });
  }, []);

  return menus.map((item) => (
    <>
      <Card key={item.id} style={{ width: "18rem" }}>
        <CardHeader title={item.id}></CardHeader>
        <Card.Body>
          <Card.Text>{item.menuTypeName}</Card.Text>
          <Card.Text>{item.totalPriceForOneDay}</Card.Text>
          <Card.Text>{item.date}</Card.Text>

          {/* <Button variant="primary" onClick={(e) => handleAdd(item, ilosc)}>
            Dodaj
          </Button> */}
        </Card.Body>
      </Card>
    </>
  ));
}
