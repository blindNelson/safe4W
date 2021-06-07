import React from 'react';
import './Navegacao.css';
import Logo from '../../assets/imagens/logo.png';

function Navegacao() {
    return (
        <div>
            <header className="menu-principal">
                <div className="conteudo-margem">
                    <img className="logo" src={Logo} />
                </div>
            </header>
            <nav className="navegacao">
                <div className="conteudo-margem">
                    <div className="menu-navegacao">
                        <ul>
                            <li>
                                <a href="/">Início</a>
                            </li>
                            <li>
                                <a href="">Apoio</a>
                            </li>
                            <li>
                                <a href="/denuncia">Denuncia</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

        </div>

    )
}

export default Navegacao;