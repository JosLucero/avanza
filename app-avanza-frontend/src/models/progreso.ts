// src/models/progreso.ts

export interface HitoProgreso {
    hitoDeDominioId: number; // Corresponds to HitoDeDominio.Id
    descripcion: string;     // From HitoDeDominio
    area: string;            // From HitoDeDominio (enum as string)
    completado: boolean;     // From ProgresoHito
    fechaCompletado?: string | null; // From ProgresoHito (ISO date string or null)
    // nivelId?: number; // Optional: Could be useful if displaying hitos from multiple/different levels than current
}
