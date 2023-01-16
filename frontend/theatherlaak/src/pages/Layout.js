import { Outlet, Link } from "react-router-dom";

import React from "react";

const Layout = () => {
    // navbar in princiepe
  return (
    <>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/login">Login</Link>
          </li>
          <li>
            <Link to="/contact">Contact</Link>
          </li>
          <li>
            <Link to="/bestellen">bestellen</Link>
          </li>
          <li>
            <Link to="/betaling">betaling</Link>
          </li>
        </ul>
      </nav>

      <Outlet />
    </>
  )
};

export default Layout;