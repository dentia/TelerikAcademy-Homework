function changeImage(img) {
    window.document.getElementById("zoomedImage").src = "images/cat" + img + ".jpg";
    window.document.getElementById("zoomedImage").style.width = "600px";
    window.document.getElementById("zoomedImage").style.height = "445px";
}