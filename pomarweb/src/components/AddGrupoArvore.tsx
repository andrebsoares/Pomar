import React from 'react';
import { yupResolver } from '@hookform/resolvers';
import * as yup from 'yup';
import { useForm } from 'react-hook-form';
import { postGrupoArvore } from '../services/api';
import { GrupoArvore } from '../models/GrupoArvore';

const schema = yup.object().shape({
    descricao: yup.string().required('Descrição obrigatória'),
});

const AddGrupoArvore = () => {
    const { register, handleSubmit, errors } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data: GrupoArvore, e: any) => {
        postGrupoArvore(data);
        e.target.reset();
        window.location.href = '/grupoarvores';
    }

    return (
        <form onSubmit={handleSubmit<GrupoArvore>(onSubmit)}>
            <h4>Novo grupo de árvore</h4>
            <div className="uk-margin uk-width-1-1">
                <input type="text" name="descricao" id="descricao" placeholder="Descrição do novo grupo de árvore" className="uk-input" autoComplete="off" ref={register} />
                <span><small><strong className="uk-text-danger">{errors.descricao?.message}</strong></small></span>
            </div>
            <div className="uk-width-1-1">
                <button type="submit" className="uk-button uk-button-primary">Salvar</button>
            </div>
        </form>
    );
};

export default AddGrupoArvore;
