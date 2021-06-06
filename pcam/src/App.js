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
        <Menu />
        <Navegacao />
        <Rotas />
      </div>
    </BrowserRouter>
  );
}

export default App;
