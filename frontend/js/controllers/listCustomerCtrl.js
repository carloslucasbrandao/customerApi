(function (app) {
    'use strict';
    app.controller('listCustomerCtrl', listCustomerCtrl);

    listCustomerCtrl.$inject = ['customerApi', 'customerService', '$location'];

    function listCustomerCtrl(customerApi, customerService, $location) {
        var vm = this;
        vm.redirect = function (cpf) {
            $location.path("/edit/" + cpf);
        };

        vm.redirectNew = function () {
            $location.path("/new/");
        };

        var getAll = function () {
            customerApi.getAll().success(function (data, status) {
                vm.clients = data;
            }).error(function (data, status) {
                console.log(data, status);
            });
        };

        getAll();

        vm.deleteCustomer = function(cpf){
            customerService.deleteCustomer(cpf);
            getAll();
        };
    };
})(angular.module('customerApp'));
