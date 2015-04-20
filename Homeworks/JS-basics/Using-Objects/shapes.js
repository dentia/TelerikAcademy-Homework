// Write functions for working with shapes in standard
// Planar coordinate system
// ? Points are represented by coordinates P(X, Y)
// ? Lines are represented by two points, marking their
// beginning and ending
// ? L(P1(X1,Y1), P2(X2,Y2))
// ? Calculate the distance between two points
// ? Check if three segment lines can form a triangle

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function Point(x, y){
    if(!isNumber(x) || !isNumber(y)){
        throw  new Error('X and Y should be numbers.');
    }

    if(!(this instanceof Point)){
        return new Point(x, y);
    }

    this.x = x;
    this.y = y;
}

Point.prototype.toString = function() {
    return 'P(' + this.x + ',' + this.y + ')';
};

function Line(sPoint, ePoint) {
    if (!(sPoint instanceof Point) || !(ePoint instanceof Point)) {
        throw new Error("sPoint and ePoint should be instances of Point");
    }

    if (!(this instanceof Line)) {
        return new Line(sPoint, ePoint);
    }

    this.sPoint = sPoint;
    this.ePoint = ePoint;
}

Line.prototype.getDistance = function() {
    var x = (this.sPoint.x - this.ePoint.x) * (this.sPoint.x - this.ePoint.x);
    var y = (this.sPoint.y - this.ePoint.y) * (this.sPoint.y - this.ePoint.y);

    return Math.sqrt(x + y);
};

Line.prototype.toString = function() {
    return 'L[' + this.sPoint.toString() + ',' + this.ePoint.toString() + ']';
};

function Triangle(a, b, c){
    if(!(a instanceof Line) || !(b instanceof Line) || !(c instanceof Line)){
        throw  new Error('A, B and C should be instances of Line');
    }

    if(!(this instanceof Triangle)){
        return new Triangle(a, b, c);
    }

    if(!canFormTriangle(a, b, c)){
        throw  new Error('invalid triangle');
    }

    this.a = a;
    this.b = b;
    this.c = c;
}

function canFormTriangle(a, b, c){
    return a.getDistance() < b.getDistance() + c.getDistance() &&
           b.getDistance() < c.getDistance() + a.getDistance() &&
           c.getDistance() < a.getDistance() + b.getDistance();
}