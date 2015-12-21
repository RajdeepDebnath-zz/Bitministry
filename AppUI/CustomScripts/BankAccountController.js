mainApp.controller('bankAccountController', function ($scope, $http, $rootScope, $location) {
    $http({
        method: "GET",
        url: "http://PRACTICE-PC/RajdeepBankApp/api/BankAccount",
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        $scope.userNameList = {
            singleSelect: null,
            availableOptions: data,
        };
        $scope.UserNameChangeEvent = function () {
            $rootScope.CurrentUserName = $scope.singleSelect.UserName;
            $location.path("#/checkBalance");
        };
    }).error(function (data) {
        console.log(data);
    });
});