const createEvent = async (req, res, next) => {
  await req.service.createEvent(req, res, next);
  res.json({
    isSuccess: true,
    message: "Event successfully created",
  });
};
const getAllEvents = async (req, res, next) => {
  const data = await req.service.getAllEvents(req, res, next);
  debugger;
  res.json({
    data: data,
    message: "all event",
  });
};
const getEventsByTagName = async (req, res, next) => {
  const data = await req.service.getEventByTagName(req, res, next);
  res.json(data);
};
const getEventsByCategoryName = async (req, res, next) => {
  const data = await req.service.getEventsByCategoryName(req, res, next);
  res.json(data);
};
const getEventsByCategoryId = async (req, res, next) => {
  const data = await req.service.getEventsByCategoryId(req, res, next);
  res.json(data);
};
const updateEvent = async (req, res, next) => {
  await req.service.updateEvent(req, res, next);
  res.json({
    message: "Event successfully updated",
  });
};
const getEvent = async (req, res, next) => {
  const data = await req.service.getEventDetail(req, res, next);
  res.json({
    data: data,
  });
};
const deleteUserPostedEvents = async (req, res, next) => {
  await req.service.deleteUserPostedEvents(req, res, next);

  res.json("deleted");
};
module.exports = {
  createEvent,
  getAllEvents,
  getEvent,
  getEventsByCategoryId,
  getEventsByCategoryName,
  getEventsByTagName,
  updateEvent,
  deleteUserPostedEvents,
};
