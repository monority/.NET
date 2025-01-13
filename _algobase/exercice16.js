
let table2d = [[14,12,15],[14,12,15],[14,12,15]];

student01 = table2d[0];
student01_note01 = table2d[0][0];

console.log(student01);

for (let i = 0; i < 4; i++) {
	console.log(`Student n°${i+1}`)
	for (let j = 0; j < 3; j++) {
		console.log(`Note n° ${j+1} ${table2d[i][j]}`)
	}
}