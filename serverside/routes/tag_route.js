const express = require("express");
const { createTag, getAllTags } = require("../controllers/tag_controller");

const router = express.Router();

router.post("/Tag/tags", getAllTags);

module.exports = router;
