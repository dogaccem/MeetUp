const login = async (req, res, next) => {
  await req.service.login(req, res, next);
};

const logout = async (req, res, next) => {
  console.log("ab");
  await req.service.logout(req, res, next);
};

module.exports = {
  login,
  logout,
};
