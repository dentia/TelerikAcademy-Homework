(function () {
    var canvas = document.getElementById('canvas'),
        ctx = canvas.getContext('2d'),
        drawHouseButton = document.getElementById('drawHouse'),
        drawBicycleButton = document.getElementById('drawBicycle'),
        drawPersonButton = document.getElementById('drawPerson');

    drawHouseButton.addEventListener('click', drawHouse);
    drawBicycleButton.addEventListener('click', drawBike);
    drawPersonButton.addEventListener('click', drawPerson);

    (function () {
        ctx.font = '27px Arial';
        ctx.fillText('\tSelect a figure to print', 110, 200);
        ctx.fillText('using the buttons below.', 110, 250);
    }());

    function getRadians(degrees){
        return degrees * Math.PI / 180;
    }

    function drawWindow(x, y, width, height, margin, color){
        ctx.fillStyle = color;
        ctx.fillRect(x, y, width, height);
        ctx.fillRect(x + width + margin, y, width, height);
        ctx.fillRect(x, y + height + margin, width, height);
        ctx.fillRect(x + width + margin, y + height + margin, width, height);
    }

    function drawRoof(startX, endX, startY, endY, strokeColor, fillColor){
        var middleX = startX + ((endX - startX) / 2);

        ctx.strokeStyle = strokeColor;
        ctx.fillStyle = fillColor;
        ctx.lineWidth = 6;

        ctx.beginPath();
        ctx.moveTo(startX, startY);
        ctx.lineTo(middleX, endY);
        ctx.lineTo(endX, startY);
        ctx.closePath();

        ctx.stroke();
        ctx.fill();
    }

    function drawBase(x, y, width, height, strokeColor, fillColor){
        ctx.strokeStyle = strokeColor;
        ctx.fillStyle = fillColor;
        ctx.lineWidth = 3;

        ctx.fillRect(x, y, width, height);
        ctx.strokeRect(x, y, width, height);
    }

    function drawDoor(startX, endX, startY, endY, curveY, strokeColor){
        var middleX = startX + ((endX - startX) / 2),
            leftKnobX = startX + ((middleX - startX) / 2),
            rightKnobX = middleX + ((endX - middleX) / 2),
            knobY = startY - curveY;

        ctx.strokeStyle = strokeColor;
        ctx.lineWidth = 3;

        ctx.beginPath();

        ctx.moveTo(startX, startY);
        ctx.lineTo(startX, endY);
        ctx.bezierCurveTo(startX, endY - curveY, endX, endY - curveY, endX, endY);
        ctx.lineTo(endX, startY);

        ctx.moveTo(middleX, endY - curveY / 1.4);
        ctx.lineTo(middleX, startY);
        ctx.closePath();

        ctx.stroke();

        ctx.beginPath();
        ctx.arc(leftKnobX, knobY, 3, 0, getRadians(360));
        ctx.closePath();
        ctx.stroke();

        ctx.beginPath();
        ctx.arc(rightKnobX, knobY, 3, 0, getRadians(360));
        ctx.closePath();
        ctx.stroke();
    }

    function drawChimney(x, y, width, height, curveY, strokeColor, fillColor){
        var middleX = x + ( width / 2);

        ctx.strokeStyle = strokeColor;
        ctx.fillStyle = fillColor;
        ctx.lineWidth = 3;

        ctx.beginPath();
        ctx.moveTo(x, y);
        ctx.lineTo(x, y - height);
        ctx.lineTo(x + width, y - height);
        ctx.lineTo(x + width, y);
        ctx.closePath();
        ctx.fill();

        ctx.beginPath();
        ctx.moveTo(x, y);
        ctx.lineTo(x, y - height);
        ctx.closePath();
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x + width, y);
        ctx.lineTo(x + width, y - height);
        ctx.closePath();
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x - 1, y - height);
        ctx.quadraticCurveTo(middleX, y - height + curveY, x + width - 1, y - height);
        ctx.quadraticCurveTo(middleX, y - height - curveY, x, y - height);

        ctx.stroke();
        ctx.fill();
    }

    function drawTire(x, y, r, strokeColor, fillColor){
        ctx.lineWidth = 3;
        ctx.strokeStyle = strokeColor;
        ctx.fillStyle = fillColor;

        ctx.beginPath();

        ctx.arc(x, y, r, 0, getRadians(360));

        ctx.fill();
        ctx.stroke();

        ctx.closePath();
    }

    function drawFrame(leftTireX, leftTireY, rightTireX, rightTireY, tireRadius, strokeColor){
        var lowerFrameAngleX = leftTireX + (rightTireX - leftTireX) / 2,
            lowerFrameAngleY = leftTireY,
            upperFrameAngleX = leftTireX + tireRadius * 1.2,
            upperFrameAngleY = rightTireY - tireRadius * 1.2,
            quarterRadius = tireRadius * 0.25;

        ctx.lineWidth = 3;
        ctx.strokeStyle = strokeColor;

        // main frame
        ctx.beginPath();
        ctx.moveTo(leftTireX, leftTireY);
        ctx.lineTo(lowerFrameAngleX, lowerFrameAngleY);
        ctx.lineTo(rightTireX - tireRadius / 5, rightTireY - tireRadius * 1.2);
        ctx.lineTo(upperFrameAngleX, upperFrameAngleY);
        ctx.closePath();
        ctx.stroke();

        // lower to upper frame angle + seat
        ctx.beginPath();
        ctx.moveTo(lowerFrameAngleX, lowerFrameAngleY);
        ctx.lineTo(upperFrameAngleX - quarterRadius, upperFrameAngleY - quarterRadius);
        ctx.moveTo(upperFrameAngleX - tireRadius * 0.75, upperFrameAngleY - quarterRadius);
        ctx.lineTo(upperFrameAngleX + tireRadius * 0.5  , upperFrameAngleY - quarterRadius);
        ctx.closePath();
        ctx.stroke();

        // steering
        ctx.beginPath();
        ctx.moveTo(rightTireX, rightTireY);
        ctx.lineTo(rightTireX - quarterRadius, rightTireY - tireRadius * 2);
        ctx.lineTo(rightTireX - tireRadius * 0.75, rightTireY - tireRadius * 1.8);
        ctx.moveTo(rightTireX - quarterRadius, rightTireY - tireRadius * 2);
        ctx.lineTo(rightTireX + quarterRadius, rightTireY - tireRadius * 2.3);
        ctx.closePath();
        ctx.stroke();

        // pedals
        ctx.beginPath();
        ctx.arc(lowerFrameAngleX, lowerFrameAngleY, quarterRadius, 0, getRadians(360));
        ctx.moveTo(lowerFrameAngleX + quarterRadius - getRadians(180), lowerFrameAngleY + quarterRadius - getRadians(180));
        ctx.lineTo(lowerFrameAngleX + tireRadius * 0.45, lowerFrameAngleY + tireRadius * 0.45);
        ctx.moveTo(lowerFrameAngleX - quarterRadius + getRadians(180), lowerFrameAngleY - quarterRadius + getRadians(180));
        ctx.lineTo(lowerFrameAngleX - tireRadius * 0.45, lowerFrameAngleY - tireRadius * 0.45);
        ctx.closePath();
        ctx.stroke();
    }

    function drawFace(x, y, r, strokeColor, fillColor){
        ctx.strokeStyle = strokeColor;
        ctx.fillStyle = fillColor;
        ctx.lineWidth = 3;

        ctx.beginPath();
        ctx.arc(x, y, r, 0, getRadians(360));
        ctx.fill();
        ctx.stroke();

        // nose
        ctx.beginPath();
        ctx.moveTo(x - r * 0.25, y - r * 0.25);
        ctx.lineTo(x - r * 0.5, y + r * 0.25);
        ctx.lineTo(x - r * 0.25, y + r * 0.25);
        ctx.stroke();

        // mouth
        ctx.save();
        ctx.lineWidth = 5;
        ctx.beginPath();
        ctx.setTransform(1.5, 0.2, 0, 0.25, -70, 220);
        ctx.arc(x - r / 2, y + r, r * 0.25, 0, getRadians(360));
        ctx.stroke();
        ctx.restore();

        function makeEye(eyeX, eyeY, radius){
            ctx.save();
            ctx.beginPath();
            ctx.scale(1, 0.6);
            ctx.arc(eyeX, eyeY, radius, 0, getRadians(360));
            ctx.stroke();
            ctx.closePath();
            ctx.restore();
        }

        function makePupil(x, y, radius){
            ctx.save();
            ctx.beginPath();
            ctx.scale(0.5, 1);
            ctx.arc(x, y, radius, 0, getRadians(360));
            ctx.fillStyle = strokeColor;
            ctx.fill();
            ctx.stroke();
            ctx.closePath();
            ctx.restore();
        }

        makeEye(x - r * 0.60, y * 1.6, 12);
        makeEye(x + r * 0.15, y * 1.6, 12);
        makePupil(x * 2.05 + r * 0.15, y - r * 0.12, 5);
        makePupil(x * 1.45 + r * 0.15, y - r * 0.12, 5);
    }

    function drawHat(x, y, width, height, strokeColor, fillColor){
        ctx.strokeStyle = strokeColor;
        ctx.fillStyle = fillColor;
        ctx.lineWidth = 3;

        ctx.save();
        ctx.beginPath();
        ctx.scale(1, 0.2);
        ctx.arc(x, y * 5, width, 0, getRadians(360));
        ctx.fill();
        ctx.stroke();
        ctx.restore();

        ctx.beginPath();
        ctx.moveTo(x - width * 0.55, y);
        ctx.quadraticCurveTo(x, y + height * 0.2, x + width * 0.55, y);
        ctx.lineTo(x + width * 0.55, y - height);
        ctx.lineTo(x - width * 0.55, y - height);
        ctx.closePath();
        ctx.fill();
        ctx.stroke();

        ctx.save();
        ctx.beginPath();
        ctx.scale(1, 0.4);
        ctx.arc(x, y * 1.32, width * 0.55, 0, getRadians(360));
        ctx.fill();
        ctx.stroke();
        ctx.restore();
    }

   function drawHouse(){
       ctx.clearRect(0, 0, canvas.width, canvas.height);

       drawBase(45, 150, 400, 300, '#000000', '#975B5B');
       drawRoof(50, 440, 148, 5, '#000000', '#975B5B');
       drawWindow(100,200,55,35, 3, '#000000');
       drawWindow(280,200,55,35, 3, '#000000');
       drawWindow(280,300,55,35, 3, '#000000');
       drawDoor(110, 200, 450, 360, 40, '#000000');
       drawChimney(360, 130, 40, 90, 10, '#000000', '#975B5B');
   }

    function drawBike(){
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        drawTire(170, 350, 60, '#337D8F', '#90CAD7');
        drawTire(370, 350, 60, '#337D8F', '#90CAD7');
        drawFrame(170, 350, 370, 350, 60, '#337D8F');
    }

    function drawPerson(){
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        drawFace(250, 300, 100, '#337D8F', '#90CAD7');
        drawHat(250, 200 + 20, 105, 100, '#262626', '#396693');
    }

}());