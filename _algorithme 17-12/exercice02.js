let age = Number(prompt("Donne ton âge"));

if (age > 0) {
	if (age >= 18) {
		alert(`Vous avez ${age}, vous êtes majeur.`);
	}
	else {
		alert(`Vous avez ${age}, vous êtes mineur.`)
	}
} else {
	alert("Votre âge doit être positif")
}

switch (age) {
	case 15:
		alert(`Vous avez ${age}`)
		break;
	case 17:
		alert(`Vous avez ${age}`)

		break;
	case 18:
		break;
	default:
		break;
}