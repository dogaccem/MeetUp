import { Grid, MenuItem, Container, CssBaseline, Button } from "@mui/material";
import React from "react";
import { useForm, Controller } from "react-hook-form";
import { TextField } from "@mui/material";
import { LocalizationProvider, DateTimePicker } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import dayjs from "dayjs";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";
import { CategoryService } from "../../services/category.service";
import { selectCategories } from "../../features/category/categorySlice";
import CreateEventView from "./CreateEventView";
import { EventService } from "../../services/event.service";

const CreateEvent = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(CategoryService.getCategories());
  }, [dispatch]);

  const onSubmit = (data) => {
    dispatch(EventService.createEvent(data));
  };

  return <CreateEventView onSubmit={onSubmit} />;
};
export default CreateEvent;
