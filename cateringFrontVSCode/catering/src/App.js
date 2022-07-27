import logo from './logo.svg';
import './App.css';
import { useEffect } from 'react';
import { createEndpoint, ENDPOINTS } from "./api";
import Restaurant from './Components/Restaurant/index.js';

function App() {

  return (  
  <div>
    <Restaurant />
  </div>
    

    
  );
}

export default App;
