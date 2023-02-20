const mongoose = require("mongoose");

const category = new mongoose.Schema(
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

category.pre(["find", "findOne"], function () {
  this.where({ isDeleted: false });
});

const Category = mongoose.model("Categories", category);

module.exports = Category;
