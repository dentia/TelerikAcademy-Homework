function solve(){
    return function(){
        $.fn.listview = function(data){
            var $this = $(this),
                templateSelector = '#' + $this.attr('data-template'),
                templateHtml = $(templateSelector).html(),
                template = handlebars.compile(templateHtml),
                ind, len;

            for(ind = 0, len = data.length; ind < len; ind += 1) {
                $this.append(template(data[ind]));
            }

            return this;
        };
    };
}

module.exports = solve;