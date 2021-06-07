import React from 'react';
import './Denuncia.css'

const apiURL = '';
const stateInicial = {
    denuncia: { nomeVitima: '', nomeAgressor: '', relacao: 0, descricao: '' },
    dadosDenuncias: []
}

export default class Denuncia extends React.Component{
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

                <table className="content">
                    <tr>
                        <td>
                            <input className="recebebores" type="text"  id="nomeVitima"  placeholder="Nome da Vítima"/>
                        </td>
                        <td>
                            <input className="recebebores" type="text"id="nomeAgressor" placeholder="Nome do agressor"/>
                        </td>
                        <td>
                            <select className="recebebores">
                                <option>desconhecidos</option>
                                <option>conhecidos</option>
                                <option>familiar</option>
                                <option>cônjuge</option>
                                <option>proximos</option>
                            </select>
                        </td>
                        <td>
                            <select className="recebebores">
                                <option>norte</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colSpan="4">
                            <textarea rows="15" style={{width:"100%"}} id="descricao" placeholder="Descrição da agressão"className="form-input" />
                        </td>
                    </tr>
                </table>
                <br/>     
                <br/>

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

    render(){
        return <div>{this.renderForm()}</div>
    }
}