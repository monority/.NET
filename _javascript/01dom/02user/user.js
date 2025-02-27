const res = document.querySelector(".result");
const name = document.querySelector(".name");	


const validate = ()	=> {
	res.innerHTML = `<h1>Hi ${name.value}! Welcome to the world of DOM</h1>`;
	res.innerHTML += "<p>test</p>";
}