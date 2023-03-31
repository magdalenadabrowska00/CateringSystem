import { Container, Row, Col } from "react-bootstrap";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { useRef, useState } from "react";

const RegisterEN = () => {
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
    navigate("/login");
  };

  return (
    <>
      <Container className="mt-2">
        <Form>
          <legend>Registration form</legend>
          <Row>
            <Col>
              <Form.Group className="mb-3" controlId="formFirstName" inline>
                <Form.Label>First name</Form.Label>
                <Form.Control type="text" ref={firstName} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formLastName">
                <Form.Label>Last name</Form.Label>
                <Form.Control type="text" ref={lastName} />
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Group className="mb-3" controlId="formDateOfBirth">
                <Form.Label>Date of birth</Form.Label>
                <Form.Control type="date" ref={dateOfBirth} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formPhoneNumber">
                <Form.Label>Phone number</Form.Label>
                <Form.Control type="text" ref={phoneNumber} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formCountry">
                <Form.Label>Country</Form.Label>
                <Form.Control type="text" ref={country} />
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Group className="mb-3" controlId="formCity">
                <Form.Label>City</Form.Label>
                <Form.Control type="text" ref={city} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formStreet">
                <Form.Label>Street</Form.Label>
                <Form.Control type="text" ref={street} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formPostalCode">
                <Form.Label>Postal code</Form.Label>
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
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" ref={password} />
              </Form.Group>
            </Col>
            <Col>
              <Form.Group className="mb-3" controlId="formConfirmPassword">
                <Form.Label>Confirm password</Form.Label>
                <Form.Control type="password" ref={confirmPassword} />
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Check
                inline
                label="Client"
                name="checkbox"
                type="radio"
                value="1"
                onChange={(e) => setRoleId(e.target.value)}
              />
            </Col>
            <Col>
              <Form.Check
                inline
                label="Restaurant manager"
                name="checkbox"
                type="radio"
                value="2"
                onChange={(e) => setRoleId(e.target.value)}
              />
            </Col>
            <Col>
              <Form.Check
                inline
                label="Restaurant worker"
                name="checkbox"
                type="radio"
                value="3"
                onChange={(e) => setRoleId(e.target.value)}
              />
            </Col>
            <Col>
              <Form.Check
                inline
                label="Admin"
                name="checkbox"
                type="radio"
                value="4"
                onChange={(e) => setRoleId(e.target.value)}
              />
            </Col>

            <Button variant="primary" type="button" onClick={registerSubmit}>
              Register
            </Button>
          </Row>
        </Form>
      </Container>
    </>
  );
};

export default RegisterEN;
