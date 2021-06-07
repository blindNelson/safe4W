import Denuncia from './Denuncia';
import React, { Component } from 'react';

import './EnvioDenuncia.css';


export default class EnvioDenuncia extends Component {

    render() {
        return (
            <div className="conteudo">
                <h1>Denuncie!!!</h1>
                <Denuncia/>
            </div>
        )
    }
}