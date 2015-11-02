var app = Sammy('#result', function () {

    this.get('#/', function () {
        $('#result').text('');
        $('#requests').text('');
    });

    this.get('#/songs', songsController.all);
    this.get('#/artists', artistsController.all);
    this.get('#/albums', albumsController.all);
});

app.run('#/');