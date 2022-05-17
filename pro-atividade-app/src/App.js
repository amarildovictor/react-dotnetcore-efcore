import { useState, useEffect } from 'react';
import './App.css';
import AtividadeForm from './components/AtividadeForm';
import AtividadeLista from './components/AtividadeLista';

let initialState = [
  {
    id: 1,
    prioridade: '1',
    titulo: 'Título 1',
    descricao: 'Primeira'
  },
  {
    id: 2,
    prioridade: '2',
    titulo: 'Título 2',
    descricao: 'Segunda'
  }
];

function App() {
  const [index, setIndex] = useState(0);
  const [atividades, setAtividades] = useState(initialState);
  const [atividade, setAtividade] = useState({id: 0});
  
  useEffect(() => {
    atividades.length <=0 ? setIndex(1) : setIndex(Math.max.apply(Math, atividades.map(ativ => ativ.id)) + 1)
  }, [atividades])

  function addAtividade(ativ){
    setAtividades([ ...atividades, 
      { ...ativ, id: index }]
      );
  }

  function cancelarAtividade(){
    setAtividade({id: 0});
  }

  function atualizarAtividade(ativ) {
    setAtividades(atividades.map(item => item.id === ativ.id ? ativ : item));
    setAtividade({id: 0});
  }

  function excluirAtividade(id){
    const atividadesFiltradas = atividades.filter(atividade => atividade.id !== id);
    setAtividades([...atividadesFiltradas]);
  }

  function pegarAtividade(id){
    const atividade = atividades.filter(atividade => atividade.id === id);
    setAtividade(atividade[0]);
  }

  return (
    <>
      <AtividadeForm 
        addAtividade = {addAtividade}
        atualizarAtividade = {atualizarAtividade}
        cancelarAtividade= {cancelarAtividade}
        ativSelecionada = {atividade}
        atividades = {atividades}
      />
      <AtividadeLista
        atividades = {atividades}
        excluirAtividade = {excluirAtividade}
        pegarAtividade={pegarAtividade}
      />
    </>
  );
}

export default App;
