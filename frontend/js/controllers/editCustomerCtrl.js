(function (app) {
  'use strict';
  app.controller('editCustomerCtrl', editCustomerCtrl);

  editCustomerCtrl.$inject = ['customerApi', 'customerService', '$routeParams'];

  function editCustomerCtrl(customerApi, customerService, $routeParams) {
    var vm = this;
    vm.maritalStatusList = customerService.maritalStatusList;

    customerApi.getCustomer($routeParams.cpf).then(function (res, status) {
      vm.client = res.data;
    }).catch(function(erro) {
      console.log(erro);
    });

    vm.save = function (customer, formValid) {
        customerService.save(customer, formValid, $routeParams.cpf);
        vm.submitted = !formValid;
    };

    vm.deleteCustomer = function(cpf){
        customerService.deleteCustomer(cpf);
    };

    vm.addPhone = function(phoneNumber, customer){
      customerService.addPhone(phoneNumber, customer);
      delete vm.phoneNumber;
    };

    vm.deletePhone = function(phoneNumber, customer){
      customerService.deletePhone(phoneNumber, customer);
    };
  };
})(angular.module('customerApp'));
