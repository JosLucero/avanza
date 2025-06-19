import axios, { AxiosError } from 'axios';
import { API_BASE_URL } from '../config/apiConfig';
import { LoginRequest, AuthResponse, RegisterRequest, RegisterResponse } from '../models/auth';

export const loginApi = async (credentials: LoginRequest): Promise<AuthResponse> => {
    try {
        const response = await axios.post<AuthResponse>(`${API_BASE_URL}/auth/login`, credentials);
        return response.data;
    } catch (error) {
        const axiosError = error as AxiosError;
        if (axiosError.response && axiosError.response.data) {
            const serverError = axiosError.response.data as { message?: string };
            throw new Error(serverError.message || `Error de inicio de sesión (${axiosError.response.status})`);
        }
        throw new Error(axiosError.message || 'Error de inicio de sesión. Intente nuevamente.');
    }
};

export const registerApi = async (userData: RegisterRequest): Promise<RegisterResponse> => {
    try {
        const response = await axios.post<RegisterResponse>(`${API_BASE_URL}/auth/register`, userData);
        return response.data;
    } catch (error) {
        const axiosError = error as AxiosError;
        if (axiosError.response && axiosError.response.data) {
            const serverError = axiosError.response.data as { message?: string };
            throw new Error(serverError.message || `Error en el registro (${axiosError.response.status})`);
        }
        throw new Error(axiosError.message || 'Error en el registro. Intente nuevamente.');
    }
};
