function TagController($scope, $http, $routeParams) {
    $scope.tagList = [];
    $scope.tag = { Id: 0, Name: '' };

    $scope.deleteTag = function (id) {
        $http.delete('../Api/Tag/' + id).success(function (data, status) {
            //TODO: Remove tag here
            $scope.tagList = [];
        });
    }

    $scope.newTag = function () {
        $scope.tag = { Id: 0, Name: '' };
    }

    $scope.saveTag = function () {
        $http.post('../Api/Tag/', $scope.tag).success(function (data, status) {
            $scope.tag = data;
        });
    }

    function populateTags(data) {
        $scope.tagList = data;
    }
}