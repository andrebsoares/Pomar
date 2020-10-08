import axios from 'axios';
import { Especie } from '../models/Especie';
import { GrupoArvore } from '../models/GrupoArvore';

const baseURL = 'https://localhost:5001';

export const get = async (rota: string) => {
    try {
        const { data } = await axios.get(`${baseURL}/${rota}`);

        return data;
    } catch (error) {
        console.log(error);
    }
};

export const postEspecie = (data: Especie) => {
    try {
        axios.post(`${baseURL}/especies`, data);
    } catch (error) {
        console.log(error);
    }
};

export const postGrupoArvore = (data: GrupoArvore) => {
    try {
        console.log(data)
        axios.post(`${baseURL}/grupoarvores`, data);
    } catch (error) {
        console.log(error);
    }
};

export const postArvore = (data: any) => {
    try {
        axios.post(`${baseURL}/arvores`, data);
    } catch (error) {
        console.log(error);
    }
};

export const postColheita = (data: any) => {
    try {
        axios.post(`${baseURL}/colheitas`, data);
    } catch (error) {
        console.log(error);
    }
};

