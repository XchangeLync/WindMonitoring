/// <reference path="../angular.js" />
/// <reference path="module.js" />

app.service("AppCRUDService", function ($http, $filter) {
    this.getStates = function () {
        return $http.get("http://localhost:49227/api/State");
    };
    this.getCities = function () {
        return $http.get("http://localhost:49227/api/City");
    };
    this.getStations = function () {
        return $http.get("http://localhost:49227/api/Station");
    };

    this.getStateCity = function (cityList, stateId) {
        var items = ($filter('filter')(cityList, { StateCode: stateId }));
        return items;
    };
    this.getCityStation = function (stationList, stateId, cityId) {
        var items = ($filter('filter')(stationList, { StateCode: stateId, CityCode: cityId }));
        return items[0].StateCode + "-" + items[0].CityCode + "-" + items[0].StationCode;
    };

    this.getPredictedSpeed = function (station) {
        var request = $http({
            method: "GET",
            url: "http://localhost:49227/api/PredictedSpeed?station=" + station
            //data: station
        });
        return request;
    };
});