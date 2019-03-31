import React from "react";
import ReactDOM from "react-dom";
import axios from "axios";
import Pusher from "pusher-js";
import { Component } from "react";
import { BrowserRouter } from 'react-router-dom';
import registerServiceWorker from './registerServiceWorker';
import App from './App';

/*
export class App extends Component {
    constructor(props) {
        super(props);
        fetch("api/Account")
            .then(ret => ret.json())
            .then(data => {
                console.log(data);
            })
            .catch(e => {
                console.log(e);
            });

        console.log("HHA");
    }

    render() {
        return (
            <div>aa</div>
            );
    }
}
*/
ReactDOM.render(<App />, document.getElementById("root"));

registerServiceWorker();