import SearchIcon from "@mui/icons-material/Search";
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";

import { Link } from "react-router-dom";
import "./Navbar.css";
import { AuthService } from "../services/auth.service";
import { useState } from "react";
import {
  Avatar,
  IconButton,
  Menu,
  MenuItem,
  Tooltip,
  Typography,
} from "@mui/material";
import Switch from "./Switch";
import { Person } from "@mui/icons-material";
import { Box } from "@mui/system";

const Navbar = () => {
  const isAuth = AuthService.isAuthenticated();
  const [anchorElNav, setAnchorElNav] = useState(null);
  const [anchorElUser, setAnchorElUser] = useState(null);

  const handleOpenNavMenu = (event) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = (event) => {
    console.log(event.currentTarget);
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const logout = async () => {
    AuthService.logout();
    window.location.href = "/login";
    window.location.reload(false);
  };
  return (
    <div className="navbar">
      <div className="wrapper">
        <div className="left">
          <div className="item">
            <Link className="link" to="/events">
              Events
            </Link>
          </div>
        </div>
        <div className="center">
          <Link className="link" to="/">
            MeetUp
          </Link>
        </div>
        <div className="right">
          <div className="item">
            <Link className="link" to="/">
              Homepage
            </Link>
          </div>
          <div className="icons">
            <Box sx={{ flexGrow: 0 }}>
              {isAuth ? (
                <Tooltip title="Open settings">
                  <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                    <Avatar
                      alt="Remy Sharp"
                      src="/static/images/avatar/2.jpg"
                    />
                  </IconButton>
                </Tooltip>
              ) : (
                <Tooltip title="Login">
                  <Link to={"/login"}>
                    <IconButton>
                      <Person fontSize="large" sx={{ color: "gray" }} />
                    </IconButton>
                  </Link>
                </Tooltip>
              )}
              <Menu
                sx={{ mt: "45px" }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                <Link to={"/profile"} style={{ textDecoration: "none" }}>
                  <MenuItem>
                    <Typography textAlign="center"> Profile </Typography>
                  </MenuItem>
                </Link>

                <MenuItem onClick={logout}>
                  <Typography textAlign="center">Logout</Typography>
                </MenuItem>
              </Menu>
              <Switch></Switch>
            </Box>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Navbar;
