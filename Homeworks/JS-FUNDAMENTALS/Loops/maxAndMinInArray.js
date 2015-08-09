// Write a script that finds the max and min number from a sequence of numbers

var numbers = [33504, 15963, 94073, 56791, 81681, 4058, 68912, 40887, 60265, 8954, 70585, 84429, 16066, 30210,
    51332, 58345, 30871, 3257, 50976, 11018, 32154, 23075, 3477, 11539, 59347, 60773, 53908, 78723, 46588, 7584],
	minInd = 0,
	maxInd = 0;

for (var ind = 0; ind < numbers.length; ind++) {
    if (numbers[maxInd] < numbers[ind]) maxInd = ind;
    if (numbers[ind] < numbers[minInd]) minInd = ind;
}

console.log('min: ' + numbers[minInd]);
console.log('max: ' + numbers[maxInd]);