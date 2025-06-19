// src/models/actividad.ts
export interface ActividadSemanal {
    id: number;
    diaSemana: string; // e.g., "Lunes", "Martes" - matches backend enum string representation
    nivelId: number;
    titulo: string;
    descripcionPractica: string;
    logroEsperado: string;
    // Consider adding nivelNombre if the backend can provide it easily or if needed for display
    // nivelNombre?: string;
}
