import React from 'react';
import { useNavigate, Link as RouterLink } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import { AppBar, Toolbar, Typography, Button, Box, IconButton, Menu, MenuItem } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';

const Navbar: React.FC = () => {
    const { isAuthenticated, logout, user } = useAuth();
    const navigate = useNavigate();
    const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(null);

    const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorElNav(event.currentTarget);
    };

    const handleCloseNavMenu = () => {
        setAnchorElNav(null);
    };

    const handleLogout = () => {
        logout();
        navigate('/login');
        handleCloseNavMenu();
    };

    return (
        <AppBar position="static">
            <Toolbar>
                {/* Logo o Título Principal */}
                <Typography
                    variant="h6"
                    noWrap
                    component={RouterLink}
                    to={isAuthenticated ? "/" : "/login"}
                    sx={{
                        mr: 2,
                        display: { xs: 'none', md: 'flex' },
                        fontFamily: 'monospace',
                        fontWeight: 700,
                        letterSpacing: '.1rem',
                        color: 'inherit',
                        textDecoration: 'none',
                    }}
                >
                    App AVANZA
                </Typography>

                {/* Menú para pantallas pequeñas */}
                <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
                    {isAuthenticated && (
                        <IconButton
                            size="large"
                            aria-label="menu"
                            aria-controls="menu-appbar"
                            aria-haspopup="true"
                            onClick={handleOpenNavMenu}
                            color="inherit"
                        >
                            <MenuIcon />
                        </IconButton>
                    )}
                    <Menu
                        id="menu-appbar"
                        anchorEl={anchorElNav}
                        anchorOrigin={{
                            vertical: 'bottom',
                            horizontal: 'left',
                        }}
                        keepMounted
                        transformOrigin={{
                            vertical: 'top',
                            horizontal: 'left',
                        }}
                        open={Boolean(anchorElNav)}
                        onClose={handleCloseNavMenu}
                        sx={{
                            display: { xs: 'block', md: 'none' },
                        }}
                    >
                        {/* Add more menu items here if needed */}
                        {isAuthenticated && user?.rol === 'Facilitador' && (
                             <MenuItem component={RouterLink} to="/facilitador" onClick={handleCloseNavMenu}>
                                <Typography textAlign="center">Dashboard Facilitador</Typography>
                            </MenuItem>
                        )}
                        {/* Example for Aprendiz - needs dynamic ID or different handling
                        {isAuthenticated && user?.rol === 'Aprendiz' && (
                             <MenuItem component={RouterLink} to={`/aprendiz/${user.id}`} onClick={handleCloseNavMenu}>
                                <Typography textAlign="center">Mi Dashboard</Typography>
                            </MenuItem>
                        )}
                        */}
                        {isAuthenticated && (
                            <MenuItem onClick={handleLogout}>
                                <Typography textAlign="center">Cerrar Sesión</Typography>
                            </MenuItem>
                        )}
                        {!isAuthenticated && (
                             <MenuItem component={RouterLink} to="/login" onClick={handleCloseNavMenu}>
                                <Typography textAlign="center">Iniciar Sesión</Typography>
                            </MenuItem>
                        )}
                         {!isAuthenticated && (
                             <MenuItem component={RouterLink} to="/register" onClick={handleCloseNavMenu}>
                                <Typography textAlign="center">Registrarse</Typography>
                            </MenuItem>
                        )}
                    </Menu>
                </Box>

                {/* Título para pantallas pequeñas (centrado o a la derecha del menú) */}
                 <Typography
                    variant="h5" // h6 might be too small if menu icon is also present
                    noWrap
                    component={RouterLink}
                    to={isAuthenticated ? "/" : "/login"}
                    sx={{
                        mr: 2,
                        display: { xs: 'flex', md: 'none' },
                        flexGrow: 1,
                        fontFamily: 'monospace',
                        fontWeight: 700,
                        letterSpacing: '.1rem',
                        color: 'inherit',
                        textDecoration: 'none',
                    }}
                >
                    AVANZA
                </Typography>

                {/* Botones para pantallas grandes */}
                <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                    {isAuthenticated && user?.rol === 'Facilitador' && (
                        <Button component={RouterLink} to="/facilitador" sx={{ my: 2, color: 'white', display: 'block' }}>
                            Dashboard Facilitador
                        </Button>
                    )}
                    {/* Example for Aprendiz
                    {isAuthenticated && user?.rol === 'Aprendiz' && (
                        <Button component={RouterLink} to={`/aprendiz/${user.id}`} sx={{ my: 2, color: 'white', display: 'block' }}>
                            Mi Dashboard
                        </Button>
                    )}
                    */}
                </Box>

                {/* Info de Usuario y Botón de Logout para pantallas grandes */}
                {isAuthenticated ? (
                    <Box sx={{ flexGrow: 0, display: 'flex', alignItems: 'center' }}>
                         <Typography sx={{ mr: 2, display: { xs: 'none', md: 'inline' } }}> {/* Ocultar en xs si es muy largo */}
                            Hola, {user?.nombre || 'Usuario'}
                         </Typography>
                        <Button color="inherit" onClick={handleLogout} sx={{display: { xs: 'none', md: 'flex' }}}>
                            Cerrar Sesión
                        </Button>
                    </Box>
                ) : (
                    <Box sx={{ flexGrow: 0, display: { xs: 'none', md: 'flex' } }}>
                        <Button component={RouterLink} to="/login" color="inherit">Iniciar Sesión</Button>
                        <Button component={RouterLink} to="/register" color="inherit">Registrarse</Button>
                    </Box>
                )}
            </Toolbar>
        </AppBar>
    );
};

export default Navbar;
