import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { EventService } from "../../services/event.service";

import { createTheme, ThemeProvider } from "@mui/material/styles";

import EventDetailView from "./EventDetailView";

const theme = createTheme();
const Product = () => {
  const id = useParams().id;
  console.log("🚀 ~ file: EventDetail.js:13 ~ Product ~ id", id);
  const dispatch = useDispatch();
  const handleAttend = (event) => {
    event.preventDefault();
    dispatch(EventService.attendToEvent(id));
  };
  useEffect(() => {
    dispatch(EventService.getEventWithDetail(id));
    dispatch(EventService.getEventAttendees(id));
  }, [id, dispatch]);

  return <EventDetailView handleAttend={handleAttend} />;
};

export default Product;
