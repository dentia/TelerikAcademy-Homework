// Write a function that finds all the occurrences of
// word in a text
// ? The search can case sensitive or case insensitive
// ? Use function overloading

var text = 'asd ASD asd Asd ASd AsD asD asd asd';
console.log(countOccurrence(text, 'asd', false));
console.log(countOccurrence(text, 'asd', true));

function countOccurrence(text, word, isCaseSensitive){
	var regexString = '\\b' + word + '\\b',
		modifier = isCaseSensitive ? 'g' : 'gi',
		regex = new RegExp(regexString, modifier);
		
	return text.match(regex).length;
}