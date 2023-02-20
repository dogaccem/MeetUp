import { createAsyncThunk } from "@reduxjs/toolkit";
import { axiosApiInstance } from "./axios.base.service";

export const UserService = {};

UserService.registerUser = createAsyncThunk(
  "userSlice/registerUser",
  async ({ firstName, lastName, username, password, email }) => {
    try {
      const response = await axiosApiInstance.post(
        `api/User`,
        { firstName, lastName, username, password, email },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);

UserService.getUser = createAsyncThunk("userSlice/getUser", async () => {
  try {
    const response = await axiosApiInstance.get(`api/User`, {
      headers: {
        "Content-Type": "application/json",
      },
    });
    console.log("burada var mı bişi?", response.data);
    return response.data;
  } catch (error) {
    console.error(error);
  }
});
