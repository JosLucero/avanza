import React from 'react';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import Divider from '@mui/material/Divider';

interface RegistroDiario {
    id: number;
    fecha: string; // Debería ser Date, pero string para simplicidad aquí
    observaciones: string;
}

const DiarioFacilitador: React.FC = () => {
    // Lógica para obtener los registros del facilitador para este aprendiz
    const registros: RegistroDiario[] = [
        { id: 1, fecha: "2024-06-17", observaciones: "Hoy Juan ha mostrado mucho interés en el taller de palabras. Ha identificado 3 nuevas!" },
        { id: 2, fecha: "2024-06-16", observaciones: "Costó un poco mantener la atención en la aventura numérica, pero al final participó." },
    ];

    return (
        <Paper elevation={3} sx={{ p: 2, mb: 2 }}>
            <Typography variant="h5" gutterBottom>
                Diario del Facilitador
            </Typography>
            <List>
                {registros.map((registro, index) => (
                    <React.Fragment key={registro.id}>
                        <ListItem alignItems="flex-start">
                            <ListItemText
                                primary={registro.observaciones}
                                secondary={`Fecha: ${registro.fecha}`}
                            />
                        </ListItem>
                        {index < registros.length - 1 && <Divider component="li" />}
                    </React.Fragment>
                ))}
            </List>
        </Paper>
    );
};

export default DiarioFacilitador;
