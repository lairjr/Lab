'use strict';

/**
 * @ngdoc service
 * @name blogApp.postService
 * @description
 * # postService
 * Service in the blogApp.
 */
angular.module('blogApp')
  .service('postService', function postService() {
      var resource = $resource('../Api/Post/:id', { id: '@id' },
        {
            'search': { url: '../Api/Post/Search/', method: 'GET' },
            'getAll': { url: '../Api/Post/List/', method: 'GET' }
        });
      var post = '';

      return {
          currentPost: function () {
              return post;
          },
          getPost: function (postId) {
              var deferred = $q.defer();

              resource.get({ id: postId },
                  function (post) {
                      deferred.resolve(post);
                      this.post = post;
                  },
                  function (response) {
                      deferred.reject(response);
                  });

              return deferred.promise;
          },
          search: function (searchString, currentPage) {
              var deferred = $q.defer();

              resource.search({ searchString: searchString, currentPage: currentPage },
                  function (postList) {
                      deferred.resolve(postList);
                  },
                  function (response) {
                      deferred.reject(response);
                  });

              return deferred.promise;
          },
          getAll: function (currentPage) {
              var deferred = $q.defer();

              resource.getAll({ currentPage: currentPage },
                  function (postList) {
                      deferred.resolve(postList);
                  },
                  function (response) {
                      deferred.reject(response);
                  });

              return deferred.promise;
          },
          save: function (post) {
              var deferred = $q.defer();

              resource.save(post,
                  function (post) {
                      deferred.resolve(post);
                  },
                  function (response) {
                      deferred.reject(response);
                  });

              return deferred.promise;
          },
          delete: function (postId) {
              var deffered = $q.defer();

              resource.delete({ id: postId },
                  function (post) {
                      deffered.resolve(post);
                  },
                  function (response) {
                      deffered.reject(response);
                  });

              return def.promise;
          }
      }
  });
