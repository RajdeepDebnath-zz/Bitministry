var mainApp = angular.module("accountApp", []);


accountApp.controller('accountController', function ($scope, $http) {

    $scope.name = "Raj";


    $http({
        method: "GET",
        url: "http://localhost/RajdeepBankApp/api/account/index",
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        $scope.employees = data;
        console.log(data);
    }).error(function (data) {
        console.log(data);
    });




});