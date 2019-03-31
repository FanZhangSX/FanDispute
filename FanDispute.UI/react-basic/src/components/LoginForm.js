import React, { Component } from 'react';
import { FormGroup, FormControl, Button } from 'react-bootstrap';
import { AlertMessage } from './AlertMessage.js';
import './LoginForm.css';

export class LoginForm extends Component {

    constructor(props) {
        super(props);

        this.state = {
            email: '',
            password: '',
            teams: [],
            rememberMe: false,
            showValidation: false,
            validationColor: '',
            validationMessage: '',
            baseUrl: 'http://localhost:8899'
        };

        fetch(this.state.baseUrl + '/api/Team')
            .then(res => res.json())
            .then(data => {
                console.log(data);
                let teamsFromApi = data.map(team => { return { key:team.Id, value: team.Name, display: team.Name } })

                this.setState({ teams: [{ key:'', value: '', display: '' }].concat(teamsFromApi) });
            })
            .catch(error => {
                console.log(error);
            });
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleRememberMe = this.handleRememberMe.bind(this);
    }

    handleChange = (e) => {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    handleRememberMe = () => {
        this.setState({ rememberMe: !this.state.rememberMe });
    }

    handleSubmit = (e) => {
        e.preventDefault();

        const { email, password, team, rememberMe, baseUrl } = this.state;
        console.log(this.state);

        let formData = new FormData();
        formData.append('Email', email);
        formData.append('Password', password);
        formData.append('TeamId', "1");
        let headers=new Headers();
        //headers.append('Access-Control-Allow-Origin', 'http://localhost:3000');
        //headers.append('Content-Type', 'application/json');
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        //headers.append('Content-Type', 'text/plain');
        headers.append('Accept', 'application/json');
        
        fetch(baseUrl + "/api/Login/Login", {
            //mode: 'no-cors',
            method: 'post',
            //headers: {},
            headers: headers,
            //body: formData
            body: 'email=' + email + '&password=' + password + '&teamId=1'
            //body: JSON.stringify({'Email':email, 'Password':password, 'TeamId':"1"})
            //body: {'Email': email, 'Password':password, 'TeamId':"1"}
        })
        .then(res => res.json())
        .then(data => {
            console.log(data);
            if (data.success === true) {
                this.setState({ showValidation: true, validationColor: "success", validationMessage: data.message });
            }
            else {
                this.setState({ showValidation: true, validationColor: "danger", validationMessage: data.message });
            }
        })
        .catch(e => {
            console.log(e.message);
        });
    }

    render() {
        const { teams, showValidation, validationMessage, validationColor } = this.state;
        return (
            <form className="demoForm">
                <FormGroup>
                    <FormControl required name="email" placeholder="Email" value="fan.zhang.sx@gmail.com"
                        className="formItem" type="text" onChange={this.handleChange} />
                </FormGroup>
                <FormGroup>
                    <FormControl required name="password" placeholder="Password" type="password" value="123"
                        className="formItem" onChange={this.handleChange} />
                </FormGroup>
                <FormGroup>
                    <FormControl componentClass="select" required name="team" placeholder="Team" className="formItem" onChange={this.handleChange}>
                        {teams.map((team) => <option key={team.key} value={team.value}>{team.display}</option>)}
                    </FormControl>
                </FormGroup>

                <div className="formItem">
                <FormGroup>
                    <a className="formText" href="#forgotten-password">
                        Forgot email or password? Click here.
                    </a>
                    </FormGroup>
                </div>
                {showValidation ? <AlertMessage validationColor={validationColor} validationMessage={validationMessage} /> : null}
                <br/>
                <Button bsStyle="primary"
                    className="formItem"
                    block
                    onClick={this.handleSubmit}>Login</Button>

                <br />
                <div className="formItem">
                    <label className="checkbox-inline formText">
                        <input className="formText" id="rememberMe" name="rememberMe" type="checkbox" onChange={this.handleRememberMe}/>
                            Remember Me
                    </label>
                </div>
                <br />
            </form>

        )
    }
}