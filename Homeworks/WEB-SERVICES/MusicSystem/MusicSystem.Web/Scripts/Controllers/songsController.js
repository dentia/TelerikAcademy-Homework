var songsController = function () {
    function all(context) {
        $.get('Views/songsRequests.html', function (data) {
            $('#requests').html(data);
        });
    }

    return {
        all: all
    };
}();