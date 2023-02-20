import jwt_decode from "jwt-decode";

export const TokenService = {};

TokenService.DecodeAccessToken = (accessToken) => {
  return jwt_decode(accessToken);
};

TokenService.setToken = ({ accessToken }) => {
  const decoded = TokenService.DecodeAccessToken(accessToken);
  localStorage.setItem("username", decoded.unique_name);
  localStorage.setItem("userId", decoded.nameid);
  localStorage.setItem("access_token", accessToken);
};

TokenService.clearToken = () => {
  localStorage.removeItem("username");
  localStorage.removeItem("access_token");
};
