// src/models/aprendiz.ts
export interface Aprendiz {
    id: number;
    nombre: string;
    nivelActualId: number;
    // Podríamos añadir más detalles si son devueltos por el API o se cargan por separado
    // facilitadorId?: number;
    // nivelActualNombre?: string;
}

export interface CrearAprendizRequest {
    nombre: string;
    // nivelActualId no es necesario si el backend lo asigna por defecto al Nivel 1,
    // o si se quiere permitir seleccionarlo, se añadiría aquí.
    // Por ahora, solo nombre como en la especificación del backend.
}

// No es necesario un CrearAprendizResponse explícito si es igual a Aprendiz.
// export type CrearAprendizResponse = Aprendiz;
