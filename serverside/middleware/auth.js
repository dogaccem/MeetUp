const jwt = require("jsonwebtoken");

const authFromHeader = (req, res, next) => {
  const authHeader = req.headers["authorization"];
  const token = authHeader && authHeader.split(" ")[1];
  if (token == null) return res.sendStatus(401);

  jwt.verify(token, "jwt_secret_key", (err, decoded) => {
    if (err) return res.sendStatus(403);
    req.userId = decoded.userId;
    console.log("🚀 ~ file: auth.js:11 ~ jwt.verify ~ req.userId", req.userId);
    next();
  });
};

const authFromCookie = (req, res, next) => {
  const token = req.cookies.token;
  if (token == null) return res.sendStatus(401);

  jwt.verify(token, "jwt_secret_key", (err, decoded) => {
    if (err) return res.sendStatus(403);
    req.userId = decoded.userId;
    next();
  });
};

module.exports = {
  authFromHeader,
  authFromCookie,
};
