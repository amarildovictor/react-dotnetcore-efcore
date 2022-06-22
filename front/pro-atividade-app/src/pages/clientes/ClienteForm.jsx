import React from 'react'
import TitlePage from './../../components/TitlePage';
import { Button } from 'react-bootstrap';
import { useNavigate, useParams } from 'react-router-dom';

export default function ClienteForm() {
  const history = useNavigate();
  let { id } = useParams();
  
  return (
    <>
        <TitlePage title={'Cliente Detalhes ' + (id !== undefined ? id : '')}>
          <Button variant='outline-secondary' onClick={() => history('/cliente/lista')}>
            <i className='fas fa-arrow-left me-1'></i>
            Voltar
          </Button>
        </TitlePage>
        <div></div>
    </>
  )
}
