import React from 'react';
import EnvioDenuncia from './components/EnvioDenuncia/EnvioDenunca.js';
import Menu from './components/Menu/Menu.js';
import Navegacao from './components/Navegacao/Navegacao.js';

function App() {
  return (
    <div className="App">
      <Menu />
      <Navegacao />
      <EnvioDenuncia />
    </div>
  );
}

export default App;
