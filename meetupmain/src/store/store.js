import { configureStore } from "@reduxjs/toolkit";
import categoryReducer from "../features/category/categorySlice";
import userReducer from "../features/user/userSlice";
import eventReducer from "../features/events/eventSlice";
import tagReducer from "../features/tag/tagSlice";

export const store = configureStore({
  reducer: {
    categoryListSlice: categoryReducer,
    userSlice: userReducer,
    eventSlice: eventReducer,
    tagSlice: tagReducer,
  },
});
