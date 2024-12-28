import { useState } from "react";
import Login from "../../../components/login/login";
import NovoCadastro from "../components/novo-cadastro/novo-cadastro";
import Snackbar from "../../../components/snack-bar";
import axios from "axios";
import './entrada.less';

function Entrada() {
  const [exibirLogin, setExibirLogin] = useState(true);
  const [snackbarState, setSnackbarState] = useState({
    children: null,
    type: "",
    open: false,
  })

  function onToggleExibirLogin() {
    setExibirLogin(prev => (prev = !prev));
  }

  async function realizarLogin(loginResponse) {
    console.log(loginResponse);
    const { email, senha, setLoading } = loginResponse;
    try {
      setLoading(true);
      var resultado = await axios.post('http://localhost:5001/api/autenticacao', {
        email, senha,
      });
      setSnackbarState(prev => ({
        open: true,
        children: <span>Login realizado com sucesso</span>,
        type: 'success'
      }))
    } catch ({ response }) {
      setSnackbarState(prev => ({
        open: true,
        children: <span>{response.data?.mensagem}</span>,
        type: 'error'
      }))
    }
    finally {
      setLoading(false);
    }

  }

  return (
    <div className="card-visao-geral">
      <h1>
        Sistema de Agendamento
      </h1>
      {exibirLogin ?
        <Login onCriarNovaConta={onToggleExibirLogin} onSubmitCallback={realizarLogin} /> :
        <NovoCadastro onCancelarNovaConta={onToggleExibirLogin} />}

      <Snackbar {...snackbarState} onClose={() => {
        setSnackbarState(prev => ({
          ...prev,
          open: false,
        }))
      }}></Snackbar>
    </div>
  )
}

export default Entrada;