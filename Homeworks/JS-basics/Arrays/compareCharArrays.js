// Write a script that compares two char arrays
// lexicographically (letter by letter).

Array.prototype.compareLexicographically = function (arr){
    for(var ind = 0; ind < Math.min(this.length, arr.length); ind++){
        if(arr[ind] !== this[ind]){
            return this[ind] < arr[ind] ? -1 : 1;
        }
    }

    if(this.length != arr.length){
        this.length < arr.length ? -1 : 1;
    }

    return 0;
}

var a = 'abc'.split(''), b = 'acb'.split('');

console.log(a.compareLexicographically(b));


