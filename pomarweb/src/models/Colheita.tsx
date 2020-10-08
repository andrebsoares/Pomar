import { ColheitaArvore } from "./ColheitaArvore";

export class Colheita {
    constructor(
        public codigo: number,
        public informacoes: string,
        public dataColheita: string,
        public pesoBruto: number,
        public colheitaArvores: ColheitaArvore[]
    ) {

    }
}