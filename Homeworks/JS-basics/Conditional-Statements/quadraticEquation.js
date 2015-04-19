//Write a script that enters the coefficients a, b and c
// of a quadratic equation
// a*x2 + b*x + c = 0
// and calculates and prints its real roots. Note that
// quadratic equations may have 0, 1 or 2 real roots.

console.log(getRoots(1, 0, -4));
console.log(getRoots(1, 4, 4));
console.log(getRoots(3, 4, 5));

function getRoots(a, b, c){
    var D = b * b - 4 * a * c;
    if(D < 0){
        return [null];
    }
    else if(!D){
        return [getRoot(-1, D, b, a)];
    }
    else{
        return[getRoot(1, D, b, a), getRoot(-1, D, b, a)];
    }
}

function getRoot(sign, D, b, a){
    return (-b + Math.sqrt(D) * sign) / (2 * a);
}
