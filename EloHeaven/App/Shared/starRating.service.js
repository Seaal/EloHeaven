(function () {
	'use strict';

	angular
		.module("seaal")
		.factory("starRatingService", starRatingSerivce);

	function starRatingSerivce() {

	    return {
	        getRatingText: getRatingText,
	        getStars: getStars
	    }

	    function getRatingText(rating) {

	        rating = Math.floor(rating);

	        switch (rating) {
	            case 0:
	                return "Unrated";
	            case 1:
	                return "Poor";
	            case 2:
	                return "Average";
	            case 3:
	                return "Good";
	            case 4:
	                return "Very Good";
	            case 5:
	                return "Excellent!";
	            default:
	                return "";
	        }
	    }

	    function getStars(rating) {

	        //Multiply the rating by 2 to get it at the correct resolution for figuring out half stars
	        rating *= 2;

	        rating = Math.floor(rating);

	        var fullStars = Math.floor(rating / 2);

	        var halfStar = rating % 2;

	        var stars = [];

	        for (var i = 0; i < fullStars; i++) {
	            stars.push({ full: true });
	        }

	        if (halfStar) {
	            stars.push({ half: true });
	        }

	        for (var i = stars.length; i < 5; i++) {
	            stars.push({ empty: true });
	        }

	        return stars;
	    }
	}
})();