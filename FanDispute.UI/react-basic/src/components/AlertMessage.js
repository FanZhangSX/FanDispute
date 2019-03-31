import React, { Component } from 'react';
import { Alert } from 'react-bootstrap';
import "./AlertMessage.css";

export class AlertMessage extends Component {
    render() {
        return (
                <Alert bsStyle={this.props.validationColor} className="alert">
                    {this.props.validationMessage}
                </Alert>
            );
    }
}