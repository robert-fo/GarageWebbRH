(function (app) {

    var app = angular.module("parkingModule");

    var ParkingController = function ($scope, $log, $http, parkingService) {

        $scope.test = "Testar om det syns nåt";
        $scope.fordon = [];
        alert("Controller.js -> i ParkingController");

        //$scope.divFordon = false;
        var getFordon2 = function () {
            alert("Service.js -> i getFordon servicen");

            //return $http.get("/Fordons/GetFordon")
            //            .then(function (response) {
            //                $log.log("Get Fordon: "+response.data);
            //                return response.data;
            //            }, function () {
            //                alert('http.get /Fordons/GetFordon gick fel');
            //            });

            $http({
                method: 'GET',
                url: '/Fordons/GetFordon'
            }).then(function successCallback(response) {
                $log.log("Get Fordon: " + response.data);
                $scope.Vehicles = response.data;
                return response.data;
            }, function errorCallback(response) {
                alert('http.get /Fordons/GetFordon gick fel');
            });
        };

        // To Get All Records 
        function GetAllFordon() {
            //alert("Controller.js -> i GetAllFordon");

            //var getData = parkingService.getFordon();
            $log.log("1");
            var Alle = getFordon2();
            $log.log("2");
            $log.log($scope.Vehicles);
            $log.log("3");

            //getData.then(function (response) {
            //    $scope.fordon = response.data;
            //    $log.log($scope.fordon);
            //}, function () {
            //    alert('Error in getting records');
            //});
        }

        GetAllFordon();
    };

    app.controller("ParkingController", ParkingController);

}());