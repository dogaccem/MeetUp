import * as React from "react";
import { styled, alpha } from "@mui/material/styles";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import InputBase from "@mui/material/InputBase";
import MenuIcon from "@mui/icons-material/Menu";
import SearchIcon from "@mui/icons-material/Search";
import Button from "@mui/material/Button";
import { useDispatch } from "react-redux";
import { EventService } from "../services/event.service";
import { useSelect } from "@mui/base";
import { selectEvents } from "../features/events/eventSlice";

const Search = styled("div")(({ theme }) => ({
  position: "relative",
  borderRadius: theme.shape.borderRadius,
  backgroundColor: alpha(theme.palette.common.white, 0.15),
  "&:hover": {
    backgroundColor: alpha(theme.palette.common.white, 0.25),
  },
  marginLeft: 0,
  width: "100%",
  [theme.breakpoints.up("sm")]: {
    marginLeft: theme.spacing(1),
    width: "auto",
  },
}));

const SearchIconWrapper = styled("div")(({ theme }) => ({
  padding: theme.spacing(0, 2),
  height: "100%",
  position: "absolute",
  pointerEvents: "none",
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: "inherit",
  "& .MuiInputBase-input": {
    padding: theme.spacing(1, 1, 1, 0),
    // vertical padding + font size from searchIcon
    paddingLeft: `calc(1em + ${theme.spacing(4)})`,
    transition: theme.transitions.create("width"),
    width: "100%",
    [theme.breakpoints.up("sm")]: {
      width: "12ch",
      "&:focus": {
        width: "20ch",
      },
    },
  },
}));

export default function SearchAppBar() {
  const [tag, setTagSearchQuery] = React.useState(null);
  const [place, setPlaceSearchQuery] = React.useState(null);
  const [category, setCategorySearchQuery] = React.useState(null);
  const dispatch = useDispatch();
  //const eventResponse = useSelect(selectEvents);
  //const events = eventResponse?.data?.matches || [];

  function searchHandle(e) {
    e.preventDefault();

    dispatch(EventService.searchEvents({ place, tag, category }));
  }

  return (
    <Box component="form" onSubmit={searchHandle} sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="open drawer"
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ flexGrow: 1, display: { xs: "none", sm: "block" } }}
          >
            MUI
          </Typography>
          <Search>
            <SearchIconWrapper>
              <SearchIcon />
            </SearchIconWrapper>
            <StyledInputBase
              placeholder="Place..."
              inputProps={{ "aria-label": "search" }}
              value={place}
              onInput={(e) => {
                console.log(e.target.value);
                setPlaceSearchQuery(e.target.value);
              }}
            />
          </Search>
          <Search>
            <SearchIconWrapper>
              <SearchIcon />
            </SearchIconWrapper>
            <StyledInputBase
              placeholder="Tag..."
              inputProps={{ "aria-label": "search" }}
              value={tag}
              onInput={(e) => {
                console.log(e.target.value);
                setTagSearchQuery(e.target.value);
              }}
            />
          </Search>
          <Search>
            <SearchIconWrapper>
              <SearchIcon />
            </SearchIconWrapper>
            <StyledInputBase
              placeholder="Category..."
              inputProps={{ "aria-label": "search" }}
              value={category}
              onInput={(e) => {
                console.log(e.target.value);
                setCategorySearchQuery(e.target.value);
              }}
            />
          </Search>
          <Button
            type="submit"
            color="secondary"
            variant="outlined"
            startIcon={<SearchIcon />}
            sx={{ ml: 3 }}
          >
            Search
          </Button>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
