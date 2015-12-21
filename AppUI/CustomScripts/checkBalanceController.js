mainApp.controller('checkBalanceController', function ($scope, $http, $rootScope) {
    $scope.message = "Check your balance.";

    $http({
        method: "GET",
        url: "http://PRACTICE-PC/RajdeepBankApp/api/transaction/GetBalance/" + $rootScope.CurrentUserName,
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        $scope.balance = data;
    }).error(function (data) {
        console.log(data);
    });
});