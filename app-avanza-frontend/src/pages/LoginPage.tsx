import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import LoginForm from '../components/auth/LoginForm'; // Corrected import path
import { useAuth } from '../contexts/AuthContext';
import { Container, Typography, Box, CircularProgress } from '@mui/material';

const LoginPage: React.FC = () => {
    const { isAuthenticated, isLoading, user } = useAuth();
    const navigate = useNavigate();

    useEffect(() => {
        if (!isLoading && isAuthenticated) {
            // Potentially redirect based on user role
            if (user?.rol === 'Facilitador') { // Assuming rol is a string from your User model
                navigate('/facilitador');
            } else if (user?.rol === 'Aprendiz') { // Example, if you add Aprendiz role
                navigate(`/aprendiz/${user.id}`); // Needs user.id if an Aprendiz logs in this way
            } else {
                navigate('/'); // Fallback or a generic dashboard
            }
        }
    }, [isAuthenticated, isLoading, user, navigate]);

    if (isLoading) {
        return (
            <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
                <CircularProgress />
            </Box>
        );
    }

    // If already authenticated and not loading, this component might briefly render before redirect.
    // Or, you can return null if isAuthenticated is true and isLoading is false,
    // as the useEffect will handle the redirect.
    if (isAuthenticated) {
        return null;
    }


    return (
        <Container component="main" maxWidth="xs">
            <Box
                sx={{
                    marginTop: 8,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}
            >
                <Typography component="h1" variant="h5">
                    Iniciar Sesión
                </Typography>
                <LoginForm />
            </Box>
        </Container>
    );
};
export default LoginPage;
