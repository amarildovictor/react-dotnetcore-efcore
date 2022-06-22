import React from 'react'
import Atividade from './AtividadeItem';

export default function AtividadeLista(props) {
    return (
        <div className="mt-3">
          { props.atividades.map(ativ => (
            <Atividade
              pegarAtividade={props.pegarAtividade}
              ativ = {ativ}
              handleConfirmModal={props.handleConfirmModal}
            />
          )) }
        </div>
    )
}
