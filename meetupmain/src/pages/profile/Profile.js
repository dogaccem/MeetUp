import { useEffect } from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Typography from "@mui/material/Typography";
import Blog from "./profileView";
import { useDispatch } from "react-redux";
import { EventService } from "../../services/event.service";
import { useParams } from "react-router-dom";
import { UserService } from "../../services/user.service";

export default function Profile() {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(UserService.getUser());

    dispatch(EventService.getUserAttendedEvents());
    dispatch(EventService.getFavEvents());
    dispatch(EventService.getUserPostedEvents());
  }, [dispatch]);

  function handleDeletePostedEvent(id) {
    dispatch(EventService.deletePostedEvent(id));
  }

  return <Blog handleDeletePostedEvent={handleDeletePostedEvent} />;
}
