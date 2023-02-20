const express = require("express");
const {
  attendToEvent,
  getAllAttendedEventsByUserId,
  deleteAttendedEvent,
} = require("../controllers/attendedEvent_controller");

const router = express.Router();

router.post("/AttendedEvent/attend/:id", attendToEvent);
router.get("/AttendedEvent/user-attended", getAllAttendedEventsByUserId);

module.exports = router;
