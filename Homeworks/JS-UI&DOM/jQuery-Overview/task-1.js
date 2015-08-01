function solve() {
    var CONST = {
        ul: {
            class: 'items-list'
        },
        li: {
            class: 'list-item',
            content: 'List item #'
        }
    },
        validator = {
        validateSelector: function(selector){
            if(typeof selector !== 'string'){
                throw {
                    name: 'InvalidSelectorError',
                    message: 'InvalidSelectorError'
                };
            }
        },
        getValidCount: function(count){
            if(count != Number(count)){
                throw {
                    name: 'IvalidCountError',
                    message: 'IvalidCountError'
                };
            }

            count = +count;

            if(count < 1){
                throw {
                    name: 'IvalidCountError',
                    message: 'IvalidCountError'
                };
            }

            return count;
        }
    };

    function getUl (count) {
        var ind, $li,
            $ul = $('<ul />').addClass(CONST.ul.class);

        for(ind = 0; ind < count; ind += 1){
            $li = $('<li />')
                    .addClass(CONST.li.class)
                    .text(CONST.li.content + ind)
                    .appendTo($ul);
        }

        return $ul;
    }

    return function (selector, count) {
        validator.validateSelector(selector);
        count = validator.getValidCount(count);
        getUl(count).appendTo(selector);
    };
}

module.exports = solve;