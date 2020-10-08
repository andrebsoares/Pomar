import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Especie } from '../models/Especie';
import { get } from '../services/api';

const ListEspecie = () => {
    const [especies, setEspecies] = useState<Especie[]>([]);

    useEffect(() => {
        const fetchAPI = async () => {
            setEspecies(await get('especies'));
        }
        fetchAPI();
    }, [especies]);

    return (
        <div>
            <Link to="/addespecies"><button className="uk-icon-button uk-button-primary" uk-icon="icon: plus; ratio: 1.2"></button></Link>
            <table className="uk-table">
                <caption>Espécies</caption>
                <thead>
                    <tr>
                        <th>Código</th>
                        <th>Descrição</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        especies?.map(
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

export default ListEspecie;