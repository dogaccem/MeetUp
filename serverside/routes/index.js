const express = require("express");

const authRoute = require("./auth_route");
const userRoute = require("./user_route");
const eventRoute = require("./event_route");
const favoriteEventRoute = require("./favoriteEvent_route");
const attendedEventRoute = require("./attendedEvent_route");
const tagRoute = require("./tag_route");
const categoryRoute = require("./category_route");
//const commentRoute = require("./comment_route");

const { authFromHeader, authFromCookie } = require("../middleware/auth");
const container = require("../middleware/ioc");

const userService = require("../services/user_service");
const eventService = require("../services/event_service");
const tagService = require("../services/tag_service");
//const commentService = require("../services/comment_service");
const categoryService = require("../services/category_service");
const attendedEventService = require("../services/attendedEvent_service");
const favoriteEventService = require("../services/favoriteEvent_service");

const router = express.Router();
router.use(container(userService), authRoute);
router.use(container(userService), userRoute);
router.use(container(eventService), eventRoute);
router.use(authFromHeader, container(attendedEventService), attendedEventRoute);
router.use(authFromHeader, container(favoriteEventService), favoriteEventRoute);
//router.use(authFromHeader, container(commentService), commentRoute);
router.use(container(categoryService), categoryRoute);
router.use(container(tagService), tagRoute);
module.exports = router;
