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
import { selectEvents } from "../../features/events/eventSlice";

const CreateEventView = ({ onSubmit }) => {
  const categoryResponse = useSelector(selectCategories);
  const eventResponse = useSelector(selectEvents);
  const categories = categoryResponse?.data || [];

  const { control, handleSubmit, reset } = useForm({
    defaultValues: {
      title: "",
      shortContent: "",
      imageUrl: "",
      capacity: 0,
      content: "",
      place: "",
      tags: "",
      categoryId: null,
      startDate: dayjs(),
      endDate: dayjs(),
    },
  });

  return (
    <React.Fragment>
      <CssBaseline />
      <Container maxWidth="lg">
        <form onSubmit={handleSubmit(onSubmit)}>
          <Grid container spacing={2} marginTop={5}>
            <Grid item xs={12} sm={12}>
              <Controller
                name="title"
                control={control}
                render={({ field }) => (
                  <TextField label="Title" fullWidth {...field} />
                )}
                rules={{ required: "Title required" }}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name="shortContent"
                control={control}
                render={({ field }) => (
                  <TextField label="Short Content" fullWidth {...field} />
                )}
                rules={{ required: "Short Content required" }}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name="content"
                control={control}
                render={({ field }) => (
                  <TextField label="Content" fullWidth {...field} />
                )}
                rules={{ required: "Content required" }}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name="place"
                control={control}
                render={({ field }) => (
                  <TextField label="Place" fullWidth {...field} />
                )}
                rules={{ required: "Place required" }}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name="imageUrl"
                control={control}
                render={({ field }) => (
                  <TextField label="Image" fullWidth {...field} />
                )}
                rules={{ required: "Image required" }}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name="capacity"
                control={control}
                render={({ field }) => (
                  <TextField
                    type={"number"}
                    label="Capacity"
                    fullWidth
                    {...field}
                  />
                )}
                rules={{ required: "Place required" }}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <Controller
                name="tags"
                control={control}
                render={({ field }) => (
                  <TextField label="Tags" fullWidth {...field} />
                )}
                rules={{ required: "Tag required" }}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <Controller
                name="categoryId"
                control={control}
                render={({ field }) => (
                  <TextField select label="Category" fullWidth {...field}>
                    {categories?.map((category) => (
                      <MenuItem key={category.id} value={category.id}>
                        {category.name}
                      </MenuItem>
                    ))}
                  </TextField>
                )}
                rules={{ required: "Category required" }}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <Controller
                name="startDate"
                control={control}
                render={({ field }) => (
                  <LocalizationProvider dateAdapter={AdapterDayjs}>
                    <DateTimePicker
                      label="Start Date"
                      renderInput={(params) => <TextField {...params} />}
                      {...field}
                    />
                  </LocalizationProvider>
                )}
                rules={{ required: "Start Date required" }}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <Controller
                name="endDate"
                control={control}
                render={({ field }) => (
                  <LocalizationProvider dateAdapter={AdapterDayjs}>
                    <DateTimePicker
                      label="End Date"
                      renderInput={(params) => <TextField {...params} />}
                      {...field}
                    />
                  </LocalizationProvider>
                )}
                rules={{ required: "End Date required" }}
              />
            </Grid>
          </Grid>
          <Button fullWidth type="submit">
            Post
          </Button>
        </form>
      </Container>
    </React.Fragment>
  );
};
export default CreateEventView;
