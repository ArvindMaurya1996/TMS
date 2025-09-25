import { Box, Button, TextField } from "@mui/material";


const Register =()=>{
    return(
        <Box component="form" noValidate autoComplete="off">
            <TextField
              label="Full Name"
              fullWidth
              margin="normal"
              required
            />
            <TextField
              label="Email"
              type="email"
              fullWidth
              margin="normal"
              required
            />
            <TextField
              label="Password"
              type="password"
              fullWidth
              margin="normal"
              required
            />
            <TextField
              label="Confirm Password"
              type="password"
              fullWidth
              margin="normal"
              required
            />
            <Button
              variant="contained"
              color="secondary"
              fullWidth
              sx={{ mt: 2 }}
            >
              Register
            </Button>
          </Box>
    );

}

export default Register