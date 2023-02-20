import * as React from "react";
import { styled } from "@mui/material/styles";
import Box from "@mui/material/Box";
import Paper from "@mui/material/Paper";
import { useDispatch, useSelector } from "react-redux";
import { EventService } from "../../services/event.service";
import { useEffect, useState } from "react";
import { CategoryService } from "../../services/category.service";
import { TagService } from "../../services/tag.service";
import EventsView from "./EventsView";

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary,
}));

function Events() {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(EventService.getEvents());
    dispatch(CategoryService.getCategories());
    dispatch(TagService.getTags());
  }, [dispatch]);
  function onSubmitSearch(data) {
    console.log("🚀 ~ file: Events.js:28 ~ onSubmitSearch ~ data", data);
    dispatch(EventService.searchEvents(data));
  }
  return (
    <Box
      sx={{
        marginLeft: 1,
        marginTop: 1,
        flexGrow: 1,
      }}
    >
      <EventsView onSubmitSearch={onSubmitSearch} />
    </Box>
  );
}

export default Events;
