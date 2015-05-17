function shimCreateStyleSheet(){
    document.createStyleSheet = function(){
        var linkTag = document.createElement ("link");
        linkTag.href = "style.css";
        linkTag.rel = "stylesheet";
        var head = document.getElementsByTagName ("head")[0];
        head.appendChild (linkTag);

        var sheet = document.styleSheets[document.styleSheets.length - 1];

        if (!sheet.addRule) {
            sheet.addRule = function addRule(selectorText, cssText, index) {
                if (!index)
                    index = this.cssRules.length;

                this.insertRule(selectorText + ' {' + cssText + '}', index);
            }
        }
        if (!sheet.removeRule) {
            sheet.removeRule = sheet.deleteRule;
        }
        return sheet;
    }
}

// IE7 support for querySelectorAll in 274 bytes.
// Supports multiple / grouped selectors and the attribute selector with a "for" attribute.
// http://www.codecouch.com/
function shimQuerySelectorAll() {
    document.querySelectorAll = function (query) {
        query = query.replace(/\[for\b/gi, '[htmlFor').split(',');

        for (var i = query.length; i--;) {
            styleSheet.addRule(query[i], 'selector:css');

            for (var j = allElements.length; j--;) {
                allElements[j].currentStyle.selector && collection.push(allElements[j]);
            }

            styleSheet.removeRule(0);
        }

        return collection.reverse();
    }
}

function shimQuerySelector() {
    document.querySelector = function (query) {
        var result = this.querySelectorAll(query);
        return result[0] ? result[0] : null;
    }
}

if(!document.querySelectorAll){

    if(!document.createStyleSheet){
        shimCreateStyleSheet();
    }
    var styleSheet = document.createStyleSheet();
    var allElements = document.all, collection = [];

    shimQuerySelectorAll();
    shimQuerySelector();

    console.log('querySelector & querySelectorAll shim added');
}