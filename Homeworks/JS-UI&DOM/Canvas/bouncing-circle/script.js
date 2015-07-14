(function () {
    var canvas = document.getElementById('canvas'),
        ctx = canvas.getContext('2d'),
        smallBall,
        mediumBall,
        largeBall,
        Ball,
        balls;

    Ball = (function () {
        var ball = {
            init: function(radius, x, y, xChange, yChange, color){
                this.radius = radius;
                this.x = x;
                this.y = y;
                this.xChange = xChange;
                this.yChange = yChange;
                this.color = color;

                return this;
            },
            checkDirection: function () {
                if(this.x + this.xChange + this.radius > canvas.width || this.x - this.radius + this.xChange < 0){
                    this.xChange *= -1;
                }

                if(this.y + this.radius + this.yChange > canvas.height || this.y - this.radius + this.yChange < 0){
                    this.yChange *= -1;
                }

                return this;
            },
            update: function () {
                this.x += this.xChange;
                this.y += this.yChange;

                return this;
            },
            print: function () {
                ctx.fillStyle = this.color;
                ctx.beginPath();
                ctx.arc(this.x, this.y, this.radius, 0, 2 * Math.PI);
                ctx.closePath();
                ctx.fill();

                return this;
            }
        };

        return ball;
    }());

    smallBall = Object.create(Ball).init(15, 15, canvas.height / 2, 9, 9, '#42DD00');
    mediumBall = Object.create(Ball).init(22, 22, canvas.height / 2, 7, 7, '#0094FF');
    largeBall = Object.create(Ball).init(30, 30, canvas.height / 2, 5, 5, '#FF6A00');
    balls = [largeBall, mediumBall, smallBall];

    function animationFrame () {
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        for (var ind = 0; ind < balls.length; ind++) {
            balls[ind].checkDirection().update().print();
        }

        requestAnimationFrame(animationFrame);
    }

    animationFrame();
    
}());
