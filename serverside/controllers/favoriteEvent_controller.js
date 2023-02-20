const addEventToFavorites = async (req, res, next) => {
  var result = await req.service.addEventToFavorite(req, res, next);
  res.json({
    message: result ? "Event successfully added to favorites" : "error",
  });
};

const getFavoriteEventsByUserId = async (req, res, next) => {
  var data = await req.service.getAllFavoriteEventsByUserId(req, res, next);
  console.log(
    "🚀 ~ file: favoriteEvent_controller.js:10 ~ getFavoriteEventsByUserId ~ data",
    data
  );
  res.json(data);
};

const deleteFavoriteEvent = async (req, res, next) => {
  await req.service.deleteFavoriteEvent(req, res, next);
  res.json({
    message: "favorite event is deleted",
  });
};

module.exports = {
  addEventToFavorites,
  getFavoriteEventsByUserId,
  deleteFavoriteEvent,
};
