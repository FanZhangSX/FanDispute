import React, { Component } from 'react';
import {Image } from 'react-bootstrap';
import './Login.css';
import { LoginForm } from "./LoginForm";


export class Login extends Component {
    render() {
        return(<LoginForm />);
    }
}

export default Login;