// Write an expression that checks for given point (x, y)
// if it is within the circle K( (1,1), 3) and out of the
// rectangle R(top=1, left=-1, width=6, height=2).

var rectangle = [1, -1, -1, 5], circle = [1, 1, 3], pointTrue = [2, 2], pointFalse = [1, 1];

console.log(fitsConditions(pointTrue[0], pointTrue[1]));
console.log(fitsConditions(pointFalse[0], pointFalse[1]));

function fitsConditions(x, y){
	return (isInsideCircle(x, y, circle[0], circle[1], circle[2]) &&
			isOutsideRectangle(x, y, rectangle[0], rectangle[1], rectangle[2], rectangle[3])) ? 'yes' : 'no';
}
		 
function isInsideCircle(x, y, cx, cy, r){
    return (x - cx) * (x - cx) + (y - cy) * (y - cy) < r * r;
}

function isOutsideRectangle(x, y, top, bottom, left, right){
    return !(x >= left && x <= right && y <= top && y >= bottom);
}