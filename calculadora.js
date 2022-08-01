const calculadora = {
    somar(valor1, valor2) {
        return valor1 + valor2;
    },
    subtrair(valor1, valor2) {
        return valor1 - valor2;
    },
    multiplicar(valor1, valor2) {
        return valor1 * valor2;
    },
    dividir(valor1, valor2) {
        return valor1 / valor2;
    },
};

const somar = calculadora.somar;
const subtrair = calculadora.subtrair;
const multiplicar = calculadora.multiplicar;
const dividir = calculadora.dividir;

const valoresCalcular = multiplicar(2, 2);

if (valoresCalcular) {
    console.log(valoresCalcular);
}
