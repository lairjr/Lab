function PostController($scope, $routeParams, $location, postService) {
    $scope.postList = [];
    $scope.post = { Id: 0, Title: '' };
    $scope.searchLoading = false;
    $scope.isFirstPage = true;
    $scope.isLastPage = false;

    $scope.deletePost = function (id) {
        $http.delete('../Api/Post/' + id).success(function (data, status) {
            getPosts();
        });
    }

    $scope.getPost = function () {
        var id = $routeParams.postId;
        $scope.post = postService.getPost(id);
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
            $http.get('../Api/Post/Search', { params: { searchString: searchString, currentPage: currentPage } })
                .success(function (data, status) {
                    populatePosts(data);
                    $scope.searchLoading = false;
                });
        } else {
            $http.get('../Api/Post/List', { params: { currentPage: currentPage } })
                .success(function (data, status) {
                    populatePosts(data);
                    $scope.searchLoading = false;
                });
        }
    }

    $scope.newPost = function () {
        $scope.post = { Id: 0, Title: '', Description: '' };
    }

    $scope.savePost = function (post) {
        var postResult = postService.save(post);
        postResult.then(
            function (postResult) {
                $scope.post = postResult;
            },
            function (response) {
                console.log(response);
            });
    }

    $scope.searchPost = function (sString) {
        if (sString == null || sString == '') {
            $location.search({ 'page': 1 });
        }
        else {
            $location.search({ 's': sString, 'page': 1 });
        }
    }

    function populatePosts(data) {
        $scope.postList = data.Posts;
        $scope.isLastPage = data.IsLastPage;
    }
}