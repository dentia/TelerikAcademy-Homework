// Sort 3 real values in descending order using nested if statements.

var numbers = [-2, 7, 3];

numbers = sortThree(numbers);
console.log(numbers);

function sortThree(arr) {
    var a = arr[0], b = arr[1], c = arr[2];

    var sorted = [];

    if(a >= b){
        if(b >= c){
            sorted.push(a, b, c);
        }
        else if(c > a){
            sorted.push(c, a, b);
        }
        else{
            sorted.push(a, c, b);
        }
    }
    else{
        if(b >= c){
            if(c >= a){
                sorted.push(b, c, a);
            }
            else{
                sorted.push(b, a, c);
            }
        }
        else{
            sorted.push(c, b, a);
        }
    }

    return sorted;
};