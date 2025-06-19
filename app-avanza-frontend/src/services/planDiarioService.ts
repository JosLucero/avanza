// src/services/planDiarioService.ts
import apiClient from './apiClient';
import { ActividadSemanal } from '../models/actividad';

export const getPlanDiaActual = async (aprendizId: string): Promise<ActividadSemanal | null> => {
    try {
        // El endpoint es /api/plandia/{aprendizId}
        // El backend debería determinar el día actual y el nivel del aprendiz para devolver la actividad correspondiente.
        const response = await apiClient.get<ActividadSemanal | null>(`/plandia/${aprendizId}`);
        // Si el backend devuelve 204 No Content o un cuerpo vacío para "sin actividad",
        // axios podría devolver null o un objeto vacío dependiendo de la config.
        // Asumimos que si no hay actividad, el backend devuelve 404 (manejado abajo) o 200 con null.
        if (response.status === 204 || !response.data) {
            return null;
        }
        return response.data;
    } catch (error: any) {
        if (error.response && error.response.status === 404) {
            // No hay actividad para hoy o para el nivel del aprendiz.
            console.log(`No se encontró plan diario para el aprendiz ${aprendizId}.`);
            return null;
        }
        const errorMessage = error.response?.data?.message || error.message || 'Error al obtener el plan del día';
        console.error("Error en getPlanDiaActual:", error.response || error);
        throw new Error(errorMessage);
    }
};
