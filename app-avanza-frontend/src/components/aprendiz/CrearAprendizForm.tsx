import React, { useState } from 'react';
import { TextField, Button, Box, CircularProgress, Alert } from '@mui/material';
import { CrearAprendizRequest } from '../../models/aprendiz';

interface CrearAprendizFormProps {
    onSubmit: (data: CrearAprendizRequest) => Promise<void>;
    onCancel: () => void;
    isLoadingExternally?: boolean;
}

const CrearAprendizForm: React.FC<CrearAprendizFormProps> = ({ onSubmit, onCancel, isLoadingExternally }) => {
    const [nombre, setNombre] = useState('');
    const [error, setError] = useState<string | null>(null);
    const [formIsLoading, setFormIsLoading] = useState(false);

    // Use external loading state if provided, otherwise use internal form loading state
    const internalIsLoading = isLoadingExternally !== undefined ? isLoadingExternally : formIsLoading;

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setError(null);
        if (!nombre.trim()) {
            setError("El nombre es requerido.");
            return;
        }

        // Set internal loading only if not controlled externally
        if (isLoadingExternally === undefined) {
            setFormIsLoading(true);
        }

        try {
            await onSubmit({ nombre });
            // On successful submit, the parent component (modal) will typically close the form.
            // Resetting form or showing success message here might be redundant if modal closes immediately.
            // If the modal STAYS open on success, then:
            // setNombre(''); // Reset form field
            // Or parent handles success message.
        } catch (err: any) {
            setError(err.message || "Error al procesar la solicitud. Intente de nuevo.");
            // Error is shown to the user. Parent might also display it or handle it.
        } finally {
            if (isLoadingExternally === undefined) {
                setFormIsLoading(false);
            }
        }
    };

    return (
        <Box component="form" onSubmit={handleSubmit} noValidate> {/* noValidate to prevent browser default validation */}
            {/* Error display is now handled by the parent Dialog in DashboardFacilitadorPage to show it below DialogContentText */}
            {/* {error && <Alert severity="error" sx={{ mb: 2 }}>{error}</Alert>} */}
            <TextField
                margin="dense"
                required
                fullWidth
                id="nombreAprendiz"
                label="Nombre Completo del Aprendiz"
                name="nombre"
                autoFocus
                value={nombre}
                onChange={(e) => setNombre(e.target.value)}
                disabled={internalIsLoading}
                error={!!error && !nombre.trim()} // Show error on field if name is empty on submit attempt
                helperText={!!error && !nombre.trim() ? "El nombre es requerido." : ""}
            />
            <Box sx={{ mt: 3, display: 'flex', justifyContent: 'flex-end' }}> {/* Increased mt for spacing */}
                <Button onClick={onCancel} sx={{ mr: 1 }} disabled={internalIsLoading}>
                    Cancelar
                </Button>
                <Button type="submit" variant="contained" disabled={internalIsLoading}>
                    {internalIsLoading ? <CircularProgress size={24} /> : 'Crear Aprendiz'}
                </Button>
            </Box>
        </Box>
    );
};
export default CrearAprendizForm;
