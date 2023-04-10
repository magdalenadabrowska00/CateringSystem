import Navbar from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import { Link } from "react-router-dom";
import { useContext, useEffect, useState } from "react";
import AuthContext from "./AuthContext";
import { Button } from "react-bootstrap";

const Layout = ({ children }) => {
  const { user, logout } = useContext(AuthContext);
  console.log(user);

  let language = JSON.parse(localStorage.getItem("lang"));

  const [hideRole, setHideRole] = useState(false);
  const [polishLanguage, setPolishLanguage] = useState(false);

  useEffect(() => {
    if (
      user &&
      user["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] ===
        "User"
    ) {
      setHideRole(true);
    } else {
      setHideRole(false);
    }
  });
  console.log(hideRole);

  useEffect(() => {
    if (language === "pl") {
      setPolishLanguage(true);
    } else {
      setPolishLanguage(false);
    }
  });

  return (
    <>
      <Navbar bg="primary" variant="dark">
        <Navbar.Brand>
          <Nav.Link as={Link} to="/">
            Catering system
          </Nav.Link>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="ms-auto">
            {!user && polishLanguage && (
              <Nav.Link as={Link} to="/registrationPL">
                Rejestracja
              </Nav.Link>
            )}
            {!user && polishLanguage && (
              <Nav.Link as={Link} to="/loginPL">
                Logowanie
              </Nav.Link>
            )}

            {user && polishLanguage && (
              <Nav.Link as={Link} to="/orderFormPL">
                Formularz zamówienia
              </Nav.Link>
            )}

            {user && polishLanguage && (
              <Nav.Link as={Link} to="/cardPL">
                Koszyk
              </Nav.Link>
            )}

            {!user && !polishLanguage && (
              <Nav.Link as={Link} to="/registrationEN">
                Register
              </Nav.Link>
            )}
            {!user && !polishLanguage && (
              <Nav.Link as={Link} to="/loginEN">
                Login
              </Nav.Link>
            )}

            {user && !polishLanguage && (
              <Nav.Link as={Link} to="/orderFormEN">
                Order form
              </Nav.Link>
            )}
            {/* allRestaurants */}
            {user && !polishLanguage && (
              <Nav.Link as={Link} to="/restaurantsEN">
                Restaurants
              </Nav.Link>
            )}

            {user && !polishLanguage && (
              <Nav.Link as={Link} to="/cardEN">
                Card
              </Nav.Link>
            )}

            {user && (
              <Nav.Link href="#">
                {
                  user[
                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
                  ]
                }
              </Nav.Link>
            )}
          </Nav>
          {user && (
            <Button
              variant="primary"
              type="button"
              onClick={() => {
                logout();
              }}
            >
              Logout
            </Button>
          )}
        </Navbar.Collapse>
      </Navbar>
      <Container>{children}</Container>
    </>
  );
};
export default Layout;
