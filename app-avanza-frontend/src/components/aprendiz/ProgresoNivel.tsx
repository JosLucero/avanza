import React, { useEffect, useState, useCallback } from 'react';
import { getProgresoHitos, marcarHitoCompletado } from '../../services/progresoService';
import { HitoProgreso } from '../../models/progreso';
import {
    Paper, Typography, Box, List, ListItem, ListItemText, Checkbox, CircularProgress,
    Alert, Chip, IconButton, Tooltip, Divider, LinearProgress
} from '@mui/material';
import CheckCircleIcon from '@mui/icons-material/CheckCircle';
import RadioButtonUncheckedIcon from '@mui/icons-material/RadioButtonUnchecked'; // Using this for unchecked state
import TaskAltIcon from '@mui/icons-material/TaskAlt'; // Alternative for completed

interface ProgresoNivelProps {
    aprendizId: string;
}

const ProgresoNivel: React.FC<ProgresoNivelProps> = ({ aprendizId }) => {
    const [hitos, setHitos] = useState<HitoProgreso[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [updatingHitoId, setUpdatingHitoId] = useState<number | null>(null);

    const fetchHitos = useCallback(async () => {
        if (!aprendizId) {
            setError("ID de aprendiz no proporcionado.");
            setIsLoading(false);
            return;
        }
        try {
            setIsLoading(true);
            setError(null);
            const data = await getProgresoHitos(aprendizId);
            setHitos(data);
        } catch (err: any) {
            setError(err.message || 'Ocurrió un error al cargar los hitos de progreso.');
            console.error(err);
        } finally {
            setIsLoading(false);
        }
    }, [aprendizId]);

    useEffect(() => {
        fetchHitos();
    }, [fetchHitos]);

    const handleToggleHito = async (hito: HitoProgreso) => {
        if (updatingHitoId || hito.completado) return; // Prevent multiple updates or re-completing

        setUpdatingHitoId(hito.hitoDeDominioId);
        setError(null);
        try {
            // Assumes marcarHitoCompletado marks it as true.
            // If it's a toggle, the backend needs to handle that.
            const hitoActualizado = await marcarHitoCompletado(aprendizId, hito.hitoDeDominioId);

            setHitos(prevHitos =>
                prevHitos.map(h =>
                    h.hitoDeDominioId === hito.hitoDeDominioId ? hitoActualizado : h
                )
            );
        } catch (err: any) {
            setError(err.message || `Error al actualizar el hito: ${hito.descripcion}`);
            console.error(err);
        } finally {
            setUpdatingHitoId(null);
        }
    };

    if (isLoading) {
        return <Box sx={{ display: 'flex', justifyContent: 'center', p: 2 }}><CircularProgress /></Box>;
    }

    const completados = hitos.filter(h => h.completado).length;
    const totalHitos = hitos.length;
    const progresoGeneral = totalHitos > 0 ? (completados / totalHitos) * 100 : 0;

    return (
        <Paper elevation={3} sx={{ p: { xs: 2, sm: 3 }, borderRadius: 2 }}>
            <Typography variant="h6" component="h3" gutterBottom sx={{ fontWeight: 'bold' }}>
                Progreso del Nivel
            </Typography>
            {error && <Alert severity="error" sx={{ mb: 2 }}>{error}</Alert>}

            <Box sx={{ mb: 2 }}>
                <Typography variant="body2" color="text.secondary" gutterBottom>
                    {completados} de {totalHitos} hitos completados
                </Typography>
                <LinearProgress variant="determinate" value={progresoGeneral} sx={{ height: 10, borderRadius: 5 }} />
            </Box>
            <Divider sx={{my:2}}/>

            {hitos.length === 0 && !isLoading && !error && (
                <Typography color="text.secondary">No hay hitos definidos para este nivel o para este aprendiz.</Typography>
            )}
            <List dense sx={{maxHeight: 400, overflow: 'auto'}}> {/* Added max height and scroll */}
                {hitos.map((hito) => (
                    <ListItem
                        key={hito.hitoDeDominioId}
                        disablePadding
                        secondaryAction={
                            <Tooltip title={hito.completado ? "Completado" : "Marcar como completado"}>
                                <span> {/* Tooltip needs a DOM element child if IconButton is disabled */}
                                <IconButton
                                    edge="end"
                                    onClick={() => handleToggleHito(hito)}
                                    disabled={hito.completado || (!!updatingHitoId && updatingHitoId === hito.hitoDeDominioId)}
                                >
                                    {updatingHitoId === hito.hitoDeDominioId ? (
                                        <CircularProgress size={24} color="inherit" />
                                    ) : hito.completado ? (
                                        <TaskAltIcon color="success" />
                                    ) : (
                                        <RadioButtonUncheckedIcon />
                                    )}
                                </IconButton>
                                </span>
                            </Tooltip>
                        }
                        sx={{
                            mb: 1, // Margin bottom for spacing between items
                            p: 1, // Padding for the item itself
                            border: '1px solid',
                            borderColor: 'divider',
                            borderRadius: 1,
                            backgroundColor: hito.completado ? 'action.disabledBackground' : 'background.paper'
                        }}
                    >
                        <ListItemText
                            primary={
                                <Typography variant="body1" sx={{ fontWeight: hito.completado ? 'normal' : 'medium' }}>
                                    {hito.descripcion}
                                </Typography>
                            }
                            secondary={
                                <>
                                    <Chip label={hito.area} size="small" variant="outlined" sx={{ mr: 1, mt:0.5, fontSize: '0.7rem', cursor:'default' }} />
                                    {hito.completado && hito.fechaCompletado ?
                                        <Typography component="span" variant="caption" color="text.secondary">
                                            Completado: {new Date(hito.fechaCompletado).toLocaleDateString()}
                                        </Typography>
                                        : hito.completado ?
                                        <Typography component="span" variant="caption" color="text.secondary">Completado</Typography>
                                        : <Typography component="span" variant="caption" color="text.secondary">Pendiente</Typography>}
                                </>
                            }
                            sx={{
                                textDecoration: hito.completado ? 'line-through' : 'none',
                                color: hito.completado ? 'text.disabled' : 'text.primary',
                            }}
                        />
                    </ListItem>
                ))}
            </List>
        </Paper>
    );
};
export default ProgresoNivel;
