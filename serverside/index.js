const express = require("express");

const api = require("./routes/index");
const cors = require("cors");
const bodyParser = require("body-parser");
const connectDB = require("./database/db");
const cookieParser = require("cookie-parser");

const app = express();
const port = 8080;
app.use((req, res, next) => {
  res.header("Access-Control-Allow-Credentials", true);
  next();
});
app.use(bodyParser.urlencoded({ extended: "true" }));
app.use(bodyParser.json());
app.use(cookieParser());
app.use(express.json());
app.use(
  cors({
    credentials: true,
    allowedHeaders: [
      "Content-Type",
      "Authorization",
      "Access-Control-Allow-Origin",
    ],
    origin: ["http://localhost:3000"],
  })
);

app.use("/api", api);

connectDB().then(() => {
  app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}/`);
  });
});
