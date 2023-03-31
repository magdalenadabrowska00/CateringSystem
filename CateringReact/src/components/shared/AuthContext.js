import { createContext, useState } from "react";
import axios from "axios";
import jwt_decode from "jwt-decode";
import { useNavigate } from "react-router-dom";

const AuthContext = createContext();

export const AuthContextProvider = ({ children }) => {
  const [user, setUser] = useState(() => {
    if (localStorage.getItem("token")) {
      let tokenData = JSON.parse(localStorage.getItem("token"));
      let accessToken = jwt_decode(tokenData.token);
      return accessToken;
    }
    return null;
  });
  const navigate = useNavigate();

  const login = async (userLoginData) => {
    //, language
    const apiResponse = await axios.post(
      "https://localhost:5001/api/account/login",
      userLoginData
    );
    let accessToken = jwt_decode(apiResponse.data);
    // console.log(accessToken);
    // console.log(language);

    setUser(accessToken);
    localStorage.setItem("token", JSON.stringify(apiResponse.data));
    // localStorage.setItem("lang", JSON.stringify(language));
    navigate("/");
  };

  const logout = () => {
    localStorage.removeItem("token");
    // localStorage.removeItem("lang");
    setUser(null);
    navigate("/");
  };
  return (
    <AuthContext.Provider value={{ login, user, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
