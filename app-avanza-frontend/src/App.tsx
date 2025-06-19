import React from 'react';
import AppRouter from './routes/AppRouter';
import './App.css'; // O estilos globales
import { ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { AuthProvider } from './contexts/AuthContext'; // Import AuthProvider

// Un tema básico de MUI de ejemplo
const theme = createTheme({
  palette: {
    primary: {
      main: '#1976d2', // Un azul más estándar de MUI
    },
    secondary: {
      main: '#dc004e', // Un rosa/rojo de MUI
    },
    // Puedes añadir más personalizaciones aquí: background, typography, etc.
  },
  typography: {
    fontFamily: [
      '-apple-system',
      'BlinkMacSystemFont',
      '"Segoe UI"',
      'Roboto',
      '"Helvetica Neue"',
      'Arial',
      'sans-serif',
      '"Apple Color Emoji"',
      '"Segoe UI Emoji"',
      '"Segoe UI Symbol"',
    ].join(','),
  }
});

function App() {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline /> {/* Normaliza estilos y aplica fondo del tema */}
      <AuthProvider> {/* Envolver AppRouter con AuthProvider */}
        <AppRouter />
      </AuthProvider>
    </ThemeProvider>
  );
}
export default App;
