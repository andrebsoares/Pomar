import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Arvore } from '../models/Arvore';
import { get } from '../services/api';

const ListArvore = () => {
    const [arvores, setArvores] = useState<Arvore[]>([]);

    useEffect(() => {
        const fetchAPI = async () => {
            setArvores(await get('arvores'));
        }
        fetchAPI();
    }, [arvores]);


    return (
        <div>
            <Link to="/addarvores"><button className="uk-icon-button uk-button-primary" uk-icon="icon: plus; ratio: 1.2"></button></Link>
            <table className="uk-table">
                <caption>Árvores</caption>
                <thead>
                    <tr>
                        <th>Código</th>
                        <th>Descrição</th>
                        <th>Espécie</th>
                        <th>Grupo da árvore</th>
                        <th>Data de plantio</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        arvores?.map(
                            item => {
                                return (
                                    <tr key={item.codigo} className="uk-animation-slide-bottom-medium">
                                        <td className="uk-width-auto">{item.codigo}</td>
                                        <td className="uk-width-auto">{item.descricao}</td>
                                        <td className="uk-width-auto">{item.especie.descricao}</td>
                                        <td className="uk-width-auto">{item.grupoArvore.descricao}</td>
                                        <td className="uk-width-auto">{new Date(item.dataPlantio).toLocaleDateString('pt-BR')}</td>
                                    </tr>
                                )
                            }
                        )
                    }
                </tbody>
            </table>
        </div>
    );
};

export default ListArvore;