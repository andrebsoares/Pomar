import React, { createContext } from 'react';
import { Especie } from '../models/Especie';
import { ContextBase } from './ContextBase';

export const EspecieContext = createContext<ContextBase<Especie>>({
    obj: [],
    add: () => { }
});

const TodoProvider = (props: any) => {
    const obj: Especie[] = [];

    const add = (obj: Especie) => {
        console.log(obj);
    };

    return (
        <EspecieContext.Provider value={{ obj, add }}>
            {props.children}
        </EspecieContext.Provider>
    )
};

export default TodoProvider;