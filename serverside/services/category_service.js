const Category = require("../models/category");

const getAllCategories = async (req, res, next) => {
  return await Category.find();
};

const createCategory = async (req, res, next) => {
  Category.create({ name: req.body.name }, function (err) {});
};

module.exports = {
  getAllCategories,
  createCategory,
};
