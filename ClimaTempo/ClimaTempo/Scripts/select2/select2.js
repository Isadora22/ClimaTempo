(function () {
    'use strict';

    angular.module('app').directive('select2', select);

    function select() {
        return {
            restrict: "C",
            scope: {
                ngModel: "=",
                allowClear: "=?",
                allowSearch: "=?"
            },
            link: function (scope, element) {

                function Select2Tag() { }
                scope.__tag = new Select2Tag();

                element.select2({
                    placeholder: "",
                    allowClear: scope.allowClear == undefined || scope.allowClear == true ? true : false,
                    minimumResultsForSearch: scope.allowSearch == undefined || scope.allowSearch == true ? 0 : -1,
                    
                    "language": {
                        "noResults": function () {
                            return "Nenhum resultado encontrado.";
                        }
                    },
                    escapeMarkup: function (markup) {
                        return markup;
                    },
                    closeOnSelect: true,
                    container: "#divSistema"

                }).focus(function () { $(this).select2('focus'); });

                element.change(function () {
                    scope.$apply(function () {
                        if ($(element).val() == 'null') {
                            scope.ngModel = null;
                            element.select2().val(null)
                        } else {
                            scope.ngModel = $(element).val();
                        }
                    });
                });
                                        
                scope.$watch('ngModel', function () {
                    element.trigger('change.select2');
                });

                element.on('$destroy', function () {
                    scope.$destroy();
                });

                scope.$on('$destroy', function () {
                    element.find("*").off();
                    element.off();

                    element.find("*").remove();

                    scope.ngModel = null;
                    scope.allowClear = null;
                    scope.allowSearch = null;

                    scope = null;

                    element.select2('destroy');
                    element.off('select2:select');
                });

                element.on('select2:unselecting', function (e) {
                    $(this).on('select2:opening', function (e) {
                        e.preventDefault();
                    });

                });
                element.on('select2:unselect', function (e) {
                    var sel = $(this);
                    setTimeout(function () {
                        sel.off('select2:opening');
                    }, 1);
                });
            }
        }
    }
})();