export class Vehicule {
	constructor(imm, enterDate, outDate) {
		this.imm = imm;
		this.enterDate = enterDate;
		this.outDate = outDate;

	}

	display(){
		return `Imm : ${this.imm} Enter Date : ${this.enterDate} Out Date : ${this.outDate}`;	
	}
}
