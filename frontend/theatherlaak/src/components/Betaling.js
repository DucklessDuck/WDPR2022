import React, { Component } from 'react';


const handleSubmit = (event) => {
    event.preventDefault();
    // const form = event.target;
    // const amount = form.elements.amount.value;
    // const reference = form.elements.reference.value;
    // const url = form.elements.url.value;

    var details = {
        amount: form.elements.amount.value,
        reference: form.elements.reference.value,
        url: form.elements.url.value
    }

    const formBody = Object.keys(details).map(key => encodeURIComponent(key) + '=' + encodeURIComponent(details[key])).join('&');

    fetch('https://fakepay.azurewebsites.net/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8' },
        // body: JSON.stringify({ amount: amount, reference: reference, url: url }),
        body: formBody

    }).then(Response => Response.json())
    .then(data => console.log(data));
};


export class Betaling extends Component {
    static displayname = Betaling.name;

    render() {
        return (
            <div>
                <h1>Betaal je ticket(s).</h1>
                <h2>23 tickets voor *Naam voorstelling*</h2>

                <div class="row">
                    <div class="col-sm-3">

                    </div>
                    <div class="col-sm-9">
                        <div class="row">
                            <div class="col-sm-2">
                                <p>Totaal:</p>
                            </div>
                            <div class="col-sm-4">
                                <p>€10,00</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-4">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit... Un deux trois quatre, Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    </div>

                    <div class="col-sm-4">
                        <form onSubmit={handleSubmit}>
                            <label for="reference">Prijs placeholder</label>
                            <input type="text" id="prijsId" name="prijsId" value="14,59" readOnly></input><br></br>

                            <label for="reference">Reference placeholder</label>
                            <input type="text" id="referenceID" name="referenceId" value="ovo xo" readOnly></input><br></br>

                            <label for="reference">URL placeholder</label>
                            <input type="text" id="urlId" name="urlId" value="www.test.com" readOnly></input><br></br>

                            <input type="button" id="sumbitPayment" name="sumbitPayment" value="Verstuur"></input>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}
