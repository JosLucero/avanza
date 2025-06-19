import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { registerApi } from '../../services/authService';
import { RegisterRequest } from '../../models/auth';
import { TextField, Button, Box, Typography, CircularProgress, Alert } from '@mui/material';

const RegisterForm: React.FC = () => {
    const [nombre, setNombre] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    // const [confirmPassword, setConfirmPassword] = useState(''); // Not in RegisterRequest, can be added for UI validation
    const [error, setError] = useState<string | null>(null);
    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setError(null);
        setSuccessMessage(null);

        if (password.length < 6) {
            setError("La contraseña debe tener al menos 6 caracteres.");
            setIsLoading(false); // Ensure loading is false if validation fails early
            return;
        }
        // Add other client-side validations if necessary (e.g., email format, though TextField type="email" helps)

        setIsLoading(true);
        try {
            const userData: RegisterRequest = { nombre, email, password };
            await registerApi(userData); // We don't use the response directly here for now
            setSuccessMessage('¡Registro exitoso! Serás redirigido a la página de inicio de sesión.');
            setTimeout(() => {
                navigate('/login');
            }, 2000);
        } catch (err: any) {
            setError(err.message || 'Error en el registro. Verifique sus datos.');
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <Box component="form" onSubmit={handleSubmit} sx={{ mt: 1 }}>
            {error && <Alert severity="error" sx={{ mb: 2 }}>{error}</Alert>}
            {successMessage && <Alert severity="success" sx={{ mb: 2 }}>{successMessage}</Alert>}
            <TextField
                margin="normal"
                required
                fullWidth
                id="nombre"
                label="Nombre Completo"
                name="nombre"
                autoComplete="name"
                autoFocus
                value={nombre}
                onChange={(e) => setNombre(e.target.value)}
                disabled={isLoading}
            />
            <TextField
                margin="normal"
                required
                fullWidth
                id="email"
                label="Correo Electrónico"
                name="email"
                type="email" // Added type email for basic validation
                autoComplete="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                disabled={isLoading}
            />
            <TextField
                margin="normal"
                required
                fullWidth
                name="password"
                label="Contraseña (mín. 6 caracteres)"
                type="password"
                id="password"
                autoComplete="new-password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                disabled={isLoading}
            />
            {/*
            // Optional: Confirm Password field - would require state and validation logic
            <TextField
                margin="normal"
                required
                fullWidth
                name="confirmPassword"
                label="Confirmar Contraseña"
                type="password"
                id="confirmPassword"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
                disabled={isLoading}
            />
            */}
            <Button
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
                disabled={isLoading}
            >
                {isLoading ? <CircularProgress size={24} /> : 'Registrarse'}
            </Button>
        </Box>
    );
};
export default RegisterForm;
