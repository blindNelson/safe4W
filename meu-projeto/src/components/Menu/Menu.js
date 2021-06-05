import React from 'react';
import './Menu.css'
import Logo from '../../assets/imagens/logo.png';

function Menu() {
    return (
        <div>
            <header className="menu-principal">
                <div className="conteudo-margem">
                    <img className="logo" src={Logo} />
                </div>
            </header>
        </div>
    )
}

export default Menu;