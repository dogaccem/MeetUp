import * as React from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Grid from "@mui/material/Grid";
import Container from "@mui/material/Container";

import { createTheme, ThemeProvider } from "@mui/material/styles";
import Slider from "@mui/material/Slider";
import { Box, Button, Divider, Typography } from "@mui/material";
import { useSelector } from "react-redux";
import { selectEvents } from "../../features/events/eventSlice";
import EventCard from "../../components/EventCard";
import SearchForm from "../../forms/eventSearch/SearchForm";

const theme = createTheme();

function EventsView({ onSubmitSearch }) {
  const data = useSelector(selectEvents);
  console.log("🚀 ~ file: EventsView.js:18 ~ EventsView ~ data", data);
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Container maxWidth="lg">
        <main>
          <Box sx={{ display: "flex", flexDirection: "row" }}>
            <Box
              maxWidth={"25rem"}
              maxHeight={"50rem"}
              sx={{ mt: 5, mr: 5, pt: 10 }}
            >
              <Typography id="input-slider" gutterBottom>
                Search
              </Typography>

              <SearchForm onSubmit={onSubmitSearch} />
              <Button
                form="event-form"
                type="submit"
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
              >
                Search
              </Button>
            </Box>
            <Box>
              <Typography variant="h6" gutterBottom>
                Posted Events
              </Typography>
              <Divider sx={{ mb: 2 }} />
              <Grid container spacing={1}>
                {data?.data?.map((post) => (
                  <EventCard key={post?.title} post={post} />
                ))}
              </Grid>
            </Box>
          </Box>
        </main>
      </Container>
    </ThemeProvider>
  );
}
export default EventsView;
