// Sort 3 real values in descending order using nested if statements.

console.log(sortThree(5, 1, 2));
console.log(sortThree(-2, -2, 1));
console.log(sortThree(-2, 4, 3));
console.log(sortThree(-1.1, -0.5, -0.1));

function sortThree(a, b, c) {
    var sorted = [];

    if (a >= b) {
        if (b >= c) {
            sorted.push(a, b, c);
        } else if (c > a) {
            sorted.push(c, a, b);
        } else {
            sorted.push(a, c, b);
        }
    } else {
        if (b >= c) {
            if (c >= a) {
                sorted.push(b, c, a);
            } else {
                sorted.push(b, a, c);
            }
        } else {
            sorted.push(c, b, a);
        }
    }

    return sorted.join(' ');
};