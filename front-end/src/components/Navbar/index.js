import React from 'react'
import {Nav, NavLink, Bars, NavMenu, NavBtn, NavBtnLink} from './NavbarElements.js';

const Navbar=()=>{
    return (
        <>
            <Nav>
                <NavLink to="/">
                    <h1>Logo</h1>
                </NavLink>
                <Bars />
                <NavMenu>
                    <NavLink to="/denuncie" activeStyle>
                        Denuncie
                    </NavLink>
                    <NavLink to="/sobre" activeStyle>
                        Sobre
                    </NavLink>
                </NavMenu>
                <NavBtn to="/sigin">
                    <NavBtnLink to="/sigin">cadastre-se</NavBtnLink>
                </NavBtn>
            </Nav>
        </>
    );
};

export default Navbar