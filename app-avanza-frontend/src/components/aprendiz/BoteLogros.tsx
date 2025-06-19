import React, { useEffect, useState, useCallback } from 'react';
import { getLogros, crearLogro as crearLogroService } from '../../services/progresoService';
import { Logro, CrearLogroRequest } from '../../models/logro';
import {
    Paper, Typography, Box, List, ListItem, ListItemText, TextField, Button,
    CircularProgress, Alert, Divider, IconButton, Tooltip
} from '@mui/material';
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import EmojiEventsIcon from '@mui/icons-material/EmojiEvents'; // Icono para logros

interface BoteLogrosProps {
    aprendizId: string;
    sx?: object; // Para pasar estilos desde el padre
}

const BoteLogros: React.FC<BoteLogrosProps> = ({ aprendizId, sx }) => {
    const [logros, setLogros] = useState<Logro[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<string | null>(null); // Error para la carga de la lista

    const [nuevaDescripcion, setNuevaDescripcion] = useState('');
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [submitError, setSubmitError] = useState<string | null>(null); // Error para el envío del formulario

    const fetchLogros = useCallback(async () => {
        if (!aprendizId) {
            setError("ID de aprendiz no proporcionado.");
            setIsLoading(false);
            return;
        }
        try {
            setIsLoading(true);
            setError(null);
            const data = await getLogros(aprendizId);
            // Ordenar por fecha más reciente primero
            setLogros(data.sort((a, b) => new Date(b.fecha).getTime() - new Date(a.fecha).getTime()));
        } catch (err: any) {
            setError(err.message || 'Ocurrió un error al cargar los logros.');
            console.error(err);
        } finally {
            setIsLoading(false);
        }
    }, [aprendizId]);

    useEffect(() => {
        fetchLogros();
    }, [fetchLogros]);

    const handleCrearLogro = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        if (!nuevaDescripcion.trim()) {
            setSubmitError("La descripción del logro no puede estar vacía.");
            return;
        }
        setIsSubmitting(true);
        setSubmitError(null);
        setError(null); // Clear list error if any before new submit

        try {
            const nuevoLogroData: CrearLogroRequest = {
                aprendizId: parseInt(aprendizId),
                descripcion: nuevaDescripcion
            };
            const logroCreado = await crearLogroService(nuevoLogroData);
            // Añadir al principio y re-ordenar por si acaso la fecha del servidor es ligeramente diferente
            setLogros(prevLogros => [logroCreado, ...prevLogros]
                .sort((a, b) => new Date(b.fecha).getTime() - new Date(a.fecha).getTime()));
            setNuevaDescripcion('');
        } catch (err: any) {
            setSubmitError(err.message || "Error al guardar el logro. Intente de nuevo.");
            console.error(err);
        } finally {
            setIsSubmitting(false);
        }
    };

    return (
        <Paper elevation={3} sx={{ p: {xs: 1.5, sm: 2}, borderRadius: 2, ...sx }}>
            <Typography variant="h6" component="h3" gutterBottom sx={{ display: 'flex', alignItems: 'center', mb:1.5}}>
                <EmojiEventsIcon sx={{ mr: 1, color: 'warning.main', fontSize: '1.75rem' }} />
                Bote de los Logros
            </Typography>

            <Box component="form" onSubmit={handleCrearLogro} sx={{ mb: 2 }}>
                <TextField
                    label="Nuevo logro conseguido"
                    variant="outlined"
                    fullWidth
                    multiline
                    minRows={2} // Para que sea un poco más alto
                    value={nuevaDescripcion}
                    onChange={(e) => setNuevaDescripcion(e.target.value)}
                    disabled={isSubmitting}
                    size="small"
                    sx={{mb: 1}}
                />
                {submitError && <Alert severity="error" sx={{ mt: 0.5, mb:1, fontSize:'0.8rem', p: '0px 8px' }}>{submitError}</Alert>}
                <Button
                    type="submit"
                    variant="contained"
                    size="medium" // Un poco más grande
                    startIcon={isSubmitting ? <CircularProgress size={20} color="inherit" /> : <AddCircleOutlineIcon />}
                    disabled={isSubmitting || !nuevaDescripcion.trim()}
                    fullWidth // Para que ocupe todo el ancho
                >
                    Añadir Logro
                </Button>
            </Box>
            <Divider sx={{ my: 2 }}/>

            {isLoading && <Box sx={{ display: 'flex', justifyContent: 'center', p: 2 }}><CircularProgress /></Box>}
            {error && <Alert severity="warning" sx={{ mb: 2 }}>{error}</Alert>}

            {!isLoading && !error && logros.length === 0 && (
                <Typography variant="body2" color="text.secondary" textAlign="center" sx={{py:2}}>
                    Aún no hay logros en el bote. ¡Sigue adelante!
                </Typography>
            )}

            {!isLoading && !error && logros.length > 0 && (
                <List dense sx={{ maxHeight: 300, overflow: 'auto', p:0 }}>
                    {logros.map((logro) => (
                        <ListItem
                            key={logro.id}
                            sx={{
                                borderBottom: '1px solid #eee',
                                '&:last-child': { borderBottom: 'none' },
                                pt:0.5, pb:0.5
                            }}
                        >
                            <ListItemText
                                primary={
                                    <Typography variant="body1">{logro.descripcion}</Typography>
                                }
                                secondary={`Conseguido: ${new Date(logro.fecha).toLocaleDateString()}`}
                            />
                        </ListItem>
                    ))}
                </List>
            )}
        </Paper>
    );
};
export default BoteLogros;
