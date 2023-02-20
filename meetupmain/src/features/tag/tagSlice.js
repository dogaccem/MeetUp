import { createSlice } from "@reduxjs/toolkit";
import { TagService } from "../../services/tag.service";

const initialState = {
  tags: {},
};

const tagSlice = createSlice({
  name: "tagSlice",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(TagService.getTags.fulfilled, (state, action) => {
      state.tags = action.payload;
    });
  },
});

export const selectTags = (state) => state.tagSlice.tags;
export default tagSlice.reducer;
