(function () {

    var app = angular.module("parkingModule");

    var ParkingController = function ($scope, parkingService) {
        //alert("Controller.js -> i ParkingController");
        //$scope.test = "Testar om det syns nåt";

        var onGetFordonComplete = function (data) {
            $scope.fordon = data;
        };

        var onError = function (reason) {
            $scope.error = "Could not fetch the data.";
        };

        $scope.orderByMe = function (x) {
            $scope.myOrderBy = x;
        }

        parkingService.getFordon().then(onGetFordonComplete, onError);

    };

    app.controller("ParkingController", ParkingController);

}());