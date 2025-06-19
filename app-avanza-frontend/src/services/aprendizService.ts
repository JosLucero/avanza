// src/services/aprendizService.ts
import apiClient from './apiClient';
import { Aprendiz, CrearAprendizRequest } from '../models/aprendiz';

export const getAprendicesDelFacilitador = async (): Promise<Aprendiz[]> => {
    try {
        const response = await apiClient.get<Aprendiz[]>('/aprendices');
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || error.message || 'Error al obtener los aprendices del facilitador.';
        console.error("Error en getAprendicesDelFacilitador:", error.response || error);
        throw new Error(errorMessage);
    }
};

export const getAprendizById = async (id: number): Promise<Aprendiz> => {
    try {
        const response = await apiClient.get<Aprendiz>(`/aprendices/${id}`);
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || error.message || `Error al obtener el aprendiz con ID ${id}.`;
        console.error(`Error en getAprendizById (${id}):`, error.response || error);
        throw new Error(errorMessage);
    }
};

export const crearAprendiz = async (data: CrearAprendizRequest): Promise<Aprendiz> => {
    try {
        // El backend espera un objeto con la propiedad "nombre"
        // Asumiendo que el backend responde con la entidad Aprendiz completa (incluyendo el ID generado)
        const response = await apiClient.post<Aprendiz>('/aprendices', data );
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || error.message || 'Error al crear el aprendiz.';
        console.error("Error en crearAprendiz:", error.response || error);
        throw new Error(errorMessage);
    }
};
