import React from 'react';
import { Paper, Typography, Box, Divider, Chip } from '@mui/material';
import { ActividadSemanal } from '../../models/actividad';

interface MisionDelDiaProps {
    actividad: ActividadSemanal | null;
    nombreAprendiz?: string; // Opcional, para personalizar el saludo
}

const MisionDelDia: React.FC<MisionDelDiaProps> = ({ actividad, nombreAprendiz }) => {
    if (!actividad) {
        return (
            <Paper elevation={3} sx={{ p: 3, textAlign: 'center', borderRadius: 2 }}>
                <Typography variant="h5" component="h2" gutterBottom>
                    Misión del Día {nombreAprendiz ? `para ${nombreAprendiz}`: ""}
                </Typography>
                <Typography variant="body1" color="text.secondary">
                    ¡Hoy no hay una actividad específica programada!
                </Typography>
                <Typography variant="body2" sx={{ mt: 1 }}>
                    Aprovecha para repasar lo que más te guste o explorar nuevos temas.
                </Typography>
            </Paper>
        );
    }

    return (
        <Paper elevation={3} sx={{ p: 3, borderRadius: 2 }}> {/* Added borderRadius */}
            <Typography variant="h5" component="h2" gutterBottom sx={{ color: 'primary.main', fontWeight: 'bold' }}>
                Misión del Día: {actividad.titulo}
            </Typography>
            <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
                <Chip label={`Día: ${actividad.diaSemana}`} color="info" variant="outlined" sx={{ mr: 1 }} />
                <Chip label={`Nivel: ${actividad.nivelId}`} color="secondary" variant="outlined" />
            </Box>
            <Divider sx={{ my: 2 }} />
            <Box sx={{ mb: 2 }}>
                <Typography variant="h6" gutterBottom sx={{ color: 'text.primary' }}>
                    Práctica Sugerida:
                </Typography>
                <Typography variant="body1" sx={{ whiteSpace: 'pre-line', color: 'text.secondary' }}>
                    {actividad.descripcionPractica}
                </Typography>
            </Box>
            <Divider sx={{ my: 2 }} />
            <Box>
                <Typography variant="h6" gutterBottom sx={{ color: 'text.primary' }}>
                    Logro Esperado:
                </Typography>
                <Typography variant="body1" sx={{ whiteSpace: 'pre-line', color: 'text.secondary' }}>
                    {actividad.logroEsperado}
                </Typography>
            </Box>
        </Paper>
    );
};
export default MisionDelDia;
