const getAllCategories = async (req, res, next) => {
  const data = await req.service.getAllCategories(req, res, next);
  res.json({ data: data });
};

const createCategory = async (req, res, next) => {
  await req.service.createCategory(req, res, next);
  res.json("category created");
};
module.exports = {
  getAllCategories,
  createCategory,
};
