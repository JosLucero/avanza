import React from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { Card, CardContent, Typography, CardActions, Button, Box } from '@mui/material';
import { Aprendiz } from '../../models/aprendiz'; // Ajusta la ruta si es necesario

interface AprendizCardProps {
    aprendiz: Aprendiz;
}

const AprendizCard: React.FC<AprendizCardProps> = ({ aprendiz }) => {
    return (
        <Card sx={{
            minWidth: 270,
            mb: 2,
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'space-between',
            height: '100%' // Para que todas las cards en un Grid tengan la misma altura
        }}>
            <CardContent>
                <Typography variant="h5" component="div" gutterBottom>
                    {aprendiz.nombre}
                </Typography>
                <Typography sx={{ mb: 0.5 }} color="text.secondary">
                    ID: {aprendiz.id}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    ID Nivel Actual: {aprendiz.nivelActualId}
                    {/* Si tuvieras el nombre del nivel, lo mostrarías aquí: */}
                    {/* {aprendiz.nivelActualNombre && `(${aprendiz.nivelActualNombre})`} */}
                </Typography>
                {/* Aquí podrían ir más detalles o un resumen del progreso */}
            </CardContent>
            <CardActions sx={{ justifyContent: 'flex-start', pt: 0 }}> {/* pt:0 para reducir espacio si el contenido es poco */}
                <Button component={RouterLink} to={`/aprendiz/${aprendiz.id}`} size="small">
                    Ver Dashboard
                </Button>
                <Button component={RouterLink} to={`/evaluacion/${aprendiz.id}`} size="small">
                    Evaluar
                </Button>
            </CardActions>
        </Card>
    );
};
export default AprendizCard;
