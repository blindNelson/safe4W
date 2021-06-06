import React, { Component } from 'react';
import { Switch, Route, Redirect } from 'react-router';
import EnvioDenuncia from '../EnvioDenuncia';
import Cadastro from '../Cadastro';

class Rotas extends Component{
    render(){
        return(
            <Switch>
                <Route exact path="/" component={Cadastro} />
                <Route path="/denuncia" component={EnvioDenuncia} />
                <Redirect from='*' to='/' />
            </Switch>
        )
    }
}

export default Rotas;