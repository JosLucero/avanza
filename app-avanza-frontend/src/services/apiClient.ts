// src/services/apiClient.ts
import axios from 'axios';
import { API_BASE_URL } from '../config/apiConfig';

const apiClient = axios.create({
    baseURL: API_BASE_URL,
});

// Interceptor para añadir el token JWT a las cabeceras
apiClient.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('authToken');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

// Opcional: Interceptor de respuesta para manejar errores globales (ej. 401 Unauthorized)
apiClient.interceptors.response.use(
    response => response,
    error => {
        if (error.response && error.response.status === 401) {
            // Considerar si esta lógica debe estar aquí o ser manejada por AuthContext
            // Si AuthContext maneja el logout globalmente, este interceptor podría ser redundante
            // o podría llamar a una función de logout del AuthContext si se pudiera acceder.
            // Por ahora, una simple redirección como ejemplo:
            console.error("Interceptor: Unauthorized access - 401. Redirecting to login.");
            localStorage.removeItem('authToken'); // Limpiar token
            // Evitar bucles de redirección si la página de login también usa apiClient y falla
            if (window.location.pathname !== '/login') {
                 window.location.href = '/login';
            }
        }
        return Promise.reject(error);
    }
);

export default apiClient;
