const mongoose = require("mongoose");

const attendedEventModel = new mongoose.Schema(
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

attendedEventModel.pre(["find", "findOne"], function () {
  this.where({ isDeleted: false });
});

const AttendedEvent = mongoose.model("attendedEvents", attendedEventModel);

module.exports = AttendedEvent;
