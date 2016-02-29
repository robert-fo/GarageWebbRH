(function () {

    var app = angular.module("parkingViewer");

    var ParkingController = function ($scope, parkingGarage) {

        $scope.divFordon = false;
        GetAllFordon();
        //To Get All Records 
        function GetAllFordon() {
            debugger;
            var getData = parkingGarage.getEmployees();
            debugger;
            getData.then(function (emp) {
                $scope.fordon = emp.data;
            }, function () {
                alert('Error in getting records');
            });
        }

    };

    app.controller("ParkingController", ParkingController);

}());