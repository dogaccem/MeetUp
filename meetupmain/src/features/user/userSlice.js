import { createSlice } from "@reduxjs/toolkit";
import { AuthService } from "../../services/auth.service";
import { UserService } from "../../services/user.service";

const userToken = localStorage.getItem("access_token")
  ? localStorage.getItem("access_token")
  : null;

const initialState = {
  userToken,
  user: null,
  isLoading: false,
  hasError: false,
  canLogin: false,
};

const userSlice = createSlice({
  name: "userSlice",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(AuthService.userLogin.pending, (state, action) => {
        state.isLoading = true;
        state.hasError = false;
      })
      .addCase(AuthService.userLogin.fulfilled, (state, action) => {
        state.userToken = action.payload.accessToken;
        state.isLoading = false;
        state.hasError = false;
        if (action.payload.accessToken === undefined) {
          state.canLogin = false;
        } else {
          state.canLogin = true;
        }
      })
      .addCase(AuthService.userLogin.rejected, (state, action) => {
        state.isLoading = false;
        state.hasError = true;
      })
      .addCase(UserService.getUser.pending, (state, action) => {
        state.isLoading = true;
        state.hasError = false;
      })
      .addCase(UserService.getUser.fulfilled, (state, action) => {
        state.user = action.payload;
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(UserService.getUser.rejected, (state, action) => {
        state.isLoading = false;
        state.hasError = true;
      });
  },
});
export const selectUserToken = (state) => state.userSlice.userToken;
export const selectUser = (state) => state.userSlice.user;
export const selectLoadingState = (state) => state.userSlice.isLoading;
export const selectErrorState = (state) => state.userSlice.hasError;
export const selectCanLoginState = (state) => state.userSlice.canLogin;
export default userSlice.reducer;
