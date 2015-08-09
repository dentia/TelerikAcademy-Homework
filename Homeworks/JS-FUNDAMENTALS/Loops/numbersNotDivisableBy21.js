// Write a script that prints all the numbers from 1 to
// N, that are not divisible by 3 and 7 at the same time

var n = 25;

for (var number = 1; number <= n; number++) {
    if (number % 21) { // 3 and 7 are coprime, so we can check only the remainder after division by their product
        console.log(number);
    }
}