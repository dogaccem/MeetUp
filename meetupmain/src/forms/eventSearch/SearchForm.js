import { LocalizationProvider, DateTimePicker } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { MenuItem, Grid, TextField, Typography } from "@mui/material";
import { Controller, useForm } from "react-hook-form";
import dayjs from "dayjs";
import { useSelector } from "react-redux";
import { selectCategories } from "../../features/category/categorySlice";
import { selectTags } from "../../features/tag/tagSlice";

function SearchForm({ onSubmit }) {
  const categories = useSelector(selectCategories);
  const tags = useSelector(selectTags);
  console.log("🚀 ~ file: SearchForm.js:13 ~ SearchForm ~ tags", tags);
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm();
  return (
    <form id="event-form" onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={12}>
          <Controller
            name="title"
            defaultValue={""}
            control={control}
            render={({ field }) => (
              <TextField
                error={!!errors.title}
                required
                label="Title"
                {...field}
                fullWidth
              />
            )}
            rules={{
              required: "Title is required.",
              minLength: {
                value: 3,
                message: "This input must exceed 3 characters",
              },
              pattern: {
                value: /^\p{L}+$/u,
                message: "This input is letter only.",
              },
            }}
          />
          {errors.title && (
            <Typography marginTop={1} color="red" role="alert">
              {errors.title?.message}
            </Typography>
          )}
        </Grid>
        <Grid item xs={12} sm={12}>
          <Controller
            name="place"
            defaultValue={""}
            control={control}
            render={({ field }) => (
              <TextField
                error={!!errors.lastName}
                required
                label="Place"
                {...field}
                fullWidth
              />
            )}
            rules={{
              required: "Place is required.",
              minLength: {
                value: 3,
                message: "This input must exceed 3 characters",
              },
              pattern: {
                value: /^\p{L}+$/u,
                message: "This input is letter only.",
              },
            }}
          />
          {errors.place && (
            <Typography marginTop={1} color="red" role="alert">
              {errors.place?.message}
            </Typography>
          )}
        </Grid>
        <Grid item xs={12} sm={12}>
          <Controller
            name="tag"
            control={control}
            defaultValue={""}
            render={({ field }) => (
              <TextField select label="Tag" fullWidth {...field}>
                {tags?.data?.map((tag) => (
                  <MenuItem key={tag.name} value={tag.name}>
                    {tag.name}
                  </MenuItem>
                ))}
              </TextField>
            )}
            rules={{ required: "Tag required" }}
          />
        </Grid>
        <Grid item xs={12} sm={12}>
          <Controller
            name="category"
            control={control}
            defaultValue={""}
            render={({ field }) => (
              <TextField select label="Category" fullWidth {...field}>
                {categories?.data?.map((category) => (
                  <MenuItem key={category.name} value={category.name}>
                    {category.name}
                  </MenuItem>
                ))}
              </TextField>
            )}
            rules={{ required: "Category required" }}
          />
        </Grid>
        <Grid item xs={12} sm={12}>
          <Controller
            name="startDate"
            control={control}
            defaultValue={dayjs()}
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
        <Grid item xs={12} sm={12}>
          <Controller
            name="endDate"
            control={control}
            defaultValue={dayjs()}
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
    </form>
  );
}

export default SearchForm;
