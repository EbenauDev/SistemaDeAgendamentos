import { useState } from "react";
import './index.less';
import axios from "axios";

function NovoCadastro() {
    const [loadingForm, setLoadingForm] = useState(false);
    const [formNovoCadastro, setFormNovoCadastro] = useState({
        nome: '',
        email: '',
        celular: '',
    });

    const [errorsForm, setErrorsForm] = useState({
        nome: null,
        email: null,
        formsIsValid: true,
    })

    async function cadastrarPessoa(formData) {
        formData.preventDefault();
        if (!errorsForm.formsIsValid) return;
        try {
            setLoadingForm(() => true);
            await axios.post('http://localhost:5001/api/pessoa', formNovoCadastro);
        } catch (e) {
            console.error(e);
        }
        finally {
            setLoadingForm(() => false);
        }
    }

    function handleInputChange(identifier, event) {
        setFormNovoCadastro(prevValues => ({ ...prevValues, [identifier]: event.target.value }));
    }

    function handleInputBlur(identifier, event) {
        let errorMessage = "";
        if (identifier == 'nome') {
            if (!event.target.value)
                errorMessage = "Nome deve ser informado";
            if (event.target.value.length < 3)
                errorMessage = "Nome deve ser maior que 2 caracteres";
        }

        if (identifier == 'email') {
            if (!event.target.value)
                errorMessage = "E-mail é obrigatório";
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

    const formulario = <form className="novo-cadastro-form" name="novoCadastro" onSubmit={cadastrarPessoa}>
        <div className="form-group">
            <label className="form-label" htmlFor="nome">Nome</label>
            <input className="form-control" type="text"
                name="nome"
                id="nome"
                onChange={(event) => handleInputChange('nome', event)}
                onBlur={(event) => handleInputBlur('nome', event)}
                value={formNovoCadastro.nome} />
            {errorsForm.nome ?? (
                <p className="invalid-feedback">
                    {errorsForm.nome}
                </p>
            )}
        </div>
        <div className="form-group mt-2">
            <label className="form-label" htmlFor="email">Email</label>
            <input className="form-control"
                type="email"
                name="email"
                id="email"
                onChange={(event) => handleInputChange('email', event)}
                onBlur={(event) => handleInputBlur('email', event)}
                value={formNovoCadastro.email} />
            {errorsForm.email ?? (
                <p className="invalid-feedback">
                    {errorsForm.email}
                </p>
            )}
        </div>
        <div className="form-group mt-2">
            <label className="form-label" htmlFor="celular">Celular</label>
            <input className="form-control" type="tel"
                name="celular"
                id="celular"
                onChange={(event) => handleInputChange('celular', event)}
                value={formNovoCadastro.celular} />
        </div>
        <div className="mt-3">
            <button className="btn btn-primary">Salvar</button>
        </div>
    </form>;

    return (
        <div className="card-novo-cadastro">
            <h1>Novo cadastro</h1>
            {loadingForm ? <>
                <h1>Salvando cadastro</h1>
            </> : formulario}
        </div>
    )
}

export default NovoCadastro;