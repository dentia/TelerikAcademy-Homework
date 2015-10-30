var artistsController = function () {
    function all(context) {
        $.get('Views/artistsRequests.html', function (data) {
            $('#requests').html(data);
        });
    }

    return {
        all: all
    };
}();