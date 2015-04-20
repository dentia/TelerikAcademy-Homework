// Write a function that finds all the occurrences of
// word in a text
// ? The search can case sensitive or case insensitive
// ? Use function overloading

var text = 'asd ASD asd Asd ASd AsD asD asd asd';
console.log(countOccurrence(text, 'asd', false));
console.log(countOccurrence(text, 'asd', true));

function countOccurrence(text, word, isCaseSensitive){
    var replacedPunctuation = text.replace(/\W+/g, ' ');

    if(!isCaseSensitive){
        replacedPunctuation = replacedPunctuation.toLowerCase();
        word = word.toLowerCase();
    }

    var words = replacedPunctuation.split(' ');

    var occurrences = 0;

    for(var ind = 0; ind < words.length; ind++){
        if(words[ind] === word) ++occurrences;
    }

    return occurrences;
}