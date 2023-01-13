import React, { Component } from 'react';

export class Bestellen extends Component {
  static displayname = Bestellen.name;

  render() {
    return (
      <div>
        <div class="col-sm-6">
          <h1>Kies aantal tickets</h1>
          <h2>Romeo & Julia</h2>
          <h3>VRIJDAG 16 JUNI 2023 - 21:00 UUR</h3>

          <div class="row">
            <div class="col-sm-8">
            </div>
            <div class="col-sm-2">
              <p>Prijs</p>
            </div>
          </div>
          <div class="row">
            <div class="col-sm-8">
              <p>Normaal</p>
            </div>
            <div class="col-sm-2">
              <p>€10,00</p>
            </div>

            <div class="col-sm-2">
              <input type="button" id="deductTicket" name="deductTicket" value="-" readOnly></input>
              <input type="button" id="addTicket" name="addTicket" value="+" readOnly></input>
            </div>


          </div>
          <div class="col-sm-6">
            <p>Totale prijs </p>
          </div>
        </div>

      </div>
    );
  }
}
