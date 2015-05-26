// Write a JavaScript function that finds how many
// times a substring is contained in a given text
// (perform case insensitive search).

var text = 'We are living in an yellow submarine. We don\'t have anything else. ' +
    'Inside the submarine is very tight. So we are drinking all the day. ' +
    'We will move out of it in 5 days.';

console.log(getOccurrenceCount(text, 'in'));

function getOccurrenceCount(text, word){
    var regex = new RegExp(word, 'gi');
    return (text.match(regex)).length;
}

