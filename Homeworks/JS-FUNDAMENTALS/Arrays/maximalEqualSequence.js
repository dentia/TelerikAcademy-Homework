// Write a script that finds the maximal sequence of
// equal elements in an array.
// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

var sequence = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];

console.log(getMaxEqualSequence(sequence).join(', '));

function getMaxEqualSequence(arr) {
    var best = [arr[0]],
		tmp = [arr[0]];

    for (var ind = 1; ind < arr.length; ind++) {
        if (arr[ind] !== tmp[0]) {
            tmp = [arr[ind]];
        } else {
            tmp.push(arr[ind]);
        }

        if(tmp.length > best.length){
            best = tmp;
        }
    }

    return best;
}