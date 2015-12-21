mainApp.controller('transferController', function ($scope, $http, $rootScope) {
    $http({
        method: "GET",
        url: "http://PRACTICE-PC/RajdeepBankApp/api/BankAccount/GetUserNames/" + $rootScope.CurrentUserName,
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        $scope.userNameList = {
            singleSelect: null,
            availableOptions: data,
        };
    }).error(function (data) {
        console.log(data);
    });

    $scope.TransferEvent = function () {
        $http({
            method: "POST",
            url: "http://PRACTICE-PC/RajdeepBankApp/api/Transaction/Transfer",
            headers: { 'Content-Type': 'application/json' },
            data: { UserNameFrom: $rootScope.CurrentUserName, UserNameTo: $scope.singleSelect.UserName, Amount: $scope.amount }
        }).success(function (data) {
            $scope.message = "Amount transferred successfully.";
        }).error(function (data) {
            $scope.message = "Some error happened. Amount could not be transferred.";
        });
    };
});