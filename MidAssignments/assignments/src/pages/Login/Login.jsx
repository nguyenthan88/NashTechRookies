import React from 'react';
import { Grid, Paper, Avatar, TextField, Button, Typography, Link } from '@mui/material';
import AddCircleOutlineOutlinedIcon from '@mui/icons-material/AddCircleOutlineOutlined';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
const Login = () => {
    const paperStyle = { padding: 40, height: '50vh', width: 280, margin: '70px auto' };
    const avatarStyle = { backgroundColor: '#1bbd7e' };
    const btnstyle = { margin: '20px 0' };
    return (
        <Grid>
            <Paper elevation={10} style={paperStyle}>
                <Grid align="center">
                    <Avatar style={avatarStyle}>
                        <AddCircleOutlineOutlinedIcon />
                    </Avatar>
                    <h2>Sign In</h2>
                </Grid>
                <TextField style={{ margin: 5 }} label="Username" placeholder="Enter username" fullWidth required />
                <TextField
                    style={{ margin: 5 }}
                    label="Password"
                    placeholder="Enter password"
                    type="password"
                    fullWidth
                    required
                />
                <FormControlLabel
                    control={<Checkbox style={{ margin: 5 }} name="checkedB" color="primary" />}
                    label="Remember me"
                />
                <Button type="submit" color="primary" variant="contained" style={{ margin: 5, btnstyle }} fullWidth>
                    Sign in
                </Button>
                <Typography style={{ margin: 5 }}>
                    <Link href="#">Forgot password ?</Link>
                </Typography>
                <Typography style={{ margin: 5 }}>
                    Do you have an account ?<Link href="/signup">Sign Up</Link>
                </Typography>
            </Paper>
        </Grid>
    );
};

export default Login;
