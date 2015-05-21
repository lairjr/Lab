'use strict';

/**
 * @ngdoc directive
 * @name blogApp.directive:permissionToView
 * @description
 * # permissionToView
 */
angular.module('blogApp')
  .directive('permissionToView', function () {
      return {
          restrict: 'AEC',
          link: function postLink(scope, element, attrs) {
              debugger;
              scope.$on("permissionLoaded", function () {
                  debugger;
                  var premissionRequired = attrs['permissionToView'];
                  var permissionIndex = scope.awesomeThings.indexOf(premissionRequired);
                  if (permissionIndex < 0) {
                      element.attr('style', 'display: none;');
                  }
              });
          }
      };
  });
