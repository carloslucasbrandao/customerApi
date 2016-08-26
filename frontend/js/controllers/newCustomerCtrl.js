(function (app) {
  'use strict';
  app.controller('newCustomerCtrl', newCustomerCtrl);

  newCustomerCtrl.$inject = ['customerApi', 'customerService', '$location'];

  function newCustomerCtrl(customerApi, customerService, $location) {
    var vm = this;
    vm.maritalStatusList = customerService.maritalStatusList;

    vm.save = function (customer, formValid) {
        customerService.save(customer, formValid, 0);
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
