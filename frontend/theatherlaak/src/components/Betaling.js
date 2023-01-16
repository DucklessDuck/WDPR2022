import React, { Component } from 'react';


const handleSubmit = (event) => {
    event.preventDefault();
    console.log('test');
    const form = event.target;
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
        // headers: { 'Content-Type': 'application/json' },
        headers: { 'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8' },
        // body: JSON.stringify({ amount: amount, reference: reference, url: url }),
        body: formBody

    }).then(
        (response) => {
            console.log(response);
            response.json().then(
                (data) => {
                    console.log(data);
                }
            );
        }
    );

    // .then(data => console.log(data));
};


export class Betaling extends Component {
    static displayname = Betaling.name;

    render() {
        return (
            <div>
                <h1>Betaal je ticket(s).</h1>
                <h2>23 tickets voor *Naam voorstelling*</h2>

                <div className="row">
                    <div className="col-sm-3">

                    </div>
                    <div className="col-sm-9">
                        <div className="row">
                            <div className="col-sm-2">
                                <p>Totaal:</p>
                            </div>
                            <div className="col-sm-4">
                                <p>€10,00</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="row">
                    <div className="col-sm-4">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit... Un deux trois quatre, Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris...</p>
                    </div>

                    <div className="col-sm-4">
                        <form onSubmit={handleSubmit}>
                            {/* <label htmlFor="rekening">Rekening nummer</label>
                            <input type="text" id="rekening" name="rekening"></input><br></br> */}

                            <label htmlFor="amount">Totale Prijs</label>
                            <input type="text" id="amount" name="amount" value="10"></input><br></br>

                            <label htmlFor="reference" hidden></label>
                            <input type="text" id="reference" name="reference" value="ovo xo" readOnly hidden></input><br></br>

                            <label htmlFor="url" hidden></label>
                            <input type="text" id="url" name="url" value="www.test.com" readOnly hidden></input><br></br>

                            <input type="submit" id="sumbitPayment" name="sumbitPayment" value="Betaal"></input>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}
