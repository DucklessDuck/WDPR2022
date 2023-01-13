import 'bootstrap/dist/css/bootstrap.css';
import './index.css';
import FakePay from '../../../Backend/Controllers/FakePay'

import React            from 'react';
import ReactDOM         from 'react-dom/client';

import App              from './App.js';
import reportWebVitals  from './reportWebVitals';
import { BrowserRouter } from 'react-router-dom';
//import * as serviceWorkerRegistration from './serviceWorkerRegistration';

//import { LoginForm } from './components/Account/Login';
//import { CreateAccountForm } from'./components/Account/CreateAccount';


const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
    //<LoginForm />
    //
    <BrowserRouter basename={baseUrl}>
        <App />
    </BrowserRouter>
);



// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
//serviceWorkerRegistration.unregister();


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
