mainApp.controller('depositController', function ($scope, $http, $rootScope) {
    
    $scope.DepositEvent = function () {
        $http({
            method: "POST",
            url: "http://PRACTICE-PC/RajdeepBankApp/api/Transaction/Diposit",
            headers: { 'Content-Type': 'application/json' },
            data: {UserName:$rootScope.CurrentUserName, Amount:$scope.amount}
        }).success(function (data) {
            $scope.message = "Amount deposited successfully.";}).error(function(data)
            {
                $scope.message = "Some error happened. Amount could not be deposited.";
            });
    };
});