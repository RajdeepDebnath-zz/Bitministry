mainApp.controller('withdrawController', function ($scope, $http, $rootScope) {


    $scope.WithdrawEvent = function () {
        $http({
            method: "POST",
            url: "http://PRACTICE-PC/RajdeepBankApp/api/Transaction/Withdraw",
            headers: { 'Content-Type': 'application/json' },
            data: { UserName: $rootScope.CurrentUserName, Amount: $scope.amount }
        }).success(function (data) {
            $scope.message = "Amount withdrawn successfully.";
        }).error(function (data) {
            $scope.message = "Some error happened. Amount could not be withdrawn.";
        });
    };
});