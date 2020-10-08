import React from 'react';

const Opcoes = () => {
    return (
        <div className="uk-grid">
            <a href="/especies" className="">
                <div className="uk-card uk-card-hover uk-card-body cursor: pointer;">
                    <h3 className="uk-card-title">Espécie<span uk-icon="icon: list; ratio: 1.2"></span></h3>
                    <p>Cadastro de espécies de árvores</p>
                </div>
            </a>

            <a href="/grupoarvores">
                <div className="uk-card uk-card-hover uk-card-body cursor: pointer;">
                    <h3 className="uk-card-title">Grupo de árvores<span uk-icon="icon: list; ratio: 1.2"></span></h3>
                    <p>Cadastro de grupo de árvores</p>
                </div>
            </a>

            <a href="/arvores">
                <div className="uk-card uk-card-hover uk-card-body cursor: pointer;">
                    <h3 className="uk-card-title">Árvore<span uk-icon="icon: list; ratio: 1.2"></span></h3>
                    <p>Cadastro de árvores</p>
                </div>
            </a>
            <a href="/colheitas">
                <div className="uk-card uk-card-hover uk-card-body cursor: pointer;">
                    <h3 className="uk-card-title">Colheita<span uk-icon="icon: list; ratio: 1.2"></span></h3>
                    <p>Cadastro de colheita</p>
                </div>
            </a>
        </div>
    );
};

export default Opcoes;