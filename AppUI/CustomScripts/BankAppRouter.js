var mainApp = angular.module("mainApp", ['ngRoute']);
mainApp.run(function ($rootScope) {
    $rootScope.CurrentUserName = "Raj";
});
mainApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.

    when('/deposit', {
        templateUrl: 'deposit.htm',
        controller: 'depositController'
    }).

    when('/checkBalance', {
        templateUrl: 'checkBalance.htm',
        controller: 'checkBalanceController'
    }).

    when('/withdraw', {
        templateUrl: 'withdraw.htm',
        controller: 'withdrawController'
    }).

    when('/transfer', {
        templateUrl: 'transfer.htm',
        controller: 'transferController'
    }).

    when('/statement', {
        templateUrl: 'statement.htm',
        controller: 'statementController'
    }).

    otherwise({
        redirectTo: '/checkBalance'
    });
}]);

