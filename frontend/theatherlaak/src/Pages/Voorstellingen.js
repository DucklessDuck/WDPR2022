







import { useState } from "react";
import React from 'react';
import { CreateVoorstellingForm } from "./createVoorstelling";


function MyForm() {
    const [inputs, setInputs] = useState({});

    // const handleChange = (event) => {
    //     const name = event.target.name;
    //     const value = event.target.value;
    //     setInputs(values => ({ ...values, [name]: value }))
    // }

    // const handleSubmit = (event) => {
    //     event.preventDefault();
    //     console.log(inputs);
    // }

    return (
        <div class="row">
            <div class="column">
                <div class="card">
                    <h3>Voorstelling 1</h3>
                    <p>Prachtige voorstelling met live muziek</p>
                    <p>Toegangelijk voor invalide</p>
                </div>
            </div>

            <div class="column">
                <div class="card">
                    <h3>Card 2</h3>
                    <p>Some text</p>
                    <p>Some text</p>
                </div>
            </div>

            <div class="column">
                <div class="card">
                    <h3>Card 3</h3>
                    <p>Some text</p>
                    <p>Some text</p>
                </div>
            </div>

            <div class="column">
                <div class="card">
                    <h3>Card 4</h3>
                    <p>Some text</p>
                    <p>Some text</p>
                </div>
            </div>
        </div>
    )
}

// const Voorstellingen = () => {
//     return <h1> <MyForm /></h1>;
// };


export default CreateVoorstellingForm;