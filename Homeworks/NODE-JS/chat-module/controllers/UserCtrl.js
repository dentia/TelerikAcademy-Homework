var User = require('mongoose').model('User');

module.exports = {
    register: function (req, res) {
        var user = {
            username: req.username
        };

        User.create(user, function (error, user) {
            if (error) {
                console.error('Cannot create a user: ' + error);
            }
        });
    }
};