var Message = require('mongoose').model('Message');

module.exports = {
    send: function (request) {
        var message = {
            from: request.from,
            to: request.to,
            text: request.text
        };

        Message.create(message, function (error) {
            if (error) {
                console.log('Cannot send message: ' + error);
            }
        });
    },
    get: function (request, callback) {
        Message.find()
            .or([{from: request.personA, to: request.personB}, {from: request.personB, to: request.personA}])
            .exec(function (error, messages) {
                if (error) {
                    console.log('Cannot find messages: ' + error);
                    return;
                }

                callback(messages);
        });
    }
};