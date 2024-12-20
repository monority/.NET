function amount(capital, rate, years) {
	capital = Number(prompt("Donner votre capital"));
	rate = Number(prompt("Donner le taux")) / 100;
	years = Number(prompt("Combien d'années"));

	let total = capital * Math.pow(1 + rate, years);
	let gain = total - capital;
	return alert(`Le total est de ${Math.round(total)}, le gain est donc de ${Math.round(gain)}`);
}
amount();