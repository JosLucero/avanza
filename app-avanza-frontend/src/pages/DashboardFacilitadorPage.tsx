import React, { useEffect, useState, useCallback } from 'react';
import { getAprendicesDelFacilitador, crearAprendiz as crearAprendizService } from '../../services/aprendizService';
import { Aprendiz, CrearAprendizRequest } from '../../models/aprendiz';
import AprendizCard from '../../components/aprendiz/AprendizCard';
import CrearAprendizForm from '../../components/aprendiz/CrearAprendizForm';
import {
    Container, Typography, Box, CircularProgress, Alert, Grid, Button,
    Dialog, DialogContent, DialogTitle, Paper
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';

const DashboardFacilitadorPage: React.FC = () => {
    const [aprendices, setAprendices] = useState<Aprendiz[]>([]);
    const [isLoadingPage, setIsLoadingPage] = useState(true); // Loading for the page content (list of aprendices)
    const [pageError, setPageError] = useState<string | null>(null);

    const [isSubmittingForm, setIsSubmittingForm] = useState(false); // Loading for the form submission
    const [formError, setFormError] = useState<string | null>(null); // Error specific to the creation form

    const [openCrearModal, setOpenCrearModal] = useState(false);

    const fetchAprendices = useCallback(async () => {
        try {
            setIsLoadingPage(true);
            setPageError(null);
            const data = await getAprendicesDelFacilitador();
            setAprendices(data);
        } catch (err: any) {
             setPageError(err.message || 'Ocurrió un error al cargar los perfiles de aprendices.');
             console.error(err);
        } finally {
            setIsLoadingPage(false);
        }
    }, []);

    useEffect(() => {
        fetchAprendices();
    }, [fetchAprendices]);

    const handleOpenCrearModal = () => {
        setFormError(null); // Clear previous form errors when opening
        setOpenCrearModal(true);
    };

    const handleCloseCrearModal = () => {
        if (isSubmittingForm) return; // Prevent closing while submitting
        setOpenCrearModal(false);
        setFormError(null); // Also clear errors when explicitly closing
    };

    const handleCrearAprendizSubmit = async (data: CrearAprendizRequest) => {
        setFormError(null);
        setIsSubmittingForm(true);
        try {
            const nuevoAprendiz = await crearAprendizService(data);
            setAprendices(prevAprendices => [nuevoAprendiz, ...prevAprendices]);
            handleCloseCrearModal();
        } catch (err: any) {
            console.error("Error en handleCrearAprendizSubmit:", err);
            setFormError(err.message || "Error al crear el aprendiz. Verifique los datos e intente de nuevo.");
            // Modal remains open to show the error
        } finally {
            setIsSubmittingForm(false);
        }
    };

    if (isLoadingPage && aprendices.length === 0) {
        return (
            <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: 'calc(100vh - 120px)' }}>
                <CircularProgress />
            </Box>
        );
    }

    return (
        <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
            <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', mb: 4 }}>
                <Typography variant="h4" component="h1" gutterBottom>
                    Mis Aprendices
                </Typography>
                <Button variant="contained" color="primary" startIcon={<AddIcon />} onClick={handleOpenCrearModal}>
                    Registrar Aprendiz
                </Button>
            </Box>

            {pageError && <Alert severity="error" sx={{ mb: 2 }}>{pageError}</Alert>}

            {aprendices.length === 0 && !isLoadingPage ? (
                 <Paper elevation={1} sx={{ p: 3, textAlign: 'center' }}>
                     <Typography variant="h6">No tienes aprendices asignados todavía.</Typography>
                     <Typography variant="body1" sx={{ mt: 1 }}>
                         Haz clic en "Registrar Aprendiz" para añadir uno nuevo.
                     </Typography>
                </Paper>
            ) : (
                <Grid container spacing={3}>
                    {aprendices.map((aprendiz) => (
                        <Grid item xs={12} sm={6} md={4} lg={3} key={aprendiz.id}>
                            <AprendizCard aprendiz={aprendiz} />
                        </Grid>
                    ))}
                </Grid>
            )}

            <Dialog open={openCrearModal} onClose={handleCloseCrearModal} maxWidth="sm" fullWidth disableEscapeKeyDown={isSubmittingForm}>
                <DialogTitle>Registrar Nuevo Aprendiz</DialogTitle>
                <DialogContent>
                    {/* <DialogContentText sx={{mb:1}}> Ingresa el nombre completo de tu aprendiz. </DialogContentText> // Moved to form placeholder/label */}
                    {formError && <Alert severity="error" sx={{ mb: 2 }}>{formError}</Alert>}
                    <CrearAprendizForm
                        onSubmit={handleCrearAprendizSubmit}
                        onCancel={handleCloseCrearModal}
                        isLoadingExternally={isSubmittingForm}
                    />
                </DialogContent>
                {/* DialogActions are now part of CrearAprendizForm for better encapsulation */}
            </Dialog>
        </Container>
    );
};
export default DashboardFacilitadorPage;
