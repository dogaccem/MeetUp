const mongoose = require("mongoose");

const eventModel = new mongoose.Schema(
  {
    title: {
      type: String,
      required: true,
    },
    shortContent: {
      type: String,
      required: true,
    },
    place: {
      type: String,
      required: true,
    },
    capacity: {
      type: Number,
      required: true,
    },
    image: {
      type: String,
      required: true,
    },
    tags: {
      type: Object,
      required: false,
      ref: "tags",
    },
    categoryId: {
      type: Number,
      required: false,
    },
    comments: {
      type: Object,
      required: false,
      ref: "comments",
    },
    userId: {
      type: String,
      required: false,
    },
    startDate: {
      type: String,
      required: true,
    },
    endDate: {
      type: String,
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

eventModel.pre(["find", "findOne"], function () {
  this.where({ isDeleted: false });
});

const Event = mongoose.model("Events", eventModel);

module.exports = Event;
