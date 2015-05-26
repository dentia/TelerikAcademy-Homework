// Write a script that allocates array of 20 integers and
// initializes each element by its index multiplied by 5.
// Print the obtained array on the console

var products = [];

for (var ind = 0; ind < 20; ind++) {
    products.push(ind * 5);
}

console.log(products);
