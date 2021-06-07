import React, { Component } from 'react';
import { Switch, Route, Redirect } from 'react-router';
import { BrowserRouter } from 'react-router-dom';
import Menu from './components/Menu/Menu.js';
import Navegacao from './components/Navegacao';
import Rotas from './components/Rotas/Rotas.js';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Navegacao />
        <div className="Conteudo">
          <Rotas />
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;
