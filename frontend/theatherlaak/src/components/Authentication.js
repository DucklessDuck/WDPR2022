import React from "react";

const Authentication = React.createContext({
  isLoggedIn: false,
  updateIsLoggedIn: () => {},
});

export default Authentication;
