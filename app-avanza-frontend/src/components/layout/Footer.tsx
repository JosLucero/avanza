import React from 'react';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';

const Footer: React.FC = () => {
    return (
        <Box
            component="footer"
            sx={{
                py: 3,
                px: 2,
                mt: 'auto',
                backgroundColor: (theme) =>
                    theme.palette.mode === 'light'
                        ? theme.palette.grey[200]
                        : theme.palette.grey[800],
            }}
        >
            <Typography variant="body2" color="text.secondary" align="center">
                {'© '}
                {new Date().getFullYear()}{' '}
                AppAvanza. Todos los derechos reservados.
            </Typography>
        </Box>
    );
};

export default Footer;
