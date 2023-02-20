import * as React from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Grid from "@mui/material/Grid";
import Container from "@mui/material/Container";
import GitHubIcon from "@mui/icons-material/GitHub";
import FacebookIcon from "@mui/icons-material/Facebook";
import TwitterIcon from "@mui/icons-material/Twitter";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import MainFeaturedPost from "./MainFeaturedPost";
import FeaturedPost from "./FeaturedPost";
import Main from "./Main";
import Sidebar from "./Sidebar";
import { Button, Divider, Typography } from "@mui/material";
import { useSelector } from "react-redux";
import {
  selectAttendedEvents,
  selectEventAttendees,
  selectEvents,
  selectFavEvents,
  selectPostedEvents,
} from "../../features/events/eventSlice";
import { selectUser } from "../../features/user/userSlice";
import { Link } from "react-router-dom";

const theme = createTheme();

export default function Blog({ handleDeletePostedEvent }) {
  const data = useSelector(selectAttendedEvents);
  const favs = useSelector(selectFavEvents);
  const posted = useSelector(selectPostedEvents);
  const userInfo = useSelector(selectUser);
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Container maxWidth="lg">
        <main>
          <MainFeaturedPost user={userInfo} />
          <Typography variant="h6" gutterBottom>
            Posted Events
          </Typography>
          <Divider sx={{ mb: 2 }} />
          <Grid container spacing={2}>
            {posted?.map((post) => (
              <FeaturedPost
                key={post?.title}
                post={post}
                handleDeletePostedEvent={handleDeletePostedEvent}
              />
            ))}
            <Link to={"/create"} style={{ textDecoration: "none" }}>
              <Button variant="contained">Post</Button>
            </Link>
          </Grid>
          <Grid container spacing={4} sx={{ mt: 3 }}>
            <Main title="Attended Posts" posts={data} />
            <Sidebar favs={favs} />
          </Grid>
        </main>
      </Container>
    </ThemeProvider>
  );
}
