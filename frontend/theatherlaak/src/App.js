import React, { useEffect, useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';

import Contact from "./pages/Contact";
import Home from "./pages/Home";
import LoginForm from "./pages/Account/Login";
import NoPage from "./pages/NoPage";
import Layout from "./components/Layout";
import Zalen from "./pages/Zalen";
import Voorstelling from "./pages/Voorstellingen";
import {Agenda} from "./pages/Agenda";

import {Bestellen} from "./pages/Bestellen";
import {Betaling} from "./pages/Betaling";


function App() {
  // const [voorstellingen, setVoorstelling] = useState([]);

  // useEffect(() => {
  //   (async () => {
  //     let voorstellingData;
  //     try {
  //       const response = await fetch("https://randomuser.me/api?results=10");
  //       const voorstellingData = (await response.json()).results;
  //     }
  //     catch (error) {
  //       console.log(error);
  //       voorstellingData = [];
  //     };

  //     setVoorstelling(voorstellingData);
  //   })();
  // });

  return (
    <BrowserRouter>
      {/* {voorstellingen.map((voorstellingen, index) => (
        <Agenda voorstellingData={Voorstelling} key="index"></Agenda>
      ))}; */}

      
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="login" element={<LoginForm />} />
          <Route path="contact" element={<Contact />} />
          <Route path="zalen" element={<Zalen />} />
          <Route path="betaling" element={<Betaling />} />
          <Route path="bestellen" element={<Bestellen />} />
          <Route path="voorstellingen" element={<Voorstelling />} />
          <Route path="agenda" element={<Agenda />} />
          <Route path="*" element={<NoPage />} />


          <Route path="/" element={<Bestellen />} />
        </Route>
      </Routes>

    </BrowserRouter>
  );
}
export default App;