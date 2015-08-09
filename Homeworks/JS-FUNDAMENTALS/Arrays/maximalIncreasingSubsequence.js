// Write a script that finds the maximal increasing
// sequence in an array. Example:
// {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

var sequence = [3, 2, 3, 4, 2, 2, 4];

console.log(getMaxIncreasingSequence(sequence).join(', '));

function getMaxIncreasingSequence(arr) {
    var best = [arr[0]],
		tmp = [arr[0]];

    for (var ind = 1; ind < arr.length; ind++) {
        if (arr[ind] > arr[ind - 1]) {
            tmp.push(arr[ind]);
        } else {
            tmp = [arr[ind]];
        }

        if (tmp.length > best.length) {
            best = tmp;
        }
    }

    return best;
}