import * as React from "react";
import PropTypes from "prop-types";
import Paper from "@mui/material/Paper";
import Typography from "@mui/material/Typography";
import Grid from "@mui/material/Grid";
import Link from "@mui/material/Link";
import Box from "@mui/material/Box";
import { Avatar } from "@mui/material";

function MainFeaturedPost(user) {
  console.log(
    "🚀 ~ file: MainFeaturedPost.js:11 ~ MainFeaturedPost ~ user",
    user
  );
  return (
    <Paper
      sx={{
        position: "relative",
        backgroundColor: "grey.800",
        color: "#fff",
        mb: 4,
        mt: 5,
        backgroundSize: "cover",
        backgroundRepeat: "no-repeat",
        backgroundPosition: "center",
      }}
    >
      <Box
        sx={{
          position: "absolute",
          top: 0,
          bottom: 0,
          right: 0,
          left: 0,
          backgroundColor: "rgba(0,0,0,.3)",
        }}
      />
      <Grid container>
        <Grid item md={6}>
          <Box
            sx={{
              position: "relative",
              p: { xs: 3, md: 6 },
              pr: { md: 0 },
            }}
          >
            <Typography
              component="h1"
              variant="h3"
              color="inherit"
              gutterBottom
            >
              {user?.user?.firstName} {user?.user?.lastName}
            </Typography>
            <Typography variant="h5" color="inherit" paragraph>
              E-mail:{user?.user?.email}
            </Typography>
            <Typography variant="h5" color="inherit" paragraph>
              Username: {user?.user?.username}
            </Typography>
          </Box>
        </Grid>
        <Grid item md={6}>
          <Box
            sx={{
              display: "flex",
              alignContent: "center",
              position: "relative",
              p: { xs: 3, md: 6 },
              pr: { md: 0 },
            }}
          >
            <Avatar></Avatar>
          </Box>
        </Grid>
      </Grid>
    </Paper>
  );
}

export default MainFeaturedPost;
