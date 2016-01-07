require('./models/User');
require('./models/Message');

var UserCtrl = require('./controllers/UserCtrl'),
    MessageCtrl = require('./controllers/MessageCtrl');

module.exports = {
    init: function () {
        require('./config/mongoose')();
    },
    registerUser: function (user) {
        UserCtrl.register(user);
    },
    sendMessage: function (messageData) {
        MessageCtrl.send(messageData);
    },
    getMessages: function (messageData) {
        MessageCtrl.get(messageData, function (messages) {
            console.log(messages.join('\n\n'));
        });
    }
};