import React, { useEffect, useState } from 'react';
import { yupResolver } from '@hookform/resolvers';
import * as yup from 'yup';
import { useForm } from 'react-hook-form';
import { Colheita } from '../models/Colheita';
import { Arvore } from '../models/Arvore';
import { get, postColheita } from '../services/api';

const schema = yup.object().shape({
    informacoes: yup.string().required('Campo obrigatório'),
    dataColheita: yup.date().required('Campo obrigatório'),
    pesoBruto: yup.number().required('Campo obrigatório'),
    arvore: yup.number().required('Campo obrigatório'),
});

const AddColheita = () => {
    const [arvores, setArvores] = useState<Arvore[]>([]);

    const [arvoresSelect, setArvoresSelect] = useState([
        { arvoreId: 0 }
    ]);

    function addArvoresSelect() {
        setArvoresSelect([...arvoresSelect, {
            arvoreId: 1
        }])
    }

    function setArraySelect(position: number, field: string, value: number) {
        const updatedArvores = arvoresSelect.map((arv, index) => {
            if (index === position) {
                return { ...arv, [field]: value }
            }

            return arv;
        })

        setArvoresSelect(updatedArvores);
    }

    const fetchAPI = async () => {
        setArvores(await get('arvores'));
    };

    useEffect(() => {
        fetchAPI();
    }, []);

    const { register, handleSubmit, errors } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data: Colheita, e: any) => {
        const { informacoes, dataColheita, pesoBruto } = data;
        postColheita({
            informacoes,
            dataColheita,
            pesoBruto,
            colheitaArvores: arvoresSelect
        });
        e.target.reset();
        window.location.href = '/colheitas';
    };

    return (
        <form onSubmit={handleSubmit<Colheita>(onSubmit)}>
            <h4>Nova Colheita</h4>
            <div className="uk-margin uk-width-1-1">
                <input autoComplete="off" type="text" name="informacoes" id="informacoes" placeholder="Informações da colheita" className="uk-input" ref={register} />
                <span><small><strong className="uk-text-danger">{errors.informacoes?.message}</strong></small></span>
            </div>
            <div className="uk-margin uk-width-1-1">
                <p>Data da colheita</p>
                <input autoComplete="off" type="date" name="dataColheita" id="dataColheita" placeholder="Data da colheita" className="uk-input" ref={register} />
                <span><small><strong className="uk-text-danger">{errors.dataColheita?.message}</strong></small></span>
            </div>
            <div className="uk-margin uk-width-1-1">
                <p>Peso bruto</p>
                <input autoComplete="off" step="any" type="number" name="pesoBruto" id="pesoBruto" placeholder="Peso bruto (ex: 10.50)" className="uk-input" ref={register} />
                <span><small><strong className="uk-text-danger">{errors.pesoBruto?.message}</strong></small></span>
            </div>

            <div className="uk-margin uk-width-1-1">
                <button type='button' onClick={addArvoresSelect} className="uk-button-primary " >
                    Adicionar Árvore
                </button>
                {arvoresSelect.map((item, index) => {
                    return (
                        <select className="uk-select" key={item.arvoreId + index} value={item.arvoreId} onChange={(e) => setArraySelect(index, 'arvoreId', Number(e.target.value))} name="arvore" ref={register}>
                            <option defaultValue="">Selecione uma árvore para colheita</option>
                            {
                                arvores?.map(
                                    item => {
                                        return (
                                            <option value={item.codigo} key={item.codigo}>{item.descricao}</option>
                                        )
                                    }
                                )
                            }
                        </select>
                    )
                })}
            </div>

            <div className="uk-width-1-1">
                <button type="submit" className="uk-button uk-button-primary">Salvar</button>
            </div>

        </form>
    );
};

export default AddColheita;