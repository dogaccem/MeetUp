const mongoose = require("mongoose");

const commentModel = new mongoose.Schema(
  {
    content: {
      type: String,
      required: true,
    },
    userId: {
      type: String,
      required: true,
    },
    eventId: {
      type: Number,
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

commentModel.pre(["find", "findOne"], function () {
  this.where({ isDeleted: false });
});

const Comment = mongoose.model("Comments", commentModel);

module.exports = Comment;
