import React, { Component } from 'react';




export class Agenda extends Component {
    static displayname = Agenda.name;


    constructor(props) {
        super(props);
        this.state = { voorstellingen: [], loading: true };
    }

    componentDidMount() {
        this.populateVoorstellingData();
    }

    static renderAgenda(vData) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <tbody>
                    {vData.map(voorstelling =>
                        <tr key={voorstelling.voorstellingid}>
                            <td>{voorstelling.naamvoorstelling}</td>
                            <td>{voorstelling.datumtijd}</td>
                            <td>{voorstelling.beschrijving}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Laden van de pagina...</em></p>
            : Agenda.renderAgenda(this.state.voorstellingen);

        // const Agenda = ({ voorstellingData }) => {
        return (
            <div>
                <h1>Agenda Laaktheater</h1>
                <div class="row container-voorstellingen">
                    <div class="col-sm-10">
                        {contents}


                        {
                            /* {voorstellingen.map((voorst) => (
                                    <div key={voorst.VoorstellingId}>
                                        <h5>{voorst.NaamVoorstelling}</h5>
                                    </div>
                                ))} */
                        }
                    </div>
                </div>
            </div>
        );
        // }
    }

    async populateVoorstellingData() {
        const response = await fetch("https://randomuser.me/api?results=10");
        const data = await response.json();

        console.log('Returned event data:', JSON.stringify(data, null, 2));

        this.setState({ voorstellingen: data, loading: false });
    }
}