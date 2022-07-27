import './App.css';
import { useEffect } from 'react';
import { createEndpoint, ENDPOINTS } from "./api";
import Restaurant from './Components/Restaurant/index.js';
import Home from './Home';
import About from './About';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Link } from "react-router-dom";
import NavBar from './NavBar';

function App() {

  return (  
  <div className="App">
    <NavBar />
    <Routes>
      <Route exact path="/" element={<Home />} />
      <Route exact path="/about" element={<About />} />
      <Route exact path="/restaurants" element={<Restaurant />} />
    </Routes>
  </div>
    
  );
}

export default App;
