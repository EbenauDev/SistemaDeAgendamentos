import { createBrowserRouter } from 'react-router';
import App from './App';
import NovoCadastro from './modules/nao-autenticado/pages/novo-cadstro';

const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
    },
    {
        path:'/novo-cadastro',
        element: <NovoCadastro/>,
    }
]);

export default router;