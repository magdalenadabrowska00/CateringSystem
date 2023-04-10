import { Container, Row, Col } from "react-bootstrap";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { useRef, useState } from "react";

const RegisterPL = () => {
  const navigate = useNavigate();

  const [roleId, setRoleId] = useState();
  console.log(roleId);

  const firstName = useRef("");
  const lastName = useRef("");
  const email = useRef("");
  const password = useRef("");
  const confirmPassword = useRef("");
  const country = useRef("");
  const city = useRef("");
  const street = useRef("");
  const postalCode = useRef("");
  const dateOfBirth = useRef("");
  const phoneNumber = useRef("");

  const registerSubmit = async () => {
    let userRegisterData = {
      lastName: lastName.current.value,
      firstName: firstName.current.value,
      dateOfBirth: dateOfBirth.current.value,
      email: email.current.value,
      phoneNumber: phoneNumber.current.value,
      password: password.current.value,
      confirmPassword: confirmPassword.current.value,
      roleId: roleId,
      city: city.current.value,
      street: street.current.value,
      postalCode: postalCode.current.value,
      country: country.current.value,
    };
    await register(userRegisterData);
  };

  const register = async (userRegisterData) => {
    const apiResponse = await axios.post(
      "https://localhost:5001/api/account/register",
      userRegisterData
    );
    console.log(apiResponse.data);
    navigate("/loginPL");
  };

  return (
    <>
      <Container className="mt-2">
        <Form>
          <legend>Rejestracja</legend>
          <Row>
            <Col>
              <Form.Group className="mb-3" controlId="formFirstName" inline>
                <Form.Label>Imię</Form.Label>
                <Form.Control type="text" ref={firstName} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formLastName">
                <Form.Label>Nazwisko</Form.Label>
                <Form.Control type="text" ref={lastName} />
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Group className="mb-3" controlId="formDateOfBirth">
                <Form.Label>Data urodzenia</Form.Label>
                <Form.Control type="date" ref={dateOfBirth} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formPhoneNumber">
                <Form.Label>Numer telefonu</Form.Label>
                <Form.Control type="text" ref={phoneNumber} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formCountry">
                <Form.Label>Kraj</Form.Label>
                <Form.Control type="text" ref={country} />
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Group className="mb-3" controlId="formCity">
                <Form.Label>Miasto</Form.Label>
                <Form.Control type="text" ref={city} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formStreet">
                <Form.Label>Ulica</Form.Label>
                <Form.Control type="text" ref={street} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formPostalCode">
                <Form.Label>Kod pocztowy</Form.Label>
                <Form.Control type="text" ref={postalCode} />
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Group className="mb-3" controlId="formEmail">
                <Form.Label>Email</Form.Label>
                <Form.Control type="text" ref={email} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formPassword">
                <Form.Label>Hasło</Form.Label>
                <Form.Control type="password" ref={password} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formConfirmPassword">
                <Form.Label>Potwierdź hasło</Form.Label>
                <Form.Control type="password" ref={confirmPassword} />
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Check
                inline
                label="Klient"
                name="checkbox"
                type="radio"
                value="1"
                onChange={(e) => setRoleId(e.target.value)}
              />
            </Col>
            <Col>
              <Form.Check
                inline
                label="Menedżer  restauracji"
                name="checkbox"
                type="radio"
                value="2"
                onChange={(e) => setRoleId(e.target.value)}
              />
            </Col>
            <Col>
              <Form.Check
                inline
                label="Pracownik restauracji"
                name="checkbox"
                type="radio"
                value="3"
                onChange={(e) => setRoleId(e.target.value)}
              />
            </Col>
            <Col>
              <Form.Check
                inline
                label="Administrator"
                name="checkbox"
                type="radio"
                value="4"
                onChange={(e) => setRoleId(e.target.value)}
              />
            </Col>

            <Button variant="primary" type="button" onClick={registerSubmit}>
              Zarejestruj się
            </Button>
          </Row>
        </Form>
      </Container>
    </>
  );
};

export default RegisterPL;
