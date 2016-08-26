angular.module("customerApp").config(['$routeProvider',  function($routeProvider, $routeParams){
    $routeProvider.when('/', {
        controller: 'listCustomerCtrl as vm',
        templateUrl: 'view/customerList.html'
    });

    $routeProvider.when('/new', {
        controller: 'newCustomerCtrl as vm',
        templateUrl: 'view/customerForm.html'
    });

    $routeProvider.when('/edit/:cpf', {
        controller: 'editCustomerCtrl as vm',
        templateUrl: 'view/customerForm.html'
    });

    $routeProvider.when('/delete/:cpf', {
        controller: 'customerCtrl as vm',
        templateUrl: ''
    });

    $routeProvider.otherwise({ redirectTo: '/' });
}]);
