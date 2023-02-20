const Event = require("../models/event");
const Tag = require("../models/tag");
const FavoriteEvent = require("../models//favoriteEvent");
const AttendedEvent = require("../models/attendedEvent");

const createEvent = async (req, res, next) => {
  const event = new Event({
    title: req.body.title,
    shortContent: req.body.shortContent,
    place: req.body.place,
    startDate: req.body.startDate,
    endDate: req.body.endDate,
    content: req.body.content,
    categoryId: req.body.categoryId,
    userId: req.userId,
    tags: req.body.tags,
  });
  const tags = req.body.tags.split(",");

  tags.forEach((tag) => {
    Tag.create({ name: tag }, function (err) {});
  });

  await event.save();
};

const getAllEvents = async (req, res, next) => {
  const events = await Event.find();
  return events;
};

const getEventsByCategoryId = async (req, res, next) => {
  const events = await Event.find({ categoryId: req.body.categoryId });
  return events;
};
const getEventsByTagName = async (req, res, next) => {
  const events = await Event.find({ categoryId: req.body.tagName });
  return events;
};

const updateEvent = async (req, res, next) => {
  await Event.findByIdAndUpdate(req.params.id, {
    title: req.body.title,
    shortContent: req.body.shortContent,
    place: req.body.place,
    startDate: req.body.startDate,
    endDate: req.body.endDate,
    content: req.body.content,
    categoryId: req.body.categoryId,
  });
};

const getEventDetail = async (req, res, next) => {
  const event = await Event.findById(req.params.id);
  return event;
};

const deleteUserPostedEvents = async (req, res, next) => {
  var event = await Event.findByIdAndUpdate(req.params.id, {
    isDeleted: true,
  });
  console.log("🚀 ~ file: event_service.js:62 ~ event ~ event", event);
  let favoriteEvent = await FavoriteEvent.find({ event: event });
  favoriteEvent.forEach(async (fevent) => {
    fevent.isDeleted = true;
    await fevent.save();
  });

  let joinedEvent = await AttendedEvent.find({ event: event });
  joinedEvent.forEach(async (jevent) => {
    jevent.isDeleted = true;
    await jevent.save();
  });
};

module.exports = {
  createEvent,
  updateEvent,
  getAllEvents,
  getEventsByCategoryId,
  getEventsByTagName,
  getEventDetail,
  deleteUserPostedEvents,
};
