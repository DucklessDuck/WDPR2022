import { Outlet, Link } from "react-router-dom";
import '../App.css';
import React from "react";


//... Navbar ...//
const Layout = () => {
  return (
    <>
      <nav classname="navbar">
        <ul classname="navbar-itemList">
          <li id="home-button">
            <Link to="/">Theather Laak</Link>
          </li>
          <li classname="navbar-items">
            <Link to="/voorstellingen">Voorstellingen</Link>
          </li>
          {/* <li classname="navbar-items">
            <Link to="/bestellen">Bestellen</Link>
          </li>
          <li classname="navbar-items">
            <Link to="/betaling">Betaling</Link>
          </li> */}
          <li classname="navbar-items">
            <Link to="/over-ons">Over ons</Link>
          </li>
          <li classname="navbar-items">
            <Link to="/contact">Contact</Link>
          </li>
          <li classname="navbar-items" id="navbar-right">
            <Link to="/login">Login</Link>
          </li>
        </ul>
      </nav>

      <Outlet />
    </>
  )
};

export default Layout;