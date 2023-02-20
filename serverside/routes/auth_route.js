const express = require("express");
const { login } = require("../controllers/auth_controller");

const router = express.Router();
router.post("/Login", login);

module.exports = router;
