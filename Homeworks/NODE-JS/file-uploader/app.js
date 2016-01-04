(function() {
    'use strict';

    var formidable = require('formidable'),
        http = require('http'),
        util = require('util'),
        fs = require('fs-extra'),
        url = require('url'),
        uuid = require('node-uuid'),
        port = 8080;

// create server
    http.createServer(function(req, res) {
        var queryData = url.parse(req.url, true).query;

        if(queryData.id) {
            var dir = __dirname + '/uploads/' + queryData.id + '/';

            try {
                if (fs.statSync(dir)) {
                    var files = fs.readdirSync(dir),
                        file;

                    for (var i in files) {
                        file = files[i];
                        break;
                    }

                    res.writeHead(200, {
                        'Content-disposition': 'attachment; filename=' + file,
                        'content-type': 'text/html'
                    });
                    res.write(file, 'binary');
                    res.end();
                }
            } catch(e) {
                console.error('No such file exists');
            }
        }

        if (req.url == '/upload' && req.method.toLowerCase() == 'post') {

            var form = new formidable.IncomingForm();
            var guid = uuid.v1();

            form.parse(req, function(err, fields, files) {
                res.writeHead(200, {'content-type': 'text/html'});
                res.write('<h4>Upload received!</h4>');
                res.write('<div><h4 style="display: inline; margin-right: 5px">Project GUID:</h4>' +
                    '<h2 style="display: inline">' + guid + '</h2></div>');
                res.end('<a href="/">Go back</a>');
            });
            form.on('end', function(fields, files) {
                var temp_path = this.openedFiles[0].path;
                var file_name = this.openedFiles[0].name;
                var new_location = __dirname + '/uploads/' + guid + '/';
                fs.copy(temp_path, new_location + file_name, function(err) {
                    if (err) {
                        console.error(err);
                    } else {
                        console.log("success!")
                    }
                });
            });
            return;
        }

        res.writeHead(200, {'content-type': 'text/html'});
        res.end(
            '<div><input type="text" id="id" placeholder="Enter file GUID" style="width: 350px">' +
            '<button onclick="window.location = \'/?id=\' + document.getElementById(\'id\').value">Download</button></div>' +
            '<span style="font-size: 10px">Disclaimer: If you enter invalid GUID, nothing will happen</span>' +
            '<hr />'+
            '<form action="/upload" method="post" enctype="multipart/form-data">'+
            '<input type="file" name="upload" multiple="multiple"><br>'+
            '<input type="submit" value="Upload">'+
            '</form>'
        );
    }).listen(port);
    console.info('App running on localhost:' + port);
}());
