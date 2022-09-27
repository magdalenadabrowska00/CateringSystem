import './App.css';
import { useEffect } from 'react';
import { createEndpoint, ENDPOINTS } from "./api";
import Restaurant from './Components/Restaurant/index.js';
import RestaurantMenu from './Components/RestaurantMenu/index.js';
import Home from './Home';
import About from './About';
import {  Routes, Route } from 'react-router-dom'; //BrowserRouter as Router,
import { Link, Redirect, Switch, Router, NavLink  } from "react-router-dom";
import NavBar from './NavBar';
import Login from './Components/LoginRegistrationForms/Login';

function App() {

  return (  
  <div className="App">

    <Navigation />
    <Routes>
      <Route index element={<Home />} />
      <Route path="home" element={<Home />} />
      <Route path="about" element={<About />} />
      <Route path="restaurant" element={<Restaurant />} />
      <Route path="login" element={<Login />} />
      <Route path="menuforrestaurant" element={<RestaurantMenu />} />
    </Routes>

  </div>
    
  );
}

export default App;
//<NavBar />
/*
<Routes>
      <Route exact path="/" element={<Home />} />
      <Route exact path="/about" element={<About />} />
      <Route exact path="/restaurants" element={<Restaurant />} />
      <Route exact path="/login" element={<Login />} />
    </Routes>
*/


//Navigation dodaje nagłówki z podlinkowaniem
//a Routes'y dodają podlinkowanie konkretne
const Navigation = () => {
  return (
    <nav>
      <NavLink to="/home">Home </NavLink>
      <NavLink to="/about">About </NavLink>
      <NavLink to="/restaurant">Restaurants </NavLink>
      <NavLink to="/login">Login </NavLink>
      <NavLink to="/menuforrestaurant">Menus </NavLink>
    </nav>
  );
};

    

    