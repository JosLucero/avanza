import React from 'react';
// import { useNavigate } from 'react-router-dom'; // Opcional: si se quiere redirigir si ya está logueado
// import { useAuth } from '../contexts/AuthContext'; // Opcional
import RegisterForm from '../components/auth/RegisterForm';
import { Container, Typography, Box, Paper } from '@mui/material';

const RegisterPage: React.FC = () => {
    // const { isAuthenticated, isLoading } = useAuth(); // Opcional
    // const navigate = useNavigate(); // Opcional

    // useEffect(() => { // Opcional: Redirigir si ya está logueado
    //     if (!isLoading && isAuthenticated) {
    //         navigate('/facilitador'); // o a donde sea apropiado
    //     }
    // }, [isAuthenticated, isLoading, navigate]);

    // if (isLoading) { // Opcional: Mostrar un spinner mientras se verifica el estado de auth
    //     return (
    //         <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
    //             <CircularProgress />
    //         </Box>
    //     );
    // }
    // Si ya está autenticado y no está cargando, y se decide redirigir, podría retornar null aquí.
    // if (isAuthenticated) return null;


    return (
        <Container component="main" maxWidth="xs">
            <Paper elevation={3} sx={{ padding: { xs: 2, sm: 3 }, marginTop: 8 }}> {/* Responsive padding */}
                <Box
                    sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Typography component="h1" variant="h5">
                        Crear Cuenta de Facilitador
                    </Typography>
                    <RegisterForm />
                </Box>
            </Paper>
        </Container>
    );
};
export default RegisterPage;
