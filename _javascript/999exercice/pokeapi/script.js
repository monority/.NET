const inputName = document.querySelector(".name");
const API_URL = "https://pokeapi.co/api/v2/pokemon";
const result = document.querySelector(".result");
const imgpoke = document.querySelector(".pokeimg");
const poketype = document.querySelector(".poketype");
const ability = document.querySelector(".ability");
const pokeweight = document.querySelector(".pokeweight");
const pokeheight = document.querySelector(".pokeheight");
const stats = document.querySelector(".stats");
const pokename = document.querySelector(".pokename");
const pokedex = document.querySelector("#pokedex");
const pokeid = document.querySelector(".pokeid");
const pokestats = document.querySelector(".pokestats");
let currentPokemonId = null;
const pokeimgsub = document.querySelector(".pokeimgsub");
const getPokemonName = async (nameOrId) => {
	if (!inputName) {
		console.error("Element with class 'name' not found in the DOM.");
		return;
	}

	let NameValue = nameOrId || inputName.value.trim();
	if (!NameValue) {
		console.error("Please enter a Pokémon name.");
		return;
	}

	try {
		const response = await fetch(`${API_URL}/${NameValue}`);
		if (!response.ok) {
			result.innerHTML = "Pokemon not found";
			return;
		}
		pokedex.style.display = "block";
		const data = await response.json();
		console.log(data)
		currentPokemonId = data.id;

		pokeimgsub.innerHTML = '';

		Object.keys(data.sprites).forEach(key => {
			if (data.sprites[key] && typeof data.sprites[key] === 'string') {
				const imgElement = document.createElement('img');
				imgElement.classList.add("variantimg");
				imgElement.src = data.sprites[key];
				imgElement.alt = key;
				pokeimgsub.appendChild(imgElement);
			}
		});

		pokeheight.innerHTML = `Height: ${data.height}`;
		pokestats.innerHTML = `Stats: ${data.stats.map(stat => stat.base_stat).join(' ')}`;
		pokeweight.innerHTML = `Weight: ${data.weight}`;
		poketype.innerHTML = `Type: ${data.types.map(type => type.type.name).join(' ')}`;
		pokename.innerHTML = `Name: ${data.name}`;
		imgpoke.src = data.sprites.front_default;

	} catch (error) {
		console.error("Error fetching data:", error);
	}
};

const previousPokemon = async () => {
	if (currentPokemonId === null) {
		console.error("No Pokémon data available.");
		return;
	}

	const previous = currentPokemonId - 1;
	if (previous < 1) {
		currentPokemonId = 1025;
	} else {
		currentPokemonId = previous;
	}
	inputName.value = currentPokemonId;
	getPokemonName(currentPokemonId);
}

const nextPokemon = async () => {
	if (currentPokemonId === null) {
		console.error("No Pokémon data available.");
		return;
	}

	const next = currentPokemonId + 1;
	if (next > 1025) {
		currentPokemonId = 1;
	} else {
		currentPokemonId = next;
	}
	inputName.value = currentPokemonId;
	getPokemonName(currentPokemonId);
}

document.querySelector('form').addEventListener('submit', function (event) {
	event.preventDefault();
	getPokemonName();
});

