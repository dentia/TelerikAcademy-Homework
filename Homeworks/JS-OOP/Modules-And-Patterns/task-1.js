/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * // method removeAttribute(attribute)
 */


/* Example
 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');
 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)
 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');
 div.content = 'Hello, world!';
 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');
 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);
 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */


function solve() {
    var domElement = (function () {

        function isValidType(type){
            if(typeof type !== 'string'){
                throw new Error('Invalid string argument.');
            }
            
            return /^[A-Z0-9]+$/i.test(type);
        }

        function isValidAttributeName(name){
            if(typeof name !== 'string'){
                throw new Error('Invalid string argument.');
            }
            
            return /^[A-Z0-9\-]+$/i.test(name);
        }

        function getSortedAttributesString(attributes){
            var attributesString = '';
            var keys = [];

            for(var key in attributes){
                keys.push(key);
            }

            keys.sort();
            var currentKey;

            for(var ind = 0, len = keys.length; ind < len; ind += 1){
                currentKey = keys[ind];
                attributesString += ' ' + currentKey + '="' + attributes[currentKey] + '"';
            }

            return attributesString;
        }

        var domElement = {
            init: function(type) {
                this.type = type;
                this.content = '';
                this.parent;
                this.children = [];
                this.attributes = [];

                return this;
            },
            appendChild: function(child) {
                this.children.push(child);

                if(typeof child === 'object'){
                    child.parent = this;
                }
					  
                return this;
            },
            addAttribute: function(name, value) {
                if(!isValidAttributeName(name)){
                    throw new Error('Invalid attribute name.');
                }

                this.attributes[name] = value;

                return this;
            },
            removeAttribute: function(attribute) {
                if(!this.attributes[attribute]){
                    throw new Error('This attribute does not exist.');
                }

                delete this.attributes[attribute];

                return this;
            },
            get innerHTML(){
                var innerHtml = '<' + this. type;
                var attributesString = getSortedAttributesString(this.attributes);
                innerHtml += attributesString + '>';

                var child;
                for(var ind = 0, len = this.children.length; ind < len; ind += 1){
                    child = this.children[ind];

                    if(typeof child === 'string') {
                        innerHtml += child;
                    } else {
                        innerHtml += child.innerHTML;
                    }
                }

                innerHtml += this.content;
                innerHtml += '</' + this.type + '>';

                return innerHtml;
            },
            get type(){
                return this._type;
            },
            set type(value){
                if(!isValidType(value)){
                    throw new Error('Invalid type.');
                }

                this._type = value;
            },
            get content(){
                if(this.children.length){
                    return '';
                }

                return this._content;
            },
            set content(value){
                this._content = value;
            },
            get attributes(){
                return this._attributes;
            },
            set attributes(value){
                this._attributes = value;
            },
            get children(){
                return this._children;
            },
            set children(value){
                this._children = value;
            },
            get parent(){
                return this._parent;
            },
            set parent(value){
                this._parent = value;
            }

        };
        return domElement;
    } ());
    return domElement;
}