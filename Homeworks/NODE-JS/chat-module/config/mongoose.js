var mongoose = require('mongoose'),
    User = require('../models/User'),
    Message = require('../models/Message');

module.exports = function () {
    mongoose.connect('mongodb://localhost/chat-module');

    var db = mongoose.connection;

    db.once('open', function (error) {
        if (error) {
            console.log(error);
            return;
        }

        console.log('Database up and running...');
    });

    db.on('error', function (error) {
        console.log(error);
    });
};