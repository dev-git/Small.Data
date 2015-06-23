'use strict';

simpleNote.factory('noteRepository', function ($http, $q, $log) {
    return {
        save: function (note) {
            var deferred = $q.defer();
            $log.log('saving note');
            $http.post('/Note/Save', note)
                .success(function () { deferred.resolve(); })
                .error(function () { deferred.reject(); });
            return deferred.promise;
        }
    };
});