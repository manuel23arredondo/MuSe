//const funcionInit = () => {
//	if (!"geolocation" in navigator) {
//		return alert("Tu navegador no soporta el acceso a la ubicación. Intenta con otro");
//	}

//	const $latitud = document.querySelector("#latitud"),
//		$longitud = document.querySelector("#longitud"),
//		$enlace = document.querySelector("#enlace");


//	const onUbicacionConcedida = ubicacion => {
//		console.log("Tengo la ubicación: ", ubicacion);
//		const coordenadas = ubicacion.coords;
//		$latitud.innerText = coordenadas.latitude;
//		$longitud.innerText = coordenadas.longitude;
//		$enlace.href = `https://www.google.com/maps/@${coordenadas.latitude},${coordenadas.longitude},20z`;
//	}

//	const onErrorDeUbicacion = err => {

//		$latitud.innerText = "Error obteniendo ubicación: " + err.message;
//		$longitud.innerText = "Error obteniendo ubicación: " + err.message;
//		console.log("Error obteniendo ubicación: ", err);
//	}

//	const opcionesDeSolicitud = {
//		enableHighAccuracy: true, // Alta precisión
//		maximumAge: 0, // No queremos caché
//		timeout: 5000 // Esperar solo 5 segundos
//	};

//	$latitud.innerText = "Cargando...";
//	$longitud.innerText = "Cargando...";
//	navigator.geolocation.getCurrentPosition(onUbicacionConcedida, onErrorDeUbicacion, opcionesDeSolicitud);
//};
//document.addEventListener("DOMContentLoaded", funcionInit);
let map = L.map('map').setView([23.634501, -102.552784], 6)

L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
	attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
	maxZoom: 20,
	id: 'mapbox.comic',
	accessToken: 'pk.eyJ1IjoicmFsY2FyYXoiLCJhIjoiY2prNmRxcmh1MXNqODNya2NocWY5azEweCJ9.4Qf2Wgh-d1e_ujcRkvq0MA'
}).addTo(map);

document.getElementById('select-location').addEventListener('change', function (e) {
    let coords = e.target.value.split(",");
    map.flyTo(coords, 13);
})

var estiloPopup = { 'maxWidth': '300' }

var iconoBase = L.Icon.extend({
	options: {
		iconSize: [24, 39],
		iconAnchor: [16, 87],
		popupAnchor: [-3, -76]
	}
});

var iconoVerde = new iconoBase({ iconUrl: "../images/marker.png" });

L.marker([19.42573029772769, -99.14786782329821], { icon: iconoVerde }).bindPopup("<h1>Centro de Atención a la violencia Intrafamiliar C.A.V.I.</h2>", estiloPopup).addTo(map);
L.marker([19.44914740858582, -99.15915268299553], { icon: iconoVerde }).bindPopup("<h1>Asociación para el Desarrollo Integral de Personas Violadas A.C.</h1>", estiloPopup).addTo(map);