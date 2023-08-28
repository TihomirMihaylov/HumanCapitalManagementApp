import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import  EmployeeList from "./components/EmployeeList";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/employees',
    requireAuth: false,
    element: <EmployeeList />
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
