import React from 'react';
import { BrowserRouter as Router, Routes, Route, Outlet } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import RegisterPage from '../pages/RegisterPage';
import DashboardFacilitadorPage from '../pages/DashboardFacilitadorPage';
import DashboardAprendizPage from '../pages/DashboardAprendizPage';
import EvaluacionPage from '../pages/EvaluacionPage';
import NotFoundPage from '../pages/NotFoundPage';
import Navbar from '../components/layout/Navbar';
import Footer from '../components/layout/Footer';  // Assuming Footer is wanted for all layouts
import ProtectedRoute from './ProtectedRoute';
import { Box, Container } from '@mui/material'; // Para layout

// Layout para rutas públicas (ej. Login, Register) - sin Navbar o con una diferente
const PublicLayout: React.FC = () => {
    return (
        <Box sx={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
            {/* Podría tener una Navbar minimalista si se desea */}
            <Container component="main" sx={{ flexGrow: 1, py: 3 }}> {/* py for padding top/bottom */}
                <Outlet /> {/* Aquí se renderizarán las páginas públicas */}
            </Container>
            <Footer />
        </Box>
    );
};


// Componente de Layout para rutas protegidas (Navbar + Contenido)
const ProtectedLayout: React.FC = () => {
    return (
        <Box sx={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
            <Navbar />
            {/* Container para centrar y limitar el ancho del contenido principal */}
            <Container component="main" sx={{ flexGrow: 1, py: 3 }}>
                <Outlet /> {/* Aquí se renderizarán las rutas hijas protegidas */}
            </Container>
            <Footer />
        </Box>
    );
};

const AppRouter: React.FC = () => {
    return (
        <Router>
            <Routes>
                {/* Rutas Públicas con su propio layout (o sin layout específico si se prefiere) */}
                <Route element={<PublicLayout />}>
                    <Route path="/login" element={<LoginPage />} />
                    <Route path="/register" element={<RegisterPage />} />
                </Route>

                {/* Rutas Protegidas */}
                <Route element={<ProtectedRoute />}> {/* Elemento padre para verificar auth */}
                    <Route element={<ProtectedLayout />}> {/* Layout para las rutas protegidas */}
                        <Route path="/facilitador" element={<DashboardFacilitadorPage />} />
                        <Route path="/aprendiz/:aprendizId" element={<DashboardAprendizPage />} />
                        <Route path="/evaluacion/:aprendizId" element={<EvaluacionPage />} />
                        {/* Ruta de inicio si el usuario está logueado y va a "/" */}
                        {/* Esta ruta raíz DENTRO de ProtectedRoute manejará el caso de usuario logueado yendo a "/" */}
                        <Route path="/" element={<DashboardFacilitadorPage />} />
                    </Route>
                </Route>

                {/* Ruta para página no encontrada */}
                {/* Para que NotFoundPage tenga un layout, podría estar dentro de un Route que aplique el layout deseado */}
                {/* o se le añade el layout directamente dentro del componente NotFoundPage */}
                <Route path="*" element={<NotFoundPage />} />
            </Routes>
        </Router>
    );
};
export default AppRouter;
