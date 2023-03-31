import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import { AuthContextProvider } from "./components/shared/AuthContext";
import { AddMenusContextProvider } from "./components/shared/AddMenusContext";
import { LanguageContextProvider } from "./components/shared/LanguageContext";
import Layout from "./components/shared/Layout";

import HomeEN from "./pages/English/HomeEN";
import LoginEN from "./pages/English/LoginEN";
import RegisterEN from "./pages/English/RegisterEN";
import OrderFormEN from "./pages/English/OrderFormEN";
import CardEN from "./pages/English/CardEN";
import GetAllRestaurantsEN from "./pages/English/GetAllRestaurantsEN";
import GetRestaurantByIdEN from "./pages/English/GetRestaurantByIdEN";
import GetMenusForRestaurantEN from "./pages/English/GetMenusForRestaurantEN";
import GetMenuDetailsByIdForRestaurant from "./pages/English/GetMenuDetailsByIdForRestaurant";

import HomePL from "./pages/Polish/HomePL";
import LoginPL from "./pages/Polish/LoginPL";
import RegisterPL from "./pages/Polish/RegisterPL";
import OrderFormPL from "./pages/Polish/OrderFormPL";
import CardPL from "./pages/Polish/CardPL";

function App() {
  return (
    <>
      <LanguageContextProvider>
        <AuthContextProvider>
          <AddMenusContextProvider>
            <Layout>
              <Routes>
                <Route path="/" element={<HomeEN />}></Route>
                <Route path="/homePL" element={<HomePL />}></Route>

                <Route path="/loginPL" element={<LoginPL />}></Route>
                <Route path="/loginEN" element={<LoginEN />}></Route>

                <Route path="/registrationPL" element={<RegisterPL />}></Route>
                <Route path="/registrationEN" element={<RegisterEN />}></Route>

                <Route path="/orderFormPL" element={<OrderFormPL />}></Route>
                <Route path="/orderFormEN" element={<OrderFormEN />}></Route>

                <Route path="/cardEn" element={<CardEN />}></Route>
                <Route path="/cardPL" element={<CardPL />}></Route>

                <Route
                  path="/restaurantsEN"
                  element={<GetAllRestaurantsEN />}
                />

                <Route
                  path="/restaurantsEN/:restaurantId"
                  element={<GetRestaurantByIdEN />}
                />

                <Route
                  path="/restaurantsEN/:restaurantId/menus"
                  element={<GetMenusForRestaurantEN />}
                />

                <Route
                  path="/restaurantsEN/:restaurantId/menus/:menuId/meals"
                  element={<GetMenuDetailsByIdForRestaurant />}
                />
              </Routes>
            </Layout>
          </AddMenusContextProvider>
        </AuthContextProvider>
      </LanguageContextProvider>
    </>
  );
}

export default App;
