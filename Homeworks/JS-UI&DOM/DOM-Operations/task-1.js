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