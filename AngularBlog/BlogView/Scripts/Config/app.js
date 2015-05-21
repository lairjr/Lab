var blogApp = angular.module('blogApp', [
  'ngRoute', 'ngResource'
]);

angular.module('blogApp', []).
    config(['$routeProvider', function ($routeProvider, $locationProvider) {
        $routeProvider.
            when('/Post/List', {
                templateUrl: 'Views/Post/List.html',
                controller: 'PostListController'
            }).
            when('/Post/:postId', {
                templateUrl: 'Views/Post/Detail.html',
                controller: 'PostDetailController'
            }).
            otherwise({
                redirectTo: '/phones'
            });
        //$locationProvider.html5Mode(true);
    }
    ]);