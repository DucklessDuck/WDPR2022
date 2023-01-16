import { Home } from "./components/Home";
import { Bestellen } from "./components/Bestellen";
import { Agenda } from "./components/Agenda";
import { Betaling } from "./components/Betaling";

import { Login } from "./components/Account/Login";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/login',
    element: <Login />
  },
  {
    path: '/bestellen',
    element: <Bestellen />
  },
  {
    path: '/Agenda',
    element: <Agenda />
  },
  {
    path: '/bestellen/betaling',
    element: <Betaling />
  }
];

export default AppRoutes;
