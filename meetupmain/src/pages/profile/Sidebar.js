import * as React from "react";
import PropTypes from "prop-types";
import Grid from "@mui/material/Grid";
import Stack from "@mui/material/Stack";
import Paper from "@mui/material/Paper";
import Typography from "@mui/material/Typography";
import Link from "@mui/material/Link";

function Sidebar({ favs }) {
  console.log("🚀 ~ file: Sidebar.js:10 ~ Sidebar ~ favs", favs);
  return (
    <Grid item xs={12} md={4}>
      <Typography variant="h6" gutterBottom sx={{ mt: 3 }}>
        Favorite Events
      </Typography>
      {favs?.map((fav) => (
        <Link
          display="block"
          variant="body1"
          key={fav.title}
          href={`event/${fav.id || fav._id}`}
        >
          {fav.title}
        </Link>
      ))}
    </Grid>
  );
}

Sidebar.propTypes = {
  archives: PropTypes.arrayOf(
    PropTypes.shape({
      title: PropTypes.string.isRequired,
      url: PropTypes.string.isRequired,
    })
  ).isRequired,
  description: PropTypes.string.isRequired,
  social: PropTypes.arrayOf(
    PropTypes.shape({
      icon: PropTypes.elementType.isRequired,
      name: PropTypes.string.isRequired,
    })
  ).isRequired,
  title: PropTypes.string.isRequired,
};

export default Sidebar;
