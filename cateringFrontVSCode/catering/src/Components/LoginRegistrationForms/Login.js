/*
import { Button, FormControl, FormGroup, FormLabel,Grid } from "@mui/material";
import React,{ useState } from "react";
import Header from "./Header"
import LoginForm from "./LoginForm"

export default function Login(){
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");




    return ( */
        /* 
        <div className="login">
            <Grid onSubmit={handleSubmit}>
                <FormGroup size="lg" controllId="email">
                    <FormLabel>Email</FormLabel>
                    <FormControl autoFocus type="email" value={email} onChange={(e) => setEmail(e.target.value)}/>
                </FormGroup>
                <FormGroup size="lg" controllId="password">
                    <FormLabel>Password</FormLabel>
                    <FormControl type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
                </FormGroup>
                <Button block size="lg" type="submit" >
                    Login
                </Button>
            </Grid>

        </div>
        */
       /*
        <div className='form'>
            <div className='form-body' onSubmit={handleSubmit}>
                <div className='useremail'>
                    <label className='form_label' for="UserEmail">Email</label>
                    <input className="form__input" type="text" id="email" placeholder="Email"
                        autoFocus value={email} onChange={(e) => setEmail(e.target.value)}/>
                </div>
                <div className='password'>
                    <label className='form_label' for="Password">Password</label>
                    <input className="form__input" type="text" id="password" placeholder="Password"
                        value={password} onChange={(e) => setPassword(e.target.value)}/>
                </div>
            </div>
            <div className='footer'>
                <button type="submit" class="btn">
                    Login
                </button>
            </div>
        </div>
    )
}

function handleSubmit(event) {
    event.preventDefault();
} */

/*
            <Header />
            <LoginForm/>
             */


            import React, { useState, useRef } from "react";
            import { useNavigate } from 'react-router-dom';
            import Form from "react-validation/build/form";
            import Input from "react-validation/build/input";
            import CheckButton from "react-validation/build/button";
            import AuthService from "../../Services/Authentication";
            const required = (value) => {
              if (!value) {
                return (
                  <div className="alert alert-danger" role="alert">
                    This field is required!
                  </div>
                );
              }
            };
            const Login = () => {
              let navigate = useNavigate();
              const form = useRef();
              const checkBtn = useRef();
              const [username, setUsername] = useState("");
              const [password, setPassword] = useState("");
              const [loading, setLoading] = useState(false);
              const [message, setMessage] = useState("");
              const onChangeUsername = (e) => {
                const username = e.target.value;
                setUsername(username);
              };
              const onChangePassword = (e) => {
                const password = e.target.value;
                setPassword(password);
              };
              const handleLogin = (e) => {
                e.preventDefault();
                setMessage("");
                setLoading(true);
                form.current.validateAll();
                if (checkBtn.current.context._errors.length === 0) {
                  AuthService.login(username, password).then(
                    () => {
                      navigate("/home");
                      window.location.reload();
                    },
                    (error) => {
                      const resMessage =
                        (error.response &&
                          error.response.data &&
                          error.response.data.message) ||
                        error.message ||
                        error.toString();
                      setLoading(false);
                      setMessage(resMessage);
                    }
                  );
                } else {
                  setLoading(false);
                }
              };
              return (
                <div className="col-md-12">
                  <div className="card card-container">
                    <Form onSubmit={handleLogin} ref={form}>
                      <div className="form-group">
                        <label htmlFor="username">Username</label>
                        <Input
                          type="text"
                          className="form-control"
                          name="username"
                          value={username}
                          onChange={onChangeUsername}
                          validations={[required]}
                        />
                      </div>
                      <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <Input
                          type="password"
                          className="form-control"
                          name="password"
                          value={password}
                          onChange={onChangePassword}
                          validations={[required]}
                        />
                      </div>
                      <div className="form-group">
                        <button className="btn btn-primary btn-block" disabled={loading}>
                          {loading && (
                            <span className="spinner-border spinner-border-sm"></span>
                          )}
                          <span>Login</span>
                        </button>
                      </div>
                      {message && (
                        <div className="form-group">
                          <div className="alert alert-danger" role="alert">
                            {message}
                          </div>
                        </div>
                      )}
                      <CheckButton style={{ display: "none" }} ref={checkBtn} />
                    </Form>
                  </div>
                </div>
              );
            };
            export default Login;