import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Colheita } from '../models/Colheita';
import { get } from '../services/api';

const ListColheita = () => {
    const [colheita, setColheita] = useState<Colheita[]>([]);

    useEffect(() => {
        const fetchApi = async () => {
            setColheita(await get('colheitas'));
        };

        fetchApi();
    }, []);

    return (
        <div>
            <Link to="/addcolheitas"><button className="uk-icon-button uk-button-primary" uk-icon="icon: plus; ratio: 1.2"></button></Link>
            <table className="uk-table">
                <caption>Colheitas</caption>
                <thead>
                    <tr>
                        <th>Código</th>
                        <th>Árvore</th>
                        <th>Espécie</th>
                        <th>Infomações</th>
                        <th>Data da colheita</th>
                        <th>Peso bruto</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        colheita?.map(
                            item => {
                                return (
                                    item.colheitaArvores?.map(
                                        col => {
                                            return (
                                                <tr key={col.codigo} className="uk-animation-slide-bottom-medium">
                                                    <td className="uk-width-auto">{col.codigo}</td>
                                                    <td className="uk-width-auto">{col.arvore.descricao}</td>
                                                    <td className="uk-width-auto">{col.arvore.especie.descricao}</td>
                                                    <td className="uk-width-auto">{item.informacoes}</td>
                                                    <td className="uk-width-auto">{new Date(item.dataColheita).toLocaleDateString('pt-BR')}</td>
                                                    <td className="uk-width-auto">{item.pesoBruto}</td>
                                                </tr>
                                            )
                                        }
                                    )

                                )
                            }
                        )
                    }
                </tbody>
            </table>
        </div>
    );
};

export default ListColheita;