(function (app) {
  'use strict';
  app.factory('customerApi', customerApi);

  customerApi.$inject = ['$http', 'urlConfig'];

  function customerApi($http, urlConfig) {
    var _getAll = function () {
        return $http.get(urlConfig.baseUrl + "/customers");
    };

    var _getCustomer = function (cpf) {
        return $http.get(urlConfig.baseUrl + "/customers/" + cpf);
    };

    var _postCustomer = function (customer) {
        return $http.post(urlConfig.baseUrl + "/customers/", customer);
    };

    var _putCustomer = function (cpf, customer) {
        return $http.put(urlConfig.baseUrl + "/customers/" + cpf, customer);
    };

    var _deleteCustomer = function (cpf) {
        return $http.delete(urlConfig.baseUrl + "/customers/" + cpf);
    };

    return {
        getAll: _getAll,
        getCustomer: _getCustomer,
        postCustomer: _postCustomer,
        putCustomer: _putCustomer,
        deleteCustomer: _deleteCustomer
    };
  };
})(angular.module('customerApp'));
