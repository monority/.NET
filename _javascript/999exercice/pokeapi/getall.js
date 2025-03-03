const API_URL = "https://pokeapi.co/api/v2/pokemon";



const getAll = async () => {
	const response = await fetch(`${API_URL}/?limit=1000`);
	const data = await response.json();
	const pokeinput = document.querySelector(".pokeinput");
	const pokemons = data.results.map(pokemon => pokemon.name);

	console.log(pokemons);console.log(data)

	pokeinput.innerHTML = "";

	pokemons.forEach(pokemon => {
		const paragraph = document.createElement('p');
		paragraph.textContent = pokemon;
		pokeinput.appendChild(paragraph);
	});
};

window.onload = getAll;
