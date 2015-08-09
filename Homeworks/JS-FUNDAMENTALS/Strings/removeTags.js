// Write a function that extracts the content of a html
// page given as text. The function should return
// anything that is in a tag, without the tags

var html = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';
var text = getText(html);
console.log(text);

function getText(html) {
    return html.replace(/<[^>]*>/g, '');
}