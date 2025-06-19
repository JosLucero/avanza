// src/models/auth.ts
export interface LoginRequest {
    email: string;
    password: string;
}

export interface AuthResponse {
    accessToken: string;
    expiresIn: string; // o Date, el backend actualmente devuelve DateTime, que se serializa como string.
}

export interface User {
    id: string;
    email: string;
    nombre: string;
    rol: string;
}

export interface RegisterRequest {
    nombre: string;
    email: string;
    password: string;
}

// Asumiendo que el backend devuelve el usuario creado (sin contraseña)
export interface RegisterResponse {
    id: number; // Matches task spec, usually numeric from DB
    nombre: string;
    email: string;
    rol: string;
}
