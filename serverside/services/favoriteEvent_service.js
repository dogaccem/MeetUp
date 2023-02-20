const FavoriteEvent = require("../models/favoriteEvent");
const Event = require("../models/event");
const User = require("../models/user");

const addEventToFavorite = async (req, res, next) => {
  const user = await User.findById(req.userId);
  const event = await Event.findById(req.params.id);
  const result = await FavoriteEvent.findOne({
    user: user,
    event: event,
  });
  if (!result) {
    const favoriteEvent = new FavoriteEvent({
      user: user,
      event: event,
    });
    await favoriteEvent.save();
    return true;
  } else {
    return false;
  }
};

const getAllFavoriteEventsByUserId = async (req, res, next) => {
  const user = await User.findById(req.userId);
  console.log(
    "🚀 ~ file: favoriteEvent_service.js:26 ~ getAllFavoriteEventsByUserId ~ req.userId",
    req.userId
  );
  console.log(
    "🚀 ~ file: favoriteEvent_service.js:26 ~ getAllFavoriteEventsByUserId ~ user",
    user
  );

  const favorites = await FavoriteEvent.find({ user: user });

  let favoritesWithDetail = await Promise.all(
    favorites.map(async (data) => {
      let res = {
        ...data.event,
      };
      return res;
    })
  );
  return favoritesWithDetail;
};

const deleteFavoriteEvent = async (req, res, next) => {
  await FavoriteEvent.find({
    userId: req.cookies.accessToken,
    eventId: req.params.id,
  }).update({ isDeleted: true });
};

module.exports = {
  addEventToFavorite,
  getAllFavoriteEventsByUserId,
  deleteFavoriteEvent,
};
