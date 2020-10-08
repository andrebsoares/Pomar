import React from 'react';
import { yupResolver } from '@hookform/resolvers';
import * as yup from 'yup';
import { useForm } from 'react-hook-form';
import { postEspecie } from '../services/api';
import { Especie } from '../models/Especie';


const schema = yup.object().shape({
    descricao: yup.string().required('Descrição obrigatória'),
});

const AddEspecie = () => {
    const { register, handleSubmit, errors } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data: Especie, e: any) => {
        postEspecie(data);
        e.target.reset();
        window.location.href = '/especies';
    }

    return (
        <form onSubmit={handleSubmit<Especie>(onSubmit)}>
            <h4>Nova espécie</h4>
            <div className="uk-margin uk-width-1-1">
                <input autoComplete="off" type="text" name="descricao" id="descricao" placeholder="Descrição da nova espécie" className="uk-input" ref={register} />
                <span><small><strong className="uk-text-danger">{errors.descricao?.message}</strong></small></span>
            </div>
            <div className="uk-width-1-1">
                <button type="submit" className="uk-button uk-button-primary">Salvar</button>
            </div>
        </form>
    );
};

export default AddEspecie;