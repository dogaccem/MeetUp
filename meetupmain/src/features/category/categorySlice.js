import { createSlice } from "@reduxjs/toolkit";
import { CategoryService } from "../../services/category.service";

const initialState = {
  category: [],
  isLoading: false,
  hasError: false,
};

const categorySlice = createSlice({
  name: "categoryListSlice",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(CategoryService.getCategories.pending, (state, action) => {
        state.isLoading = true;
        state.hasError = false;
      })
      .addCase(CategoryService.getCategories.fulfilled, (state, action) => {
        state.category = action.payload;
        console.log(
          "🚀 ~ file: categorySlice.js:22 ~ .addCase ~ action.payload",
          action.payload
        );
        state.isLoading = false;
        state.hasError = false;
      })
      .addCase(CategoryService.getCategories.rejected, (state, action) => {
        state.hasError = true;
        state.isLoading = false;
      });
  },
});

export const selectCategories = (state) => state.categoryListSlice.category;
export const selectLoadingState = (state) => state.categoryListSlice.isLoading;
export const selectErrorState = (state) => state.categoryListSlice.hasError;
export default categorySlice.reducer;
