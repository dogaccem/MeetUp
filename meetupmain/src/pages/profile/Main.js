import * as React from "react";
import PropTypes from "prop-types";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import Divider from "@mui/material/Divider";
import { MenuItem } from "@mui/material";
import FeaturedPost from "./FeaturedPost";
import FavEvents from "./FavEvents";

function Main(props) {
  const { posts, title } = props;

  return (
    <Grid
      item
      spacing={1}
      xs={12}
      md={8}
      sx={{
        "& .markdown": {
          py: 3,
        },
      }}
    >
      <Typography variant="h6" gutterBottom>
        {title}
      </Typography>
      <Divider />
      {posts?.map((post) => (
        <FavEvents key={post?.title} post={post} />
      ))}
    </Grid>
  );
}

Main.propTypes = {
  post: PropTypes.shape({
    date: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired,
    image: PropTypes.string.isRequired,
    imageLabel: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
  }).isRequired,
  title: PropTypes.string.isRequired,
};

export default Main;
