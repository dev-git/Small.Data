'use strict';

// Controller should be an entry point to and from your views
simpleMovie.controller("MovieController", function ($scope, $location, $log, movieRepository) {
    $scope.save = function (movie) {
        $scope.error = false;
        movieRepository.save(movie).then(
            function () {
                var newUrl = $location.protocol() + '://' + $location.host() + ':' + $location.port();
                var pathParts = $location.path().split('/');
                if (pathParts.length === 4) {
                    var newPath = pathParts[pathParts.length - 3] + '/' + pathParts[pathParts.length - 2];
                } else if (pathParts.length === 3) {
                    var newPath = pathParts[pathParts.length - 2]
                }

                $log.info('newUrl ' + newUrl + '/' + newPath + '/List');
                window.location.href = newUrl + '/' + newPath + '/List';
            },
            function () { $scope.error = true; });
    };
});