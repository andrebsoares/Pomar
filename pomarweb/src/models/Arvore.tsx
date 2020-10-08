import { Especie } from "./Especie";
import { GrupoArvore } from "./GrupoArvore";

export class Arvore {
    constructor(
        public codigo: number,
        public descricao: string,
        public dataPlantio: Date,
        public especieId: number,
        public especie: Especie,
        public grupoArvoreId: number,
        public grupoArvore: GrupoArvore,
        //public colheitasArvore
    ) {

    }
}