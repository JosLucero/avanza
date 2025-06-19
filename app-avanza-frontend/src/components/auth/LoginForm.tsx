import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import { loginApi } from '../../services/authService';
import { LoginRequest } from '../../models/auth';
import { TextField, Button, Box, Typography, CircularProgress, Alert } from '@mui/material';

const LoginForm: React.FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState<string | null>(null);
    const [isLoading, setIsLoading] = useState(false);
    const { login, user } = useAuth(); // Get user to check role after login if needed
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setError(null);
        setIsLoading(true);
        try {
            const credentials: LoginRequest = { email, password };
            const authResponse = await loginApi(credentials);
            login(authResponse); // This will update context: token, user, isAuthenticated

            // The navigation logic might depend on the user's role,
            // which should now be available in the 'user' object from useAuth()
            // For now, we'll directly navigate to /facilitador as a default.
            // A more robust approach would be to check user.rol after login completes
            // or have the AuthContext handle role-based redirection.
            navigate('/facilitador');
        } catch (err: any) {
            setError(err.message || 'Error al iniciar sesión. Verifique sus credenciales.');
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <Box component="form" onSubmit={handleSubmit} sx={{ mt: 1 }}>
            {error && <Alert severity="error" sx={{ mb: 2 }}>{error}</Alert>}
            <TextField
                margin="normal"
                required
                fullWidth
                id="email"
                label="Correo Electrónico"
                name="email"
                autoComplete="email"
                autoFocus
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                disabled={isLoading}
            />
            <TextField
                margin="normal"
                required
                fullWidth
                name="password"
                label="Contraseña"
                type="password"
                id="password"
                autoComplete="current-password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                disabled={isLoading}
            />
            <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
                disabled={isLoading}
            >
                {isLoading ? <CircularProgress size={24} /> : 'Iniciar Sesión'}
            </Button>
        </Box>
    );
};
export default LoginForm;
