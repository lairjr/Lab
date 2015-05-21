angular.module('blogApp', [])
    .controller('PostDetailController', function ($scope, $http, $routeParams, $location, postService) {
        $scope.post = { Id: 0, Title: '' };
        $scope.tagName = '';
        $scope.tagList = [];

        $scope.getPost = function () {
            var id = $routeParams.postId;
            var post = postService.getPost(id);
            post.then(function (post) {
                $scope.post = post;
            });
        }

        $scope.savePost = function (post) {
            var postResult = postService.save(post);
            postResult.then(function (post) {
                $scope.post;
            });
        }

        $scope.getTags = function () {
            $http.get('../Api/Tag').success(function (data, status) {
                angular.forEach(data, function (tag) {
                    $scope.tagList.push(tag.Name);
                });
            });
        }

        $scope.removeTag = function (postTag) {
            $http.delete('../Api/PostTag/' + postTag.Id).success(function (data, status) {
                $scope.getPost();
            });
        }

        $scope.addTag = function (tagName, post) {
            var postTagVM = {
                PostId: post.Id,
                Tag: tagName
            };
            $http.post('../Api/PostTag/', postTagVM).success(function (data, status) {
                $scope.getPost();
            });
        }
    });