import { createContext } from "react";
import { useNavigate } from "react-router-dom";

const LanguageContext = createContext();

export const LanguageContextProvider = ({ children }) => {
  const navigate = useNavigate();

  const setLang = async (language) => {
    localStorage.setItem("lang", JSON.stringify(language));

    if (language === "pl") {
      navigate("/homePL");
    } else {
      navigate("/");
    }
  };

  return (
    <LanguageContext.Provider value={{ setLang }}>
      {children}
    </LanguageContext.Provider>
  );
};

export default LanguageContext;
