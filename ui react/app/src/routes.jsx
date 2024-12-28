import { createBrowserRouter } from 'react-router';
import Entrada from './modules/entrada/pages/entrada';
import VisaoGeral from './modules/socio/pages/visao-geral/visao-geral';

const router = createBrowserRouter([
    {
        path: '/',
        element: <Entrada />,
    },
    {
        path:'/visao-geral',
        element: <VisaoGeral/>
    }
]);

export default router;