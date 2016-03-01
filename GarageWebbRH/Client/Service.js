(function () {

    var parkingService = function ($http) {

        var getFordon = function () {
            alert("Service.js -> i getFordon servicen");

            return $http.get("/Fordons/GetFordon")
                        .then(function (response) {
                            return response.data;
                        }, function () {
                            alert('http.get /Fordons/GetFordon gick fel');
                        });
        };

        return {
            getFordon: getFordon
        };
    };

    var module = angular.module("parkingModule");
    module.factory("parkingService", parkingService);

}());