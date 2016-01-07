var chatDb = require('./chat-db');

chatDb.init();
chatDb.registerUser({ username: 'NikiIT'});
chatDb.registerUser({ username: 'IvoK'});

chatDb.sendMessage({
    from: 'IvoK',
    to: 'NikiIT',
    text: 'Niama kak da znam kakvo e za vylka gorata'
});

chatDb.sendMessage({
    from: 'NikiIT',
    to: 'IvoK',
    text: 'Ne moga i za ribata da znam kakvo e vodata'
});

chatDb.sendMessage({
    from: 'IvoK',
    to: 'NikiIT',
    text: 'Ne znam za oblacite kakvo sa nebesata'
});

chatDb.sendMessage({
    from: 'IvoK',
    to: 'NikiIT',
    text: 'I slynceto ne znam kak gleda na lunata'
});

chatDb.sendMessage({
    from: 'NikiIT',
    to: 'IvoK',
    text: 'Vratata moje li da syshtestvuva bez stenata?'
});

// otherwise the script may execute before all messages are saved in the db
console.info('gathering info right now...');
setTimeout(function () {
    chatDb.getMessages({
        personA: 'NikiIT',
        personB: 'IvoK'
    });
}, 1000);