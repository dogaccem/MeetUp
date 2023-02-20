import {
  Grid,
  TextField,
  Typography,
  Container,
  CssBaseline,
  Box,
  Button,
} from "@mui/material";
import { Controller, useForm } from "react-hook-form";

function RegisterView({ onSubmit }) {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm();
  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <Box
        sx={{
          marginTop: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <form id="register-form" onSubmit={handleSubmit(onSubmit)}>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6}>
              <Controller
                name="firstName"
                control={control}
                render={({ field }) => (
                  <TextField
                    error={!!errors.title}
                    required
                    label="First Name"
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
              {errors.firstname && (
                <Typography marginTop={1} color="red" role="alert">
                  {errors.title?.firstname}
                </Typography>
              )}
            </Grid>
            <Grid item xs={12} sm={6}>
              <Controller
                name="lastName"
                control={control}
                render={({ field }) => (
                  <TextField
                    error={!!errors.lastName}
                    required
                    label="Last Name"
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
              {errors.lastName && (
                <Typography marginTop={1} color="red" role="alert">
                  {errors.lastName?.message}
                </Typography>
              )}
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name="username"
                control={control}
                render={({ field }) => (
                  <TextField label="Username" fullWidth {...field} />
                )}
                rules={{ required: "User required" }}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name="email"
                control={control}
                render={({ field }) => (
                  <TextField label="Email" fullWidth {...field} />
                )}
                rules={{ required: "Email required" }}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name="password"
                control={control}
                render={({ field }) => (
                  <TextField
                    type={"password"}
                    label="Password"
                    fullWidth
                    {...field}
                  />
                )}
                rules={{ required: "Password required" }}
              />
            </Grid>
          </Grid>
        </form>
        <Button
          form="register-form"
          type="submit"
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Sign Up
        </Button>
      </Box>
    </Container>
  );
}

export default RegisterView;
