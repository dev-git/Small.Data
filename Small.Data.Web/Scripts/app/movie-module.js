var simpleMovie = angular.module('smalldata', ['ui.bootstrap', 'ngRoute'])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider.when('/Movie/Save', { templateUrl: '/Movie/Save', controller: 'movieController'});
        $locationProvider.html5Mode(true);
    });