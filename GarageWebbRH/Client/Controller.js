(function (app) {

    var app = angular.module("parkingViewer");

    var ParkingController = function ($scope, parkingGarage) { //

        $scope.test = "Testar om det syns nåt";

        alert("i ParkingController");

        //$scope.divFordon = false;
        
        // To Get All Records 
        function GetAllFordon() {
            alert("i GetAllFordon");
            
            var getData = parkingGarage.getFordon();
            
            getData.then(function (emp) {
                $scope.fordon = emp.data;
            }, function () {
                alert('Error in getting records');
            });
        }

        GetAllFordon();
    };

    app.controller("ParkingController", ParkingController);

}());
