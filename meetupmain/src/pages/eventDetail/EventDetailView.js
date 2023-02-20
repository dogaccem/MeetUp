import React, { useEffect } from "react";
import dayjs from "dayjs";
import { useState } from "react";
import { useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { EventService } from "../../services/event.service";
import {
  selectEventAttendees,
  selectEvents,
} from "../../features/events/eventSlice";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import AvatarGroup from "@mui/material/AvatarGroup";
import Divider from "@mui/material/Divider";

const theme = createTheme();
const EventDetailView = ({ handleAttend }) => {
  const eventDetail = useSelector(selectEvents);
  console.log(
    "🚀 ~ file: EventDetailView.js:25 ~ EventDetailView ~ eventDetail",
    eventDetail
  );
  const attendees = useSelector(selectEventAttendees);
  return (
    <ThemeProvider theme={theme}>
      <Grid container component="main" sx={{ height: "100vh" }}>
        <CssBaseline />
        <Grid
          item
          xs={false}
          sm={4}
          md={7}
          sx={{
            backgroundImage: "url(https://source.unsplash.com/random)",
            backgroundRepeat: "no-repeat",
            backgroundColor: (t) =>
              t.palette.mode === "light"
                ? t.palette.grey[50]
                : t.palette.grey[900],
            backgroundSize: "cover",
            backgroundPosition: "center",
          }}
        />
        <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
          <Box
            sx={{
              my: 8,
              mx: 4,
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
            }}
          >
            <Typography component="h1" variant="h5">
              Event Detail
            </Typography>
            <Box>
              <Typography variant="h4" gutterBottom>
                {eventDetail?.data?.title}
              </Typography>
              <Typography variant="subtitle1" gutterBottom>
                start : {eventDetail?.data?.startDate}
              </Typography>
              <Typography variant="subtitle1" gutterBottom>
                end : {eventDetail?.data?.startDate}
              </Typography>
              <p>{eventDetail?.data?.content}</p>
              <Typography variant="caption" display="block" gutterBottom>
                Place:{eventDetail?.data?.place}
              </Typography>
              <Typography variant="caption" display="block" gutterBottom>
                Capacity:{eventDetail?.data?.capacity}
              </Typography>
              <Divider light />
              <AvatarGroup total={eventDetail?.data?.countAttendees}>
                {attendees?.map((user, index) => {
                  return (
                    <Avatar
                      key={index}
                      alt={user.firstName + " " + user.lastName}
                      src="/static/images/avatar/1.jpg"
                    />
                  );
                })}
              </AvatarGroup>
              <Divider light />
              <Button variant="contained" onClick={handleAttend}>
                Attend To Event
              </Button>
            </Box>
          </Box>
        </Grid>
      </Grid>
    </ThemeProvider>
  );
};

export default EventDetailView;
