const bcrypt = require("bcryptjs");
const jwt = require("jsonwebtoken");

const User = require("../models/user");
const Event = require("../models/event");

const register = async (req, res, next) => {
  const email = await User.findOne({ email: req.body.email });
  const username = await User.findOne({ user: req.body.username });
  const salt = bcrypt.genSaltSync(10);
  const hashedPassword = bcrypt.hashSync(req.body.password, salt);
  if (email && username) {
    return false;
  }
  const user = new User({
    firstName: req.body.firstName,
    lastName: req.body.lastName,
    username: req.body.username,
    email: req.body.email,
    password: hashedPassword,
  });
  await user.save();
  return true;
};

const login = async (req, res, next) => {
  let user = await User.findOne({ email: req.body.username });
  if (user == null) {
    user = await User.findOne({ username: req.body.username });
  }
  if (user != null) {
    const checkPassword = bcrypt.compareSync(req.body.password, user.password);

    if (!checkPassword)
      return res.status(400).json("Wrong password or username!");

    const token = jwt.sign(
      { userId: user._id, username: user.username },
      "jwt_secret_key"
    );
    res
      .cookie("token", token, {
        httpOnly: true,
      })
      .status(200)
      .json({
        data: token
          ? {
              token: token,
            }
          : "",
        isSuccess: token ? true : false,
        message: token ? "" : "Username or Wrong password!",
      });
  } else {
    return false;
  }
};

const getUser = async (req, res, next) => {
  return await User.findById(req.userId);
};

const logout = async (req, res, next) => {
  res
    .clearCookie("token", {
      secure: true,
      sameSite: "none",
    })
    .status(200)
    .json("User has been logged out.");
};

const getUserPostedEvents = async (req, res, next) => {
  const events = await Event.find({ userId: req.userId });
  return events;
};

module.exports = {
  register,
  login,
  getUser,
  logout,
  getUserPostedEvents,
};
