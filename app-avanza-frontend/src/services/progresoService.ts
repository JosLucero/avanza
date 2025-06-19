// src/services/progresoService.ts
import apiClient from './apiClient';
import { HitoProgreso } from '../models/progreso';
import { Logro, CrearLogroRequest } from '../models/logro'; // Import Logro types

export const getProgresoHitos = async (aprendizId: string): Promise<HitoProgreso[]> => {
    try {
        // Endpoint: GET /api/progreso/{aprendizId}/hitos
        const response = await apiClient.get<HitoProgreso[]>(`/progreso/${aprendizId}/hitos`);
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || error.message || 'Error al obtener el progreso de los hitos';
        console.error("Error en getProgresoHitos:", error.response || error);
        throw new Error(errorMessage);
    }
};

export const marcarHitoCompletado = async (aprendizId: string, hitoDeDominioId: number): Promise<HitoProgreso> => {
    try {
        // Endpoint: POST /api/progreso/hitos/{hitoDeDominioId}/completar
        const response = await apiClient.post<HitoProgreso>(`/progreso/hitos/${hitoDeDominioId}/completar`, { aprendizId: parseInt(aprendizId) });
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || error.message || 'Error al marcar el hito como completado';
        console.error("Error en marcarHitoCompletado:", error.response || error);
        throw new Error(errorMessage);
    }
};

// Funciones para Logros

export const getLogros = async (aprendizId: string): Promise<Logro[]> => {
    try {
        // Endpoint: GET /api/progreso/logros/{aprendizId}
        const response = await apiClient.get<Logro[]>(`/progreso/logros/${aprendizId}`);
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || error.message || 'Error al obtener los logros';
        console.error("Error en getLogros:", error.response || error);
        throw new Error(errorMessage);
    }
};

export const crearLogro = async (data: CrearLogroRequest): Promise<Logro> => {
    try {
        // Endpoint: POST /api/progreso/logros
        // El backend espera { aprendizId, descripcion }
        const response = await apiClient.post<Logro>('/progreso/logros', data);
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || error.message || 'Error al crear el logro';
        console.error("Error en crearLogro:", error.response || error);
        throw new Error(errorMessage);
    }
};

// Optional: If a separate "desmarcar" endpoint exists or if the "completar" endpoint acts as a toggle
// export const desmarcarHitoCompletado = async (aprendizId: string, hitoDeDominioId: number): Promise<HitoProgreso> => {
//     try {
//         const response = await apiClient.post<HitoProgreso>(`/progreso/hitos/${hitoDeDominioId}/desmarcar`, { aprendizId: parseInt(aprendizId) });
//         return response.data;
//     } catch (error: any) {
//         const errorMessage = error.response?.data?.message || error.message || 'Error al desmarcar el hito.';
//         console.error("Error en desmarcarHitoCompletado:", error.response || error);
//         throw new Error(errorMessage);
//     }
// };
