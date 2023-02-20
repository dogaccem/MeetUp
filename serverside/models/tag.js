const mongoose = require("mongoose");

const tagModel = new mongoose.Schema(
  {
    name: {
      type: String,
      required: true,
      unique: true,
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

tagModel.pre(["find", "findOne"], function () {
  this.where({ isDeleted: false });
});

const Tag = mongoose.model("Tags", tagModel);

module.exports = Tag;
