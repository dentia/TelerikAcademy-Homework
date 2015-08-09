String.prototype.format = function(options) {
    var option,
        regex,
        formatted = this;
  for (option in options) {
      regex = new RegExp('#{' + option + '}', 'g');
      formatted = formatted.replace(regex, options[option]);
  }

    return formatted;
};


console.log('Hello, there! Are you #{name}?'.format({name: 'John'}));
console.log('My name is #{name} and I am #{age}-years-old'.format({name: 'John', age: 13}));
