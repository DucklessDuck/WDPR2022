import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';

import Contact from "./Pages/Contact";
import Home from "./Pages/Home";
import LoginForm from "./Pages/Account/Login";
import NoPage from "./Pages/NoPage";
import Layout from "./components/Layout";
import Zalen from "./Pages/Zalen";
import { Bestellen } from "./Pages/Bestellen";
import {Betaling} from "./Pages/Betaling";


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
          <Route path="*" element={<NoPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
export default App;