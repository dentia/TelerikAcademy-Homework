var mongoose = require('mongoose');

var userSchema = mongoose.Schema({
    username: {
        type: String,
        required: true,
        unique: true
    }
});

mongoose.model('User', userSchema);