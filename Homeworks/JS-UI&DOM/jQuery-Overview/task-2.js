function solve() {
    var CONST = {
            selector: {
                button: '.button',
                content: '.content'
            },
            class: {
                content: 'content',
                button: 'button'
            },
            buttonInnerHTML: {
                onHidden: 'show',
                onVisible: 'hide'
            },
            display: {
                hidden: 'none',
                visible: ''
            }
        },
        validator = {
            getValidElement: function(selector){
                if(typeof selector !== 'string' || !$(selector).size()){
                    throw {
                        name: 'InvalidSelectorError',
                        message: 'InvalidSelectorError'
                    };
                }

                return $(selector);
            }
        };

    var buttonEvent = function () {
        $(this).text(CONST.buttonInnerHTML.onVisible)
            .click(function(){
                var $clicked = $(this),
                    $content,
                    canToggleVisibility,
                    $nextElement = $clicked.next();

                while($nextElement){
                    if($nextElement.hasClass(CONST.class.content)){
                        $content = $nextElement;
                        $nextElement = $nextElement.next();
                        while($nextElement){
                            if($nextElement.hasClass(CONST.class.button)){
                                canToggleVisibility = true;
                                break;
                            }
                            $nextElement = $nextElement.next();
                        }
                        break;
                    } else {
                        $nextElement = $nextElement.next();
                    }
                }

                if (canToggleVisibility) {
                    if ($content.css('display') === CONST.display.hidden) {
                        $clicked.text('hide');
                        $content.css('display', CONST.display.visible);
                    } else {
                        $clicked.text('show');
                        $content.hide();
                    }
                }

            });
    };

    return function (selector) {
        validator.getValidElement(selector)
            .children(CONST.selector.button)
            .each(buttonEvent);
    };
}

module.exports = solve;