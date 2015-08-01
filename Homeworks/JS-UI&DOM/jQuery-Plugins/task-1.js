function solve(){
    var CONST = {
        selector: {
            createDiv: '<div />'
        },
        option: {
            default: 'Select a value'
        },
        class: {
            dropdownDiv: 'dropdown-list',
            current: 'current',
            optionsContainer: 'options-container',
            dropdownItem: 'dropdown-item'
        }
    };

    return function(selector){
        var $dropdown = $(CONST.selector.createDiv)
                .addClass(CONST.class.dropdownDiv),
            $select = $(selector)
                .hide()
                .appendTo($dropdown),
            $currentOption = $(CONST.selector.createDiv)
                .addClass(CONST.class.current)
                .text(CONST.option.default)
                .appendTo($dropdown),
            $optionsContainer = $(CONST.selector.createDiv)
                .addClass(CONST.class.optionsContainer)
                .css('position', 'absolute')
                .hide()
                .appendTo($dropdown);


        $select.find('option').each(function(index){
            var $this = $(this);

            $(CONST.selector.createDiv)
                .appendTo($optionsContainer)
                .addClass(CONST.class.dropdownItem)
                .attr('data-value', $this.val())
                .attr('data-index', index)
                .text($this.text())
                .click(function(){
                    $currentOption.val($this.val());
                    $currentOption.text($this.text());
                    $optionsContainer.hide();

                    $select.val($this.val());
                });
        });

        $currentOption.click(function(){
            $optionsContainer.toggle();
            $currentOption.text('Select a value');
        });

        $('body').append($dropdown);
    };
}
module.exports = solve;