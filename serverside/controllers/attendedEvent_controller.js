const attendToEvent = async (req, res, next) => {
  var result = await req.service.attendToEvent(req, res, next);
  res.json({
    message: result ? "Event successfully attended" : "Already attended",
  });
};

const getAllAttendedEventsByUserId = async (req, res, next) => {
  var data = await req.service.getAllAttendedEventsByUserId(req, res, next);

  res.json(data);
};

const deleteAttendedEvent = async (req, res, next) => {
  await req.service.deleteAttendedEvent(req, res, next);
  res.json({
    message: "attended event is deleted",
  });
};

module.exports = {
  attendToEvent,
  getAllAttendedEventsByUserId,
  deleteAttendedEvent,
};
