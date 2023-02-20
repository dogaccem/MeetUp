import { createAsyncThunk } from "@reduxjs/toolkit";
import { axiosApiInstance } from "./axios.base.service";

export const TagService = {};

TagService.getTags = createAsyncThunk("tagSlice/getTags", async () => {
  try {
    const response = await axiosApiInstance.get("/api/Tag/tags");
    return response.data;
  } catch (error) {
    console.error(error);
  }
});
