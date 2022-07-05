import React from 'react'
import AtividadeItem from './AtividadeItem';

export default function AtividadeLista(props) {
    return (
        <div className="mt-3">
          { props.atividades.map(ativ => (
            <AtividadeItem
              pegarAtividade={props.pegarAtividade}
              ativ = {ativ}
              handleConfirmModal={props.handleConfirmModal}
            />
          )) }
        </div>
    )
}
