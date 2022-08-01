const valorA = 288;
const valorB = 306;

function valorAouBZero(valorA, valorB) {
    if (valorA === 0) return valorB;
    else if (valorB === 0) return valorA;
}

function retornaResto(valorA, valorB) {
    let resto = valorA % valorB;
    return resto;
}

function algoritmoEuclidiano(valorA, valorB) {
    let valorTempA = valorA;
    let valorTempB = valorB;

    if (valorA != 0 && valorB != 0) {
        let valorMDC;
        while (retornaResto(valorTempA, valorTempB) > 0) {
            let resto = retornaResto(valorTempA, valorTempB);

            valorTempA = valorTempB;
            valorTempB = resto;
        }
        return (valorMDC = valorTempB);
    } else {
        return valorAouBZero(valorA, valorB);
    }
}

console.log(algoritmoEuclidiano(valorA, valorB));
