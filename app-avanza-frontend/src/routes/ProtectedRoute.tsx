// src/routes/ProtectedRoute.tsx
import React from 'react';
import { Navigate, Outlet, useLocation } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext'; // Ajusta la ruta si es necesario
import { Box, CircularProgress } from '@mui/material'; // Para el spinner

interface ProtectedRouteProps {
    // Si se quieren pasar roles permitidos específicos en el futuro
    // allowedRoles?: string[];
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = (/*{ allowedRoles }*/) => {
    const { isAuthenticated, isLoading, user } = useAuth(); // user es opcional aquí, pero puede ser útil para roles
    const location = useLocation();

    if (isLoading) {
        // Muestra un spinner centrado mientras se verifica el estado de autenticación
        return (
            <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
                <CircularProgress />
            </Box>
        );
    }

    if (!isAuthenticated) {
        // Redirige al login, guardando la ubicación actual para posible redirección post-login
        return <Navigate to="/login" state={{ from: location }} replace />;
    }

    // Lógica opcional para roles si se implementa en el futuro:
    // if (allowedRoles && user && !allowedRoles.includes(user.rol)) {
    //     // Usuario autenticado pero no tiene el rol correcto
    //     return <Navigate to="/unauthorized" replace />; // O a una página de 'No Autorizado'
    // }

    // Si está autenticado (y si los roles son correctos), renderiza el contenido de la ruta hija
    return <Outlet />;
};

export default ProtectedRoute;
