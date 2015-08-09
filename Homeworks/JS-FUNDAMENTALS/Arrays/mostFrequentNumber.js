// Write a program that finds the most frequent
// number in an array. Example:
// {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} ? 4 (5 times)

var numbers = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];

var mode = getMode(numbers);
console.log(mode[0] + ' (' + mode[1] + ' times)');

function getMode(arr){
    var modeMap = {},
		maxNum = arr[0], 
		maxCount = 1;

    for (var ind = 0; ind < arr.length; ind++) {
        var num = arr[ind];
		
        if (modeMap[num] == null) {
            modeMap[num] = 1;
        } else {
            modeMap[num]++;
        }

        if (modeMap[num] > maxCount) {
            maxNum = num;
            maxCount = modeMap[num];
        }
    }

    return [maxNum, maxCount];
}