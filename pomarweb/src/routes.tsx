import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import AddArvore from './components/AddArvore';
import AddColheita from './components/AddColheita';
import AddEspecie from './components/AddEspecie';
import AddGrupoArvore from './components/AddGrupoArvore';
import ListArvore from './components/ListArvore';
import ListColheita from './components/ListColheita';
import ListEspecie from './components/ListEspecie';
import ListGrupoArvore from './components/ListGrupoArvore';
import Opcoes from './components/Opcoes';

const Routes = () => {
    return (
        <BrowserRouter>
            <Route path="/" exact component={Opcoes}></Route>
            <Route path="/especies" component={ListEspecie}></Route>
            <Route path="/addespecies" component={AddEspecie}></Route>
            <Route path="/grupoarvores" component={ListGrupoArvore}></Route>
            <Route path="/addgrupoarvores" component={AddGrupoArvore}></Route>
            <Route path="/arvores" component={ListArvore}></Route>
            <Route path="/addarvores" component={AddArvore}></Route>
            <Route path="/colheitas" component={ListColheita}></Route>
            <Route path="/addcolheitas" component={AddColheita}></Route>
        </BrowserRouter>
    );
};

export default Routes;