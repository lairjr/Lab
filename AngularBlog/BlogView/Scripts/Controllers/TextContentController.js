angular.module('blogApp', [])
    .controller('TextContentController', function ($scope, postService) {
        $scope.save = function (content) {
            debugger;
            var post = postService.currentPost();
            alert(content.Text);
        };
    });