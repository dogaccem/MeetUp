const mongoose = require("mongoose");

const favoriteEventModel = new mongoose.Schema(
  {
    user: {
      type: Object,
      required: true,
    },
    event: {
      type: Object,
      required: true,
    },
    isDeleted: {
      type: Boolean,
      default: false,
    },
  },
  {
    timestamps: true,
  }
);
mongoose.models = {};

favoriteEventModel.pre(["find", "findOne"], function () {
  this.where({ isDeleted: false });
});

const FavoriteEvent = mongoose.model("favoriteEvents", favoriteEventModel);

module.exports = FavoriteEvent;
