(function () {
    var canvas = document.getElementById('canvas'),
        ctx = canvas.getContext('2d'),
        width = 700,
        height = 700,
        cellSize = 20,
        initialSnakeLength = 5,
        food = {x: -1, y: -1},
        snake,
        dir,
        directions = {
            left: {x: -cellSize, y: 0},
            down: {x: 0, y: cellSize},
            right: {x: cellSize, y: 0},
            up: {x: 0, y: -cellSize}
        },
        game,
        colors = ['red', 'black', 'blue', 'green', 'purple'];

    ctx.font = '23px Consolas';
    ctx.lineWidth = 3;


    function init () {
        var color = colors[Math.floor((Math.random() * colors.length))];
        ctx.fillStyle = color;
        ctx.strokeStyle = color;

        snake = getSnake(initialSnakeLength);
        dir = 'right';
        if(typeof game != "undefined") {
            clearInterval(game);
        }
        game = setInterval(function(){
            try{
                update();
            } catch(e){
                getHighScore();
                init();
            }
        }, 80);
    }

    init();

    document.onkeydown = function(e) {
        if (e.keyCode === 37) {
            dir = 'left';
        } else if (e.keyCode === 38) {
            dir = 'up';
        } else if (e.keyCode === 39) {
            dir = 'right';
        } else if (e.keyCode === 40) {
            dir = 'down';
        }
    };

    function hasCoordinates(array, x, y){
        return array.some(function(element){
            return element.x == x && element.y == y;
        });
    }

    function updateSnake () {
        var head = snake[0],
            nextElement = {
                x: head.x + directions[dir].x,
                y: head.y + directions[dir].y
            };

        snake.pop();

        if(hasCoordinates(snake, nextElement.x, nextElement.y)){
            throw {
                name: 'SnakeBitItself',
                message: 'SnakeBitItself'
            };
        }

        if(nextElement.x < 0 || nextElement.x >= width ||
            nextElement.y < 0 || nextElement.y >= height){
            throw {
                name: 'SnakeOutOfRange',
                message: 'SnakeOutOfRange'
            };
        }

        snake.unshift(nextElement);
    }

    function updateFood () {
        if(food.x === -1){
            do{
                food.x = Math.floor((Math.random() * width/cellSize)) * cellSize;
                food.y = Math.floor((Math.random() * height/cellSize)) * cellSize;
            } while(hasCoordinates(snake, food.x, food.y));
        }
    }

    function checkIfEaten () {
        var head = snake[0];

        if(head.x == food.x && head.y == food.y){
            snake.push({
                x: food.x,
                y: food.y
            });

            food.x = -1;
            food.y = -1;
        }
    }

    function paint () {
        ctx.clearRect(0, 0, width, height);

        if(food.x != -1) {
            ctx.fillRect(food.x, food.y, cellSize, cellSize);
        }

        snake.forEach(function(element){
            ctx.strokeRect(element.x, element.y, cellSize, cellSize);
        });

        ctx.fillText('Score: ' + ((snake.length - initialSnakeLength) * 10), 10, 690);
    }

    function update () {
        updateFood();
        updateSnake();
        checkIfEaten();
        paint();
    }

    function getSnake (length) {
        var snake = [];

        for (var x = length; x > 0; x--) {
            snake.push({
                x: x * cellSize,
                y: cellSize
            });
        }

        return snake;
    }

    function getHighScore(){
        var str = window.prompt('Enter your nickname', 'anonymous'),
            score = (snake.length - initialSnakeLength) * 10;
        localStorage.setItem(str, score + 10);

        var ul = document.getElementById('highscores');
        li = document.createElement('li');

        li.innerHTML = str + ' - ' + (score + 10);
        ul.appendChild(li);
    }
}());