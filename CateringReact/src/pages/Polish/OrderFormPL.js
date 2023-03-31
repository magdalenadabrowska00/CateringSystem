import { Container, Row } from "react-bootstrap";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useContext, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import AddMenusContext from "../../components/shared/AddMenusContext";
import Col from "react-bootstrap/Col";

const OrderFormPL = () => {
  const { menusIds } = useContext(AddMenusContext);
  console.log(menusIds);

  const navigate = useNavigate();
  let language = JSON.parse(localStorage.getItem("lang"));
  console.log(language);

  const [deliveryMenId, setDeliveryMenId] = useState();
  console.log(deliveryMenId);

  const orderDate = useRef("");
  const deliveryDate = useRef("");
  const deliveryCity = useRef("");
  const deliveryAddress = useRef("");
  const deliveryPostalCode = useRef("");
  // const deliveryMenId = useRef("");
  const orderDeliveryDate = useRef("");
  const orderDeliveryStartHour = useRef("");
  const orderDeliveryEndHour = useRef("");
  //menuIds

  const orderFormSubmit = async () => {
    let orderFormData = {
      orderDate: orderDate.current.value,
      deliveryDate: deliveryDate.current.value,
      deliveryCity: deliveryCity.current.value,
      deliveryAddress: deliveryAddress.current.value,
      deliveryPostalCode: deliveryPostalCode.current.value,
      deliveryMenId: deliveryMenId,
      orderDeliveryDate: orderDeliveryDate.current.value,
      orderDeliveryStartHour: orderDeliveryStartHour.current.value,
      orderDeliveryEndHour: orderDeliveryEndHour.current.value,
      menuIds: menusIds,
    };
    console.log(orderFormData);
    await orderForm(orderFormData);
  };

  const orderForm = async (orderFormData) => {
    const apiResponse = await axios.post(
      "https://localhost:5001/api/order",
      orderFormData
    );
    console.log(apiResponse.data);
    navigate("/");
    if (language === "pl") {
      navigate("/homePL");
    } else {
      navigate("/");
    }
    // tu będzie navigate do tego zamówienia
  };

  return (
    <>
      <Container>
        <Form>
          <legend>Formularz zamówienia</legend>

          <Row className="mb-3">
            <Col>
              <Form.Group controlId="formOrderDate">
                <Form.Label>Data zamówienia</Form.Label>
                <Form.Control type="date" ref={orderDate} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group controlId="formDeliveryDate">
                <Form.Label>Oczekiwana data dostarczenia</Form.Label>
                <Form.Control type="date" ref={deliveryDate} />
              </Form.Group>
            </Col>
          </Row>

          <Row className="mb-3">
            <Col>
              <Form.Group className="mb-3" controlId="formDeliveryCity">
                <Form.Label>Miasto</Form.Label>
                <Form.Control type="text" ref={deliveryCity} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formDeliveryAddress">
                <Form.Label>Adres</Form.Label>
                <Form.Control type="text" ref={deliveryAddress} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formDeliveryPostalCoder">
                <Form.Label>Kod pocztowy</Form.Label>
                <Form.Control type="text" ref={deliveryPostalCode} />
              </Form.Group>
            </Col>
          </Row>
          <Row className="mb-3">
            <Col>
              <Form.Group className="mb-3" controlId="formOrderDeliveryDate">
                <Form.Label>Data dostarczenia zamówienia</Form.Label>
                <Form.Control type="date" ref={orderDeliveryDate} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group
                className="mb-3"
                controlId="formOrderDeliveryStartHour"
              >
                <Form.Label>Godzina od</Form.Label>
                <Form.Control type="number" ref={orderDeliveryStartHour} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formOrderDeliveryEndHour">
                <Form.Label>Godzina do</Form.Label>
                <Form.Control type="number" ref={orderDeliveryEndHour} />
              </Form.Group>
            </Col>
          </Row>
          <Row className="mb-3">
            <Col>
              <Form.Check
                inline
                label="globKurier"
                name="checkbox"
                type="radio"
                value="1"
                onChange={(e) => setDeliveryMenId(e.target.value)}
              />
            </Col>
            <Col>
              <Form.Check
                inline
                label="Inpost"
                name="checkbox"
                type="radio"
                value="2"
                onChange={(e) => setDeliveryMenId(e.target.value)}
              />
            </Col>
            <Col>
              <Form.Check
                inline
                label="DPD"
                name="checkbox"
                type="radio"
                value="3"
                onChange={(e) => setDeliveryMenId(e.target.value)}
              />
            </Col>

            <Button variant="primary" type="button" onClick={orderFormSubmit}>
              Złóż zamówienie
            </Button>
          </Row>
        </Form>
      </Container>
    </>
  );
};

export default OrderFormPL;
