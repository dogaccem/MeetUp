const mongoose = require("mongoose");

const connectDB = async () => {
  await mongoose.connect(
    "mongodb+srv://regularUser:1TUAvmul4u1gpbIB@cluster0.ijoif0u.mongodb.net/test"
  );
};

module.exports = connectDB;
