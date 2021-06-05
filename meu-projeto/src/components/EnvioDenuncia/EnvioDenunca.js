import React, { Component } from 'react';
import './EnvioDenuncia.css';

// COLOCAR URL
const apiURL = '';
const stateInicial = {
    denuncia: { nomeVitima: '', nomeAgressor: '', relacao: 0, descricao: '' },
    dadosDenuncias: []
}


export default class EnvioDenuncia extends Component {

    state = { ...stateInicial };

    limpar() {
        this.setState({ denuncia: stateInicial.denuncia });
    }

    salvar() {
        const denuncia = this.state.denuncia;
        const metodo = denuncia.id ? 'put' : 'post';
        const url = denuncia.id ? `${apiURL}/${denuncia.id}` : apiURL;
        fetch(url, {
            method: metodo,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(denuncia)
        })
            .then(
                resp => {
                    //console.log(resp.json());
                    resp.json().then((data) => {
                        console.log(data);
                        const listaDenuncias = this.getListaAtualizada(data);
                        this.setState({

                            denuncia: stateInicial.denuncia, dadosDenuncias: listaDenuncias
                        });

                    })
                })
    }

    getListaAtualizada(denuncia) {
        const lista = this.state.dadosDenuncias.filter(d => d.id !== denuncia.id);
        lista.unshift(denuncia);
        return lista;
    }

    atualizaCampo(event) {
        //clonar usuário a partir do state, para não alterar o state diretamente
        const denuncia = { ...this.state.denuncia };
        //usar o atributo NAME do input identificar o campo a ser atualizado
        denuncia[event.target.name] = event.target.value;
        //atualizar o state
        this.setState({ denuncia });
    }

    renderForm() {
        return (
            <div className="inclui-form">
                <label> Nome da Vitima: </label>
                <input
                    type="text"
                    id="nomeVitima"
                    placeholder="Nome da Vitima"
                    className="form-input"
                    name="nomeVitima"
                    value={this.state.denuncia.nomeVitima}
                    onChange={e => this.atualizaCampo(e)}
                />
                <br />
                <label> Nome do Agressor: </label>
                <input
                    type="text"
                    id="nomeAgressor"
                    placeholder="Nome do agressor"
                    className="form-input"
                    name="nomeAgressor"
                    value={this.state.denuncia.nomeAgressor}
                    onChange={e => this.atualizaCampo(e)}
                />
                <br />
                <label> Relacao: </label>
                <input
                    type="text"
                    id="relacao"
                    placeholder="Relacao vitima-agressor"
                    className="form-input"
                    name="relacao"
                    value={this.state.denuncia.relacao}
                    onChange={e => this.atualizaCampo(e)}
                />
                <br />
                <label> Descricao: </label>
                <input
                    type="text"
                    id="descricao"
                    placeholder="Descricao da agressao"
                    className="form-input"
                    name="descricao"
                    value={this.state.denuncia.descricao}
                    onChange={e => this.atualizaCampo(e)}
                />
                <br />
                <button className="btnEnviar"
                    onClick={e => this.salvar(e)} >
                    Enviar
                </button>
                <button className="btnCancelar"
                    onClick={e => this.limpar(e)} >
                    Cancelar
                </button>
            </div>
        )
    }

    render() {
        return (
            <div>
                {this.renderForm()}
            </div>
        )
    }
}