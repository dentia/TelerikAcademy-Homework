// Write a script that selects all the div nodes that are
// directly inside other div elements
// ? Create a function using querySelectorAll()
// ? Create a function using getElementsByTagName()

function getUsingQuery(){
    var divs = document.querySelectorAll('div>div');
    for(var div in divs){
        divs[div].style.backgroundColor = '#FFD800';
        divs[div].style.color = '#404040';
    }
}

function getByTag(){
    var divs = document.getElementsByTagName('div');

    for(var ind = 0; ind < divs.length; ind++){
        if(divs[ind].parentElement instanceof HTMLDivElement){
            divs[ind].style.backgroundColor = '#B6FF00';
            divs[ind].style.color = '#424242';
        }
    }
}

