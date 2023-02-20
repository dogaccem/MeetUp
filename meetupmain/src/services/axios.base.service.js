import axios from "axios";

const token = localStorage.getItem("access_token");
console.log("🚀 ~ file: axios.base.service.js:4 ~ token", token);
const baseUrld = localStorage.getItem("url");
console.log("base", baseUrld);
export const axiosApiInstance = axios.create({
  baseURL: baseUrld,
  headers: {
    "Content-Type": "application/json",
  },
});

axiosApiInstance.interceptors.request.use(
  async (config) => {
    config.headers = {
      Authorization: `Bearer ${token}`,
    };
    console.log("token burada gözükecek:", token);
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);

axiosApiInstance.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response?.status === 401 || error.response?.status === 403) {
      localStorage.removeItem("access_token");
      window.location.href = "/login";
    }
    return error;
  }
);
