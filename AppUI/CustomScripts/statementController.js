mainApp.controller('statementController', function ($scope, $http, $rootScope) {
    $scope.message = "Get your statement.";
    $http({
        method: "GET",
        url: "http://PRACTICE-PC/RajdeepBankApp/api/transaction/GetStatement/" + $rootScope.CurrentUserName,
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        $scope.statement = data;
    }).error(function (data) {
        console.log(data);
    });
});