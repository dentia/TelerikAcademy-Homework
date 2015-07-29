/* globals $ */

/* 
 Create a function that takes an id or DOM element and an array of contents
 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neight `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {

    return function (element, contents) {
        /* globals $ */

        /*

         Create a function that takes an id or DOM element and an array of contents

         * if an id is provided, select the element
         * Add divs to the element
         * Each div's content must be one of the items from the contents array
         * The function must remove all previous content from the DOM element provided
         * Throws if:
         * The provided first parameter is neither string or existing DOM element
         * The provided id does not select anything (there is no element that has such an id)
         * Any of the function params is missing
         * Any of the function params is not as described
         * Any of the contents is neight `string` or `number`
         * In that case, the content of the element **must not be** changed
         */

        module.exports = function () {
            function validateParameter (parameter) {
                if(parameter === undefined || parameter === null){
                    throw {
                        name: 'InvalidArgumentError',
                        message: 'InvalidArgumentError'
                    };
                }
            }

            function validateContents (contents) {
                var ind, len;

                if(!Array.isArray(contents)){
                    throw {
                        name: 'InvalidArgumentPassed',
                        message: 'InvalidArgumentPassed'
                    };
                }

                for(ind = 0, len = contents.length; ind < len; ind += 1){
                    validateContent(contents[ind]);
                }

                function validateContent (content) {
                    if(typeof content !== "string" && typeof content !== "number"){
                        throw {
                            name: 'InvalidContentError',
                            message: 'InvalidContentError'
                        };
                    }
                }
            }

            function getValidElement (element) {
                if(typeof element === "string"){
                    element = document.getElementById(element);
                }

                if(!(element instanceof HTMLElement)){
                    throw {
                        name: 'InvalidElementPassed',
                        message: 'InvalidElementPassed'
                    };
                }

                return element;
            }

            function appendContentsToElement (element, contents) {
                var div, fragment, ind, len, divToBeAdded;

                element.innerHTML = '';
                div = document.createElement('div');
                fragment = document.createDocumentFragment();

                for(ind = 0, len = contents.length; ind < len; ind += 1){
                    divToBeAdded = div.cloneNode(true);
                    divToBeAdded.innerHTML = contents[ind];
                    fragment.appendChild(divToBeAdded);
                }

                element.appendChild(fragment);
            }

            return function (element, contents) {
                validateParameter(element);
                validateParameter(contents);
                validateContents(contents);
                element = getValidElement(element);
                appendContentsToElement(element, contents);
            };
        };
    };
};