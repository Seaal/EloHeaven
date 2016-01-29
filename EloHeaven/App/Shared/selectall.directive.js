(function() {
	angular
		.module("seaal")
		.directive("seaalSelectall", function($document, $window) {
			return {
				restrict: 'A',
				link: link
			};
			
			function link(scope, element, attrs) {
				element.bind('click', select);
				
				function select() {
				    var range, selection;
  
				    if ($document[0].body.createTextRange) {
				        range = $document[0].body.createTextRange();
				        range.moveToElementText(element);
				        range.select();
				    } else if ($window.getSelection) {
				        selection = $window.getSelection();        
				        range = $document[0].createRange();
				        range.selectNodeContents(element[0]);
				        selection.removeAllRanges();
				        selection.addRange(range);
				    }
				}
			}
			
		});
})();