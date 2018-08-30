var map, searchManager, pushpin, locat;

function GetMap() {
    var lng = document.getElementById("Long").value;
    var lat = document.getElementById("Lat").value;
    locat = new Microsoft.Maps.Location(lat, lng);
    map = new Microsoft.Maps.Map('#myMap',
        {
            credentials: ApiKey,
            center: locat,
            zoom: 5
        });
    Microsoft.Maps.Events.addHandler(map, 'click', reverseGeocode);
    pushpin = new Microsoft.Maps.Pushpin(locat);
    map.entities.push(pushpin);
}

function reverseGeocode(e) {
    var point = new Microsoft.Maps.Point(e.getX(), e.getY());
    var clickLocation = e.target.tryPixelToLocation(point);

    if (!searchManager) {
        Microsoft.Maps.loadModule('Microsoft.Maps.Search',
            function () {
                searchManager = new Microsoft.Maps.Search.SearchManager(map);
                reverseGeocode(e);
            });
    } else {
        var searchRequest = {
            location: clickLocation,
            callback: function (r) {
                document.getElementById("Address").value = r.name;
                document.getElementById("Long").value = clickLocation.longitude;
                document.getElementById("Lat").value = clickLocation.latitude;
                map.entities.clear();
                pushpin.setLocation(locat);

            },
            errorCallback: function (e) {
                //If there is an error, alert the user about it.
                alert("Unable to reverse geocode location.");
            }
        };
        searchManager.reverseGeocode(searchRequest);
    }
}