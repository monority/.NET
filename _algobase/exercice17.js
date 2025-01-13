
let table_student = [];

for (let i = 0; i < 15; i++) {
	console.log(`3 notes for student n°${i}`)
	table_student[i] = []
	for (let j = 0; j < 3; j++) {
		let number_rdm = Math.floor(Math.random() * 10);
		console.log(number_rdm)
		table_student[i].push(number_rdm);
	}
	console.log(table_student);
}


