var albumsController = function () {

    function all() {
        $.get('Views/albumsRequests.html', function (data) {
            $('#requests').html(data);
        });
    }

    return {
        all: all
    };
}();