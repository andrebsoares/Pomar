import { Arvore } from "./Arvore";
import { Colheita } from "./Colheita";

export class ColheitaArvore {
    constructor(
        public codigo: number,
        public colheita: Colheita,
        public arvore: Arvore) {

    }
};