// Write a function that replaces non breaking whitespaces
// in a text with &nbsp;

var text = 'We are   living in a yellow submarine. We don\'t have anything   else.';

text = replaceAll(text, ' ', '&nbsp;');
console.log(text);

function replaceAll (text, toReplace, replacement) {
    var regex = new RegExp(toReplace, 'gi');
    return text.replace(regex, replacement);
}