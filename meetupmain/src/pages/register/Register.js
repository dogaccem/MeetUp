import * as React from "react";
import { useNavigate } from "react-router-dom";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import RegisterView from "./RegisterView";
import { useDispatch } from "react-redux";
import { UserService } from "../../services/user.service";

const theme = createTheme();

export default function SignUp() {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const handleSubmit = (event) => {
    dispatch(UserService.registerUser(event)).then(() => {
      navigate("/login");
    });
  };

  return <RegisterView onSubmit={handleSubmit} />;
}
