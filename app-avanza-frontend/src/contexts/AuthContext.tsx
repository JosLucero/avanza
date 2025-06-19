import React, { createContext, useState, useContext, ReactNode, useEffect } from 'react';
import { jwtDecode, JwtPayload } from 'jwt-decode'; // Import JwtPayload for exp, iss, aud etc.
import { AuthResponse, User } from '../models/auth';

// Define the expected structure of our JWT payload
interface DecodedJwtPayload extends JwtPayload { // Extends JwtPayload for standard claims like exp, iss, aud
    sub: string;
    email: string;
    name: string;
    role: string;
    // Add other custom claims if you have them
}

interface AuthContextType {
    isAuthenticated: boolean;
    user: User | null;
    token: string | null;
    login: (authResponse: AuthResponse) => void;
    logout: () => void;
    isLoading: boolean;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

// Helper to parse JWT and map to our User model
const parseJwtToUser = (token: string): User | null => {
    try {
        const decodedToken = jwtDecode<DecodedJwtPayload>(token);

        // Validate essential claims exist
        if (!decodedToken.sub || !decodedToken.email || !decodedToken.name || !decodedToken.role) {
            console.error("JWT is missing one or more required claims (sub, email, name, role).");
            return null;
        }

        return {
            id: decodedToken.sub,
            email: decodedToken.email,
            nombre: decodedToken.name,
            rol: decodedToken.role
        };
    } catch (error) {
        console.error("Failed to parse JWT or map claims:", error);
        return null;
    }
};


export const AuthProvider: React.FC<{children: ReactNode}> = ({ children }) => {
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<User | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const isAuthenticated = !!token && !!user;

    useEffect(() => {
        const storedToken = localStorage.getItem('authToken');
        if (storedToken) {
            try {
                const decodedPayload = jwtDecode<DecodedJwtPayload>(storedToken);
                if (decodedPayload.exp && (decodedPayload.exp * 1000 > Date.now())) {
                    const parsedUser = parseJwtToUser(storedToken);
                    if (parsedUser) {
                        setUser(parsedUser);
                        setToken(storedToken);
                    } else {
                        localStorage.removeItem('authToken');
                    }
                } else {
                    localStorage.removeItem('authToken');
                }
            } catch (error) {
                console.error("Error processing stored token:", error);
                localStorage.removeItem('authToken');
            }
        }
        setIsLoading(false);
    }, []);

    const login = (authResponse: AuthResponse) => {
        localStorage.setItem('authToken', authResponse.accessToken);
        try {
            const parsedUser = parseJwtToUser(authResponse.accessToken);
            if (parsedUser) {
                setUser(parsedUser);
                setToken(authResponse.accessToken);
            } else {
                console.error("Failed to parse user from new token during login");
                logout(); // Clear auth state if parsing fails
            }
        } catch (error) { // Should not happen if parseJwtToUser handles its errors, but as a safeguard
            console.error("Error during login token processing:", error);
            logout();
        }
    };

    const logout = () => {
        localStorage.removeItem('authToken');
        setUser(null);
        setToken(null);
    };

    return (
        <AuthContext.Provider value={{ isAuthenticated, user, token, login, logout, isLoading }}>
            {!isLoading ? children : null}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (context === undefined) {
        throw new Error('useAuth must be used within an AuthProvider');
    }
    return context;
};
