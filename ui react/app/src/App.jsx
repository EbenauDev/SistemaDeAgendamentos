import { useNavigate } from "react-router";



function App() {
  const navigate = useNavigate();

  function novoCadastro(){
    navigate('/novo-cadastro');
  }

  return (
    <div>
       <h1>Olá mundo</h1>
       <button onClick={novoCadastro}>Criar conta</button>
    </div>
  )
}

export default App
