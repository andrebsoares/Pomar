import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { GrupoArvore } from '../models/GrupoArvore';
import { get } from '../services/api';

const ListGrupoArvore = () => {
    const [grupoArvores, setgrupoArvores] = useState<GrupoArvore[]>([]);

    useEffect(() => {
        const fetchAPI = async () => {
            setgrupoArvores(await get('grupoarvores'));
        }
        fetchAPI();
    }, []);

    return (
        <div>
            <Link to="/addgrupoarvores"><button className="uk-icon-button uk-button-primary" uk-icon="icon: plus; ratio: 1.2"></button></Link>
            <table className="uk-table">
                <caption>Grupos de Árvores</caption>
                <thead>
                    <tr>
                        <th>Código</th>
                        <th>Descrição</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        grupoArvores?.map(
                            item => {
                                return (
                                    <tr key={item.codigo} className="uk-animation-slide-bottom-medium">
                                        <td className="uk-width-auto">{item.codigo}</td>
                                        <td className="uk-width-expand">{item.descricao}</td>
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

export default ListGrupoArvore;