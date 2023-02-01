import { Outlet, Link } from "react-router-dom";
import React from "react";


//... Navbar ...//
const LayoutUser = () => {
  return (
    <>
      <nav class="navbar">
        <ul class="navbar-itemList">
          <li class="navbar-items" id="home-button">
            <Link to="/">Theather Laak</Link>
          </li>
          <li class="navbar-items">
            <Link to="/voorstellingen">Voorstellingen</Link>
          </li>
          {/* <li classname="navbar-items">
            <Link to="/bestellen">Bestellen</Link>
          </li>
          <li classname="navbar-items">
            <Link to="/betaling">Betaling</Link>
          </li> */}
          <li class="navbar-items">
            <Link to="/over-ons">Over ons</Link>
          </li>
          <li class="navbar-items">
            <Link to="/contact">Contact</Link>
          </li>
          <li class="navbar-items" id="navbar-right">
            <Link to="/logout">Log uit</Link>
          </li>
        </ul>
      </nav>

      <Outlet />
    </>
  )
};

export default LayoutUser;