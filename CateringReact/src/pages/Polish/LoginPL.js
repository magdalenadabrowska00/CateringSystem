import { Container, Row, Col } from "react-bootstrap";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useContext, useRef, useState } from "react";
import AuthContext from "../../components/shared/AuthContext";

const LoginPL = () => {
  const email = useRef("");
  const password = useRef("");

  // const [language, setLanguage] = useState("");

  const { login } = useContext(AuthContext);

  const loginSubmit = async () => {
    let userLoginData = {
      email: email.current.value,
      password: password.current.value,
    };
    await login(userLoginData);
  };
  return (
    <>
      <Container className="mt-2">
        <Row>
          <Col className="col-md-4 offset-md-4">
            <legend>Logowanie</legend>
            <form>
              <Form.Group className="mb-3" controlId="formUserName">
                <Form.Label>Adres email</Form.Label>
                <Form.Control type="text" ref={email} />
              </Form.Group>
              <Form.Group className="mb-3" controlId="formPassword">
                <Form.Label>Hasło</Form.Label>
                <Form.Control type="password" ref={password} />
              </Form.Group>
              <Button variant="primary" type="button" onClick={loginSubmit}>
                Zaloguj
              </Button>
            </form>
          </Col>
        </Row>
      </Container>
    </>
  );
};

export default LoginPL;
