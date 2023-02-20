const express = require("express");
const {
  getAllCategories,
  createCategory,
} = require("../controllers/category_controller");

const router = express.Router();

router.get("/Category/all", getAllCategories);
router.post("/Category", createCategory);

module.exports = router;
