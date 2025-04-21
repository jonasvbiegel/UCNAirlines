// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function hello() {
	console.log('Hello');
}

async function postAirplane() {
	var airplanepost = document.getElementById("airplanepost");

	let inputs = [];

	for (var i = 0; i < airplanepost.length; i++) {
		inputs.push(airplanepost.elements[i].value);
	}

	for (var i = 0; i < inputs.length; i++) {
		console.log(inputs[i]);
	}

	await postToApi(inputs[0], inputs[1], inputs[2], inputs[3]);
}

async function postToApi(airplaneid, model, rows, columns) {
	fetch("http://localhost:5262/api/airplane", {
		method: "POST",
		body: JSON.stringify({
			Airplane_id: airplaneid,
			Model: model,
			Seat_rows: rows,
			Seat_columns: columns
		}),
		headers: {
			"Content-type": "application/json; charset=UTF-8"
		}
	})
		.then((response) => response.json())
		.then((json) => console.log(json));
}

