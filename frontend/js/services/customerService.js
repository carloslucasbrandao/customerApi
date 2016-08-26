(function (app) {
  'use strict';
  app.service('customerService', customerService);

  customerService.$inject = ['customerApi', '$location'];

  function customerService(customerApi, $location) {
    var vm = this;
    vm.save = function (customer, formValid, cpf) {
        if(formValid)
        {
            var result;
            if(cpf > 0){
                result = customerApi.putCustomer(customer.cpf, customer);
            }else{
                result = customerApi.postCustomer(customer);
            }

            result.then(function (data, status) {
                $location.path('/');
            }).catch(function(erro) {
                console.log(erro);
            });
        }
    };

    vm.deleteCustomer = function(cpf){
        customerApi.deleteCustomer(cpf).then(function (data, status) {
            //$location.path('/');
        }).catch(function(erro) {
            console.log(erro);
        });
    };

    vm.addPhone = function(phoneNumber, customer){
        if(customer.phones == undefined){
            customer.phones = new Array();
        }
        customer.phones.push({"id":0,"number":phoneNumber,"cpfCustomer":customer.cpf});
    };

    vm.deletePhone = function(phoneNumber, customer){
        customer.phones = customer.phones.filter(function (phone) {
            if(phone.number != phoneNumber) return phone;
                    });
    };

    vm.maritalStatusList = [
        { name : "Married" },
        { name : "Widowed" },
        { name : "Divorced" },
        { name : "Single" }
    ];
    vm.regexPhone = /^\([1-9]{2}\)[0-9]{4,5}-[0-9]{4}$/;
  };
})(angular.module('customerApp'));
