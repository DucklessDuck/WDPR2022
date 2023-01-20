import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';

import Contact from "./pages/Contact";
import Home from "./pages/Home";
import LoginForm from "./pages/Account/Login";
import NoPage from "./pages/NoPage";
import Layout from "./components/Layout";
import Zalen from "./pages/Zalen";
import Voorstelling from "./pages/Voorstellingen";
import { Bestellen } from "./pages/Bestellen";
import {Betaling} from "./pages/Betaling";


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="login" element={<LoginForm />} />
          <Route path="contact" element={<Contact />} />
          <Route path="zalen" element={<Zalen />} />
          <Route path="betaling" element={<Betaling />} />
          <Route path="bestellen" element={<Bestellen />} />
          <Route path="voorstellingen" element={<Voorstelling />} />
          <Route path="*" element={<NoPage />} />


          <Route path="/" element={<Bestellen />} />          
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
export default App;