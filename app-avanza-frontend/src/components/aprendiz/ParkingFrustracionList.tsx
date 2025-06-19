import React, { useState } from 'react';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';

interface ElementoParking {
    id: number;
    descripcion: string;
    aparcado: boolean;
}

const ParkingFrustracionList: React.FC = () => {
    const [elementos, setElementos] = useState<ElementoParking[]>([
        { id: 1, descripcion: "No entiendo las restas con llevada.", aparcado: true },
        { id: 2, descripcion: "Me cuesta leer en voz alta.", aparcado: false },
    ]);
    const [nuevaFrustracion, setNuevaFrustracion] = useState('');

    const handleAddFrustracion = () => {
        if (nuevaFrustracion.trim() === '') return;
        setElementos([...elementos, { id: Date.now(), descripcion: nuevaFrustracion, aparcado: false }]);
        setNuevaFrustracion('');
        // Aquí iría la llamada a la API para guardarlo
    };

    // Lógica para marcar como aparcado/resuelto (no implementada aquí)

    return (
        <Paper elevation={3} sx={{ p: 2, mb: 2 }}>
            <Typography variant="h5" gutterBottom>
                Parking de Frustraciones
            </Typography>
            <List>
                {elementos.map((elemento) => (
                    <ListItem key={elemento.id} secondaryAction={
                        <Button size="small" disabled={elemento.aparcado}>
                            {elemento.aparcado ? "Aparcado" : "Aparcar"}
                        </Button>
                    }>
                        <ListItemText primary={elemento.descripcion} secondary={elemento.aparcado ? "Aparcado" : "Pendiente"} />
                    </ListItem>
                ))}
            </List>
            <Box component="div" sx={{ mt: 2, display: 'flex', gap: 1 }}>
                <TextField
                    label="Nueva frustración o duda"
                    variant="outlined"
                    size="small"
                    fullWidth
                    value={nuevaFrustracion}
                    onChange={(e) => setNuevaFrustracion(e.target.value)}
                />
                <Button variant="contained" onClick={handleAddFrustracion}>Añadir</Button>
            </Box>
        </Paper>
    );
};

export default ParkingFrustracionList;
