const Tag = require("../models/tag");

const getAllTags = async (req, res, next) => {
  return await Tag.find();
};

const createTag = async (req, res, next) => {
  const tag = new Tag({
    name: req.body.name,
  });
  return tag;
};

module.exports = {
  getAllTags,
  createTag,
};
