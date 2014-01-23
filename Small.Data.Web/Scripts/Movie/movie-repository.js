'use strict';

simpleMovie.factory('movieRepository', function ($http, $q, $log) {
    return {
        save: function (movie) {
            var deferred = $q.defer();
            $log.log('saving movie');
            $http.post('/Movie/Save', movie)
                .success(function () { deferred.resolve(); })
                .error(function () { deferred.reject(); });
            return deferred.promise;
        }
    };
});