import { useState } from "react";
import './index.less';

function Login({ onSubmitCallback, onCriarNovaConta }) {
    const [loading, setLoading] = useState(false);

    const [loginForm, setLoginForm] = useState({
        email: '',
        senha: '',
    })

    const [errorsForm, setErrorsForm] = useState({
        email: '',
        senha: '',
    })

    const styleAligmentButtom = {
        'display': 'flex',
        'justifyContent': 'end',
        'marginTop': '10px',
    }

    function handleInputChange(identifier, event) {
        setLoginForm(prev => ({
            ...prev,
            [identifier]: event.target.value
        }));
    }

    function handleInputBlur(identifier, event) {
        let errorMessage = "";
        if (identifier == 'password') {
            if (!event.target.value)
                errorMessage = "Campo obrigatório";
        }

        if (identifier == 'email') {
            if (!event.target.value)
                errorMessage = "Campo obrigatório";
            if (!event.target.value.includes('@'))
                errorMessage = "E-mail inválido";
            if (!event.target.value.includes('.com'))
                errorMessage = "E-mail inválido";
        }

        setErrorsForm(prevValues => ({
            ...prevValues,
            [identifier]: errorMessage,
            formsIsValid: !errorMessage,
        }));
    }

    function onSubmit(event) {
        event.preventDefault();
        if (errorsForm.formsIsValid) {
            onSubmitCallback({
                ...loginForm,
                setLoading,
            });
        }

    }


    return <div className="card-login">
        <h3>Login</h3>
        <form className="login-form"
            onSubmit={onSubmit}>
            <div className="form-group mt-2">
                <label className="form-label" htmlFor="email">Email</label>
                <input className="form-control"
                    type="email"
                    name="email"
                    id="email"
                    onChange={(event) => handleInputChange('email', event)}
                    onBlur={(event) => handleInputBlur('email', event)}
                    value={loginForm.email} />
                {errorsForm.email ?? (
                    <div className="invalid-field-form{">
                        {errorsForm.email}
                    </div>
                )}

            </div>

            <div className="form-group mt-2">
                <label className="form-label" htmlFor="senha">Senha</label>
                <input className="form-control"
                    type="password"
                    name="senha"
                    id="senha"
                    onChange={(event) => handleInputChange('senha', event)}
                    onBlur={(event) => handleInputBlur('senha', event)}
                    value={loginForm.senha} />
                {errorsForm.senha ?? (
                    <div className="invalid-field-form{">
                        {errorsForm.senha}
                    </div>
                )}

            </div>


            <div style={styleAligmentButtom}>
                <button className="btn btn-primary">
                    {loading ? <i className="fa-solid fa-spinner fa-spin"></i> : "Entrar"}
                </button>
            </div>
            <p onClick={onCriarNovaConta}>
                Não tenho conta
            </p>
        </form>
    </div>
}


export default Login;