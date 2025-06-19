// src/models/logro.ts
export interface Logro {
    id: number;
    aprendizId: number; // Included as it's part of the backend entity
    descripcion: string;
    fecha: string; // ISO date string from backend (DateTime)
}

export interface CrearLogroRequest {
    aprendizId: number; // El backend necesita esto para asociar el logro
    descripcion: string;
}

// La respuesta a la creación de un Logro es usualmente el Logro creado.
// Si es así, podemos considerar que CrearLogroResponse es igual a Logro.
// export type CrearLogroResponse = Logro;
