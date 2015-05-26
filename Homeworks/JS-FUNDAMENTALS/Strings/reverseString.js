// Write a JavaScript function reverses string and returns it
// Example: "sample" ? "elpmas"

console.log(reverse('sample'));
console.log(reverse('reverse'));

function reverse(string) {
    var reversed = [];

    for (var ind = string.length - 1; ind >= 0; ind--) {
        reversed.push(string[ind]);
    }

    return reversed.join('');
}