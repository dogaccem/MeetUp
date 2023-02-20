import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { axiosApiInstance } from "./axios.base.service";
import { TokenService } from "./token.service";

export const AuthService = {};
AuthService.userLogin = createAsyncThunk(
  "userSlice/userLogin",
  async ({ username, password }, { rejectWithValue }) => {
    try {
      const response = await axiosApiInstance.post(
        "api/Login",
        { username, password },
        {
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            username: typeof username === "string" ? username.toString() : "",
            password: typeof password === "string" ? password.toString() : "",
          }),
        }
      );

      const tokenResponse = { accessToken: response?.data?.data?.token };
      TokenService.setToken(tokenResponse);
      return tokenResponse;
    } catch (error) {
      return rejectWithValue(error);
    }
  }
);

AuthService.isAuthenticated = () => {
  return localStorage.getItem("access_token") ? true : false;
};
AuthService.logout = () => {
  TokenService.clearToken();
};
