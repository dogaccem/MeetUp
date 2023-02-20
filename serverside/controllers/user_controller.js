const register = async (req, res, next) => {
  const isSuccess = await req.service.register(req, res, next);
  res.json({
    isSuccess: isSuccess,
    message: isSuccess ? "Created" : "Ops",
  });
};

const getUser = async (req, res, next) => {
  const data = await req.service.getUser(req, res, next);
  res.json(data);
};

const getUserPostedEvents = async (req, res, next) => {
  const data = await req.service.getUserPostedEvents(req, res, next);
  res.json(data);
};

module.exports = {
  register,
  getUser,
  getUserPostedEvents,
};
