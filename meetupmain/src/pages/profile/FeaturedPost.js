import * as React from "react";
import PropTypes from "prop-types";
import Typography from "@mui/material/Typography";
import Grid from "@mui/material/Grid";
import Card from "@mui/material/Card";
import CardActionArea from "@mui/material/CardActionArea";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import { Box, Button, CardActions, Divider } from "@mui/material";
import { Delete, Edit } from "@mui/icons-material";
import { Link } from "react-router-dom";

function FeaturedPost(props) {
  const { post, handleDeletePostedEvent } = props;

  return (
    <Grid item xs={12} md={6}>
      <Card sx={{ display: "flex" }}>
        <CardActions>
          <Box>
            <Link className="link" to={`/update/${post._id || post.id}`}>
              <Button size="small" color="primary">
                <Edit />
              </Button>
            </Link>
            <Button
              size="small"
              color="primary"
              onClick={() => handleDeletePostedEvent(post.id || post._id)}
            >
              <Delete />
            </Button>
          </Box>
        </CardActions>
        <Link className="link" to={`/event/${post._id || post.id}`}>
          <CardActionArea>
            <CardContent sx={{ flex: 1 }}>
              <Typography component="h2" variant="h5">
                {post.title}
              </Typography>
              <Typography variant="subtitle1" paragraph>
                {post.description}
              </Typography>
              <Typography variant="subtitle1" color="primary">
                Continue reading...
              </Typography>
            </CardContent>
            <CardMedia
              component="img"
              sx={{ width: 160, display: { xs: "none", sm: "block" } }}
              image=" "
            />
          </CardActionArea>
        </Link>
      </Card>
    </Grid>
  );
}

FeaturedPost.propTypes = {
  post: PropTypes.shape({
    date: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired,
    image: PropTypes.string.isRequired,
    imageLabel: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
  }).isRequired,
};

export default FeaturedPost;
