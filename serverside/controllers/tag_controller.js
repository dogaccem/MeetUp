const createTag = async (req, res, next) => {
  await req.service.createTag(res, req, next);
  res.json("Tag successfully created");
};
const getAllTags = async (req, res, next) => {
  const data = await req.service.getAllTags(res, req, next);
  res.json(data);
};
module.exports = {
  createTag,
  getAllTags,
};
