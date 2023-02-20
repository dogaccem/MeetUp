import { createAsyncThunk } from "@reduxjs/toolkit";
import { axiosApiInstance } from "./axios.base.service";

export const CategoryService = {};

CategoryService.getCategories = createAsyncThunk(
  "CategorySlice/getCategories",
  async () => {
    try {
      const response = await axiosApiInstance.get("/api/Category/all");
      console.log("🚀 ~ file: category.service.js:11 ~ response", response);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  }
);
