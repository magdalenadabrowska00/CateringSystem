import Card from "react-bootstrap/Card";
import { Form } from "react-bootstrap";
import { useState, useContext } from "react";
import LanguageContext from "../../components/shared/LanguageContext";
import Button from "react-bootstrap/Button";

const HomePL = () => {
  const [language, setLanguage] = useState("");
  const { setLang } = useContext(LanguageContext);

  const languageSubmit = async () => {
    await setLang(language);
  };

  return (
    <>
      <div
        className="d-flex justify-content-center align-items-center"
        style={{ minHeight: "500px", minWidth: "500px" }}
      >
        <Card>
          <Card.Body>
            <Card.Title>Witaj na stronie głównej</Card.Title>

            <Form.Check
              inline
              label="Polski"
              name="checkbox"
              type="radio"
              value="pl"
              onChange={(e) => setLanguage(e.target.value)}
            />
            <Form.Check
              inline
              label="English"
              name="checkbox"
              type="radio"
              value="en"
              onChange={(e) => setLanguage(e.target.value)}
            />

            <Button variant="primary" type="button" onClick={languageSubmit}>
              Ustaw język
            </Button>
          </Card.Body>
        </Card>
      </div>
    </>
  );
};
export default HomePL;
