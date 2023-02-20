import "./App.css";
import { createBrowserRouter, RouterProvider, Outlet } from "react-router-dom";
import Footer from "./components/Footer";
import Events from "./pages/events/Events";
import Home from "./pages/Home";
import EventDetail from "./pages/eventDetail/EventDetail";
import Login from "./pages/Login";
import Register from "./pages/register/Register";
import Profile from "./pages/profile/Profile";
import CreateEvent from "./pages/create/CreateEvent";
import "./App.css";
import Navbar from "./components/Navbar";
import UpdateEvent from "./pages/update/UpdateEvent";

const Layout = () => {
  return (
    <div className="link">
      <Navbar />
      <Outlet />
      <Footer />
    </div>
  );
};

const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout />,
    children: [
      {
        path: "event/:id",
        element: <EventDetail />,
      },
      {
        path: "update/:id",
        element: <UpdateEvent />,
      },
      {
        path: "login",
        element: <Login />,
      },
      {
        path: "register",
        element: <Register />,
      },
      {
        path: "/",
        element: <Home />,
      },
      {
        path: "profile",
        element: <Profile />,
      },
      {
        path: "create",
        element: <CreateEvent />,
      },
      {
        path: "events",
        element: <Events />,
      },
    ],
  },
]);

function App() {
  return (
    <div className="App">
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
