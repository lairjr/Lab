'use strict';

describe('Directive: permissionToView', function () {

  // load the directive's module
  beforeEach(module('blogAppApp'));

  var element,
    scope;

  beforeEach(inject(function ($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should make hidden element visible', inject(function ($compile) {
    element = angular.element('<permission-to-view></permission-to-view>');
    element = $compile(element)(scope);
    expect(element.text()).toBe('this is the permissionToView directive');
  }));
});
