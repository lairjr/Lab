angular.module('blogApp', [])
    .controller('PostListController', function ($scope, $http, $routeParams, $location, postService) {
        $scope.postList = [];
        $scope.searchLoading = false;
        $scope.isFirstPage = true;
        $scope.isLastPage = false;

        $scope.deletePost = function (id) {
            var success = postService.delete(id);
            success.then(function () {
                this.getPosts();
            });
        }

        $scope.getPosts = function () {
            var searchString = $routeParams.s;
            var currentPage = $routeParams.page;
            if (currentPage == null)
                currentPage = 1;

            if (currentPage > 1)
                $scope.isFirstPage = false;

            $scope.searchLoading = true;

            if (searchString != null) {
                var postList = postService.search(searchString, currentPage);
                postList.then(function (postList) {
                    populatePosts(postList);
                    $scope.searchLoading = false;
                });
            } else {
                var postList = postService.getAll(searchString, currentPage);
                postList.then(function (postList) {
                    populatePosts(postList);
                    $scope.searchLoading = false;
                });
            }
        }

        $scope.searchPost = function (searchString) {
            if (searchString == null || searchString == '') {
                $location.search({ 'page': 1 });
            }
            else {
                $location.search({ 's': searchString, 'page': 1 });
            }
        }

        $scope.nextPage = function () {
            var searchString = $routeParams.s;
            var currentPage = $routeParams.page;
            if (currentPage == null)
                currentPage = 1;
            currentPage++;

            if (searchString != null) {
                $location.search({ 's': searchString, 'page': currentPage });
            } else {
                $location.search({ 'page': currentPage });
            }
        }

        $scope.previusPage = function () {
            var searchString = $routeParams.s;
            var currentPage = $routeParams.page;
            if (currentPage == null)
                currentPage = 1;
            currentPage--;

            if (searchString != null) {
                $location.search({ 's': searchString, 'page': currentPage });
            } else {
                $location.search({ 'page': currentPage });
            }
        }

        function populatePosts(data) {
            $scope.postList = data.Posts;
            $scope.isLastPage = data.IsLastPage;
        }
    });