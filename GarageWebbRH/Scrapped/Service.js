//(function () {

//    var parkingGarage = function ($http) {

//        //get All Eployee
//        var getFordon = function () {

//            alert("i getFordon");
//            ////return $http.get("Fordons/Index2");
//            //return $http.get("Fordons/GetFordon")
//            //            .success(function (response) {
//            //                return response.data;
//            //            });
//        };

//    };

//    var module = angular.module("parkingViewer");
//    module.factory("parkingGarage", parkingGarage);

//}());


//parkingViewer.factory('parkingGarageAPI', function ($http, $q) {
//    return {
//        getFordon: function () {
//            var deferred = $q.defer();
//            $http.get('Fordons/GetFordon').success(deferred.resolve).error(deferred.reject);
//            return deferred.promise;
//        }
//    }
//});