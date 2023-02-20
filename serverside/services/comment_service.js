const Comment = require("../models/comment");

const getAllCommentsByEventId = async (req, res, next) => {
  return await Comment.find({ eventId: req.body.id });
};

module.exports = {
  getAllCommentsByEventId,
};
