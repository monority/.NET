function amount(capital,rate, years){
	capital = Number(prompt("Donner votre capital"));
	rate = Number(prompt("Donner le taux"))/100;
	years = Number(prompt("Combien d'années"));

	total = capital * Math.pow(1+rate, years);
	gain = total - capital;
	return alert(gain);
}
amount();