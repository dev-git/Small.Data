'use strict';

// Controller should be an entry point to and from your views
simpleNote.controller("NoteController", function ($scope, $location, $log, noteRepository) {
    $scope.save = function (note) {
        // Disable the save button to stop multiple hits
        document.getElementById('btnSave').disabled = true;
        $scope.error = false;
        noteRepository.save(note).then(
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