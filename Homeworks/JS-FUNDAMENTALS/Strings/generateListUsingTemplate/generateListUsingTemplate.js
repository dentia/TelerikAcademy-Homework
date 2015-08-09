// Write a function that creates a HTML UL using a
// template for every HTML LI. The source of the list
// should an array of elements. Replace all
// placeholders marked with –{…}– with the value of
// the corresponding property of the object.

// to view the result, start index.html and click the 'Generate List' button

var people = [
    {name: 'Nikolay', age: 24},
    {name: 'Ivaylo', age: 25},
    {name: 'Doncho', age: 25},
    {name: 'Evlogi', age: 32},
    {name: 'Nikolay', age: 31}],
	template = document.getElementById('list-item').innerHTML;

function generateList() {
    var ul = document.createElement('ul');

    for (var ind in people) {
        var li = document.createElement('li');
        li.innerHTML = format(template, people[ind]);
        ul.appendChild(li);
    }
    document.body.appendChild(ul);
};

function format(string, person){
    return string.replace(/\-{(\w+)\}-/g, function (match, prop) {
        return person[prop] || '';
    });
}