var simpleNote = angular.module('smalldata', ['ui.bootstrap', 'ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/Note/Save', { templateUrl: '/Note/Save', controller: 'noteController' });
        $locationProvider.html5Mode(true);
    });