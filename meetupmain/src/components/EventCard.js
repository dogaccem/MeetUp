import { useEffect, useState } from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { grey, red } from "@mui/material/colors";
import {
  Avatar,
  AvatarGroup,
  Button,
  CardActionArea,
  CardActions,
  Grid,
  IconButton,
} from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import { Link } from "react-router-dom";
import Divider from "@mui/material/Divider";
import { useDispatch, useSelector } from "react-redux";
import { selectEventAttendees } from "../features/events/eventSlice";
import { EventService } from "../services/event.service";

const styles = (muiBaseTheme) => ({
  avatar: {
    display: "inline-block",
    border: "2px solid white",
    "&:not(:first-of-type)": {
      marginLeft: -muiBaseTheme.spacing.unit,
    },
  },
});

export default function EventCard({ post }) {
  const dispatch = useDispatch();
  const attendees = useSelector(selectEventAttendees);
  console.log("🚀 ~ file: EventCard.js:36 ~ attendees", attendees);
  console.log(
    "🚀 ~ file: EventCard.js:70 ~ post.countAttendees",
    post.id || post._id,
    post.title,
    post.countAttendees
  );
  const [color, setColor] = useState("secondary");
  function handleColorChange() {
    if (color === "secondary") {
      setColor("warning");
      dispatch(EventService.addFav(post.id || post._id));
    } else {
      setColor("secondary");
      dispatch(EventService.deleteFavEvent(post.id || post._id));
    }
  }
  return (
    <Grid item xs={12} md={4}>
      <Card sx={{ width: 250 }}>
        <Link className="link" to={`/event/${post.id || post._id}`}>
          <CardActionArea>
            <CardMedia
              component="img"
              height="140"
              image="https://source.unsplash.com/random"
              alt="event picture"
            />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                {post.title}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                {post.shortContent}
              </Typography>
            </CardContent>
          </CardActionArea>
        </Link>
        <Divider light />
        <AvatarGroup total={post.countAttendees}>
          {attendees?.data?.map((user, index) => {
            console.log(
              "🚀 ~ file: EventCard.js:70 ~ {attendees?.data?.map ~ user",
              user
            );
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
        <CardActions>
          <IconButton
            aria-label="add-to-favorites"
            onClick={handleColorChange}
            color={color}
          >
            <FavoriteIcon />
          </IconButton>
        </CardActions>
      </Card>
    </Grid>
  );
}
