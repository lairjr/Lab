blogApp.directive('autoComplete', function ($timeout) {
    return function (scope, iElement, iAttrs) {
        var items = scope[iAttrs.acItems];
        scope.autoCompleteValues = [];
        //debugger;
        //items.ready(function () {
        //    angular.forEach(items, function (item) {
        //        if (item != null) {
        //            debugger;
        //            scope.autoCompleteValues.push(item[iAttrs.acDisplayValue])
        //        }
        //    });
        //});
        iElement.autocomplete({
            source: items,
            select: function () {
                $timeout(function () {
                    iElement.trigger('input');
                }, 0);
            }
        });
    };
});