const express = require("express");
const { authFromHeader, authFromCookie } = require("../middleware/auth");
const {
  createEvent,
  getAllEvents,
  getEvent,
  getEventsByCategoryId,
  getEventsByCategoryName,
  getEventsByTagName,
  updateEvent,
  deleteUserPostedEvents,
} = require("../controllers/event_controller");

const router = express.Router();

router.get("/Event", getAllEvents);
router.post("/Event", authFromCookie, createEvent);
router.put("/Event/:id", authFromCookie, updateEvent);
router.get("/Event/:id", getEvent);
router.get("/Event/by-category-id/:id", getEventsByCategoryId);
router.delete("/Event/:id", deleteUserPostedEvents);

module.exports = router;
