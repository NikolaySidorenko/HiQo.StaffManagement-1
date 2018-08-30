var map;

function GetMap() {
    map = new Microsoft.Maps.Map('#myMap',
        {
            credentials: 'Av-zol3G-mxsu7oQWjco6h2K-WV6aL9f5esTkcPj8K6ZNLi_rzuoalKJg6_hOWJn'
        });
    Microsoft.Maps.Events.addEvent(map,"click",displayLatLong)   
    
    function displayLatLong(e) {
        if (e.targetType == "map") {
            var point = new Microsoft.Maps.Point(e.getX(), e.getY());
            var loc = e.target.tryPixelToLocation(point);
            document.getElementById("textBox").value= loc.latitude + ", " + loc.longitude;

        }
    }

}