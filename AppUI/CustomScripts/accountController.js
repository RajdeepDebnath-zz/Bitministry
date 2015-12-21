

var mainApp = angular.module("accountApp", []);


mainApp.controller('accountController', function ($scope, $http) {

    $scope.name = "Raju";


    $http({
        method: "GET",
        url: "http://PRACTICE-PC/RajdeepBankApp/api/account",
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        $scope.employees = data;
        console.log(data);
    }).error(function (data) {
        console.log(data);
    });




});