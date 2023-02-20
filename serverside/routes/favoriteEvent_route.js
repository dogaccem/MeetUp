const express = require("express");
const {
  addEventToFavorites,
  getFavoriteEventsByUserId,
  deleteFavoriteEvent,
} = require("../controllers/favoriteEvent_controller");

const router = express.Router();

router.post("/FavoriteEvent/fav/:id", addEventToFavorites);
router.get("/FavoriteEvent/user-favs", getFavoriteEventsByUserId);

module.exports = router;
