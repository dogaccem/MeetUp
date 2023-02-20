const express = require("express");
const {
  register,
  getUser,
  getUserPostedEvents,
  deleteUserPostedEvents,
} = require("../controllers/user_controller");
const { authFromHeader } = require("../middleware/auth");

const router = express.Router();

router.post("/User", register);
router.get("/User", authFromHeader, getUser);
router.get("/User/user-posted", authFromHeader, getUserPostedEvents);

module.exports = router;
