const AttendedEvent = require("../models/attendedEvent");
const Event = require("../models/event");
const User = require("../models/user");

const attendToEvent = async (req, res, next) => {
  const user = await User.findById(req.userId);
  const event = await Event.findById(req.params.id);
  const result = await AttendedEvent.findOne({
    user: user,
    event: event,
  });
  if (!result) {
    const attendedEvent = new AttendedEvent({
      user: user,
      event: event,
    });
    await attendedEvent.save();
    return true;
  } else {
    return false;
  }
};

const getAllAttendedEventsByUserId = async (req, res, next) => {
  const user = await User.findById(req.userId);
  const attendedEvents = await AttendedEvent.find({ user: user });
  let attendedEventsWithDetail = await Promise.all(
    attendedEvents.map(async (data) => {
      let res = {
        ...data.event,
      };
      return res;
    })
  );
  return attendedEventsWithDetail;
};

const deleteAttendedEvent = async (req, res, next) => {
  await AttendedEvent.find({
    userId: req.userId,
    eventId: req.params.id,
  }).update({ isDeleted: true });
};

module.exports = {
  attendToEvent,
  getAllAttendedEventsByUserId,
  deleteAttendedEvent,
};
