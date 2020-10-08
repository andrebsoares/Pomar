import React, { useEffect, useState } from 'react';
import * as yup from 'yup';
import { yupResolver } from '@hookform/resolvers';
import { useForm } from 'react-hook-form';
import { get, postArvore } from '../services/api';
import { Arvore } from '../models/Arvore';
import { Especie } from '../models/Especie';
import { GrupoArvore } from '../models/GrupoArvore';

const schema = yup.object().shape({
    descricao: yup.string().required('Campo Obrigatório'),
    dataPlantio: yup.date().required('Campo Obrigatório'),
    especieId: yup.number().required('Campo Obrigatório'),
    grupoArvore: yup.number().required('Campo Obrigatório'),
});

const AddArvore = () => {
    const [especieId, setEspecieId] = useState('');
    const [grupoArvoreId, setGrupoArvoreId] = useState('');

    const [especies, setEspecies] = useState<Especie[]>([]);
    const [grupoarvores, setgrupoarvores] = useState<GrupoArvore[]>([]);

    const fetchAPIGrupoArvore = async () => {
        setgrupoarvores(await get('grupoarvores'));
    };

    const fetchAPIEspecies = async () => {
        setEspecies(await get('especies'));
    };

    useEffect(() => {
        fetchAPIGrupoArvore();
        fetchAPIEspecies();
    }, []);

    const { register, handleSubmit, errors } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data: Arvore, e: any) => {
        const { descricao, dataPlantio } = data;
        postArvore({
            descricao,
            dataPlantio,
            especieId,
            grupoArvoreId
        });
        e.target.reset();
        window.location.href = '/arvores';
    };

    return (
        <form onSubmit={handleSubmit<Arvore>(onSubmit)}>
            <h4>Nova árvore</h4>
            <div className="uk-margin uk-width-1-1">
                <input autoComplete="off" type="text" name="descricao" id="descricao" placeholder="Descrição nova da árvore" className="uk-input" ref={register} />
                <span><small><strong className="uk-text-danger">{errors.descricao?.message}</strong></small></span>

            </div>
            <p>Data do plantio</p>
            <div className="uk-margin uk-width-1-1">
                <input autoComplete="off" type="date" name="dataPlantio" id="dataPlantio" placeholder="Data do plantio" className="uk-input" ref={register} />
                <span><small><strong className="uk-text-danger">{errors.dataPlantio?.message}</strong></small></span>
            </div>

            <div className="uk-margin uk-width-1-1">
                <p>Espécie da árvore</p>
                <select className="uk-select" value={especieId} onChange={(e) => { setEspecieId(e.target.value) }} name="especieId" ref={register}>
                    <option value="">Selecione uma espécie</option>
                    {
                        especies?.map(
                            item => {
                                return (
                                    <option value={item.codigo} key={item.codigo}>{item.descricao}</option>
                                )
                            }
                        )
                    }
                    {errors.exampleRequired && <span>This field is required</span>}
                </select>
            </div>

            <div className="uk-margin uk-width-1-1">
                <p>Grupo da árvore</p>
                <select className="uk-select" value={grupoArvoreId} onChange={(e) => { setGrupoArvoreId(e.target.value) }} name="grupoArvore" ref={register}>
                    <option value="">Selecione um grupo de árvore</option>
                    {
                        grupoarvores?.map(
                            item => {
                                return (
                                    <option value={item.codigo} key={item.codigo}>{item.descricao}</option>
                                )
                            }
                        )
                    }
                </select>
            </div>

            <div className="uk-width-1-1">
                <button type="submit" className="uk-button uk-button-primary">Salvar</button>
            </div>
        </form>
    );
};

export default AddArvore;