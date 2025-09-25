
import {
  Container,
  Box,
  TextField,
  Button,
  Typography,
  Paper,
} from "@mui/material";
import { TMSClient } from "./api/TMSClient";
import { useState } from "react";
import type { Login } from "./api/Models/Login";

const SignIn = () => {

    const api = new TMSClient("https://localhost:7078");

    const [userName, setUserName] = useState("");
    const [password, setpassword] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);


    const handleLogin = async (e:any) =>{
        debugger;
        e.preventDefault();

        setError("");

        if(!userName)
        {
            setError("username is required");
        }

        if(!password)
        {
            setError("password is required")
        }

        try{
            setLoading(true);
            const loginData: Login={
                email: userName,
                password: password
            }
            const response =  await  api.apiAuthLogin(loginData);
            if(response != null)
            {
                //success
                alert("login done.");
            }
            else{

            }
        }
        catch(err:any)
        {
            setError(err.message || "some thing went wrongs.")
        }
        finally
        {
            setLoading(false);
        }
        

    }


  return (
    <div>

          <Container maxWidth="sm">
              <Paper elevation={3} sx={{ p: 4, mt: 8, borderRadius: 3 }}>
                  <Typography variant="h4" align="center" gutterBottom>
                      Welcome
                  </Typography>

                  <Box >
                      <form>
                          <TextField
                              label="UserName"
                              type="text"
                              fullWidth
                              margin="normal"
                              required
                              onChange={(e)=>setUserName(e.target.value)}
                          />
                          <TextField
                              label="Password"
                              type="password"
                              fullWidth
                              margin="normal"
                              required
                              onChange={(e)=> setpassword(e.target.value)}
                          />
                          <Button
                              variant="contained"
                              color="primary"
                              fullWidth
                              sx={{ mt: 2 }}
                              onClick={handleLogin}
                          >
                              {loading ? "Logging in": "Login In"}
                          </Button>
                      </form>

                  </Box>

              </Paper>
          </Container>
    </div>
  )
}

export default SignIn