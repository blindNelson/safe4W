import React from 'react';
import './Navegacao.css';

function Navegacao() {
    return (
        <nav className="navegacao">
            <div className="conteudo-margem">
                <div className="menu-navegacao">
                    <ul>
                        <li>
                            <a href="">Início</a>
                        </li>
                        <li>
                            <a href="">Apoio</a>
                        </li>
                        <li>
                            <a href="">Conscitentização</a>
                        </li>
                        <li>
                            <a href="">Denúncia</a>
                        </li>
                    </ul>
                </div>
                <div className="busca">
                    <input type="text" placeholder="Pesquise algo" />
                </div>
            </div>
        </nav>
    )
}

export default Navegacao;