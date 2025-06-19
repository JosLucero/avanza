import React, { useEffect, useState, useCallback } from 'react';
import { useParams } from 'react-router-dom';
import { getPlanDiaActual } from '../../services/planDiarioService';
import { getAprendizById } from '../../services/aprendizService';
import { ActividadSemanal } from '../../models/actividad';
import { Aprendiz } from '../../models/aprendiz';
import MisionDelDia from '../../components/aprendiz/MisionDelDia';
import ProgresoNivel from '../../components/aprendiz/ProgresoNivel';
import BoteLogros from '../../components/aprendiz/BoteLogros'; // Import BoteLogros
import { Container, Typography, Box, CircularProgress, Alert, Grid, Paper } from '@mui/material';
// import ParkingFrustracionList from '../../components/aprendiz/ParkingFrustracionList';
// import DiarioFacilitador from '../../components/aprendiz/DiarioFacilitador';


const DashboardAprendizPage: React.FC = () => {
    const { aprendizId } = useParams<{ aprendizId: string }>();
    const [actividadActual, setActividadActual] = useState<ActividadSemanal | null>(null);
    const [aprendiz, setAprendiz] = useState<Aprendiz | null>(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    const fetchDashboardData = useCallback(async () => {
        if (!aprendizId) {
            setError("No se proporcionó un ID de aprendiz válido.");
            setIsLoading(false);
            return;
        }

        setIsLoading(true);
        setError(null);

        try {
            const [actividadData, aprendizData] = await Promise.all([
                getPlanDiaActual(aprendizId),
                getAprendizById(parseInt(aprendizId, 10))
            ]);
            setActividadActual(actividadData);
            setAprendiz(aprendizData);
        } catch (err: any) {
            console.error("Error fetching dashboard data:", err);
            setError(err.message || 'Ocurrió un error al cargar el dashboard del aprendiz.');
        } finally {
            setIsLoading(false);
        }
    }, [aprendizId]);

    useEffect(() => {
        fetchDashboardData();
    }, [fetchDashboardData]);

    if (isLoading) {
        return (
            <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: 'calc(100vh - 120px)' }}>
                <CircularProgress />
            </Box>
        );
    }

    if (error) {
        return (
            <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
                <Alert severity="error">{error}</Alert>
            </Container>
        );
    }

    return (
        <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
            <Typography variant="h4" component="h1" gutterBottom sx={{ mb: 3 }}>
                Dashboard de {aprendiz?.nombre || `Aprendiz`}
            </Typography>

            {aprendizId && (
                <Grid container spacing={3}>
                    {/* Columna Principal: Misión del Día y Progreso */}
                    <Grid item xs={12} md={8}>
                        <Box sx={{ mb: 3 }}>
                            <MisionDelDia actividad={actividadActual} nombreAprendiz={aprendiz?.nombre}/>
                        </Box>
                        <ProgresoNivel aprendizId={aprendizId} />
                    </Grid>

                    {/* Columna Lateral: Bote de Logros, Parking, Diario */}
                    <Grid item xs={12} md={4}>
                        <BoteLogros aprendizId={aprendizId} sx={{ mb: 3 }} /> {/* Integrado aquí */}
                        <Paper elevation={2} sx={{p: 2, mb:3}}>
                            <Typography variant="h6">Parking de Frustraciones (Placeholder)</Typography>
                            {/* <ParkingFrustracionList aprendizId={aprendizId} /> */}
                        </Paper>
                        <Paper elevation={2} sx={{p: 2, mb:3}}>
                            <Typography variant="h6">Diario del Facilitador (Placeholder)</Typography>
                            {/* <DiarioFacilitador aprendizId={aprendizId} /> */}
                        </Paper>
                    </Grid>
                </Grid>
            )}
        </Container>
    );
};
export default DashboardAprendizPage;
