import React, { useEffect, useState } from 'react';

const zalen = async () => {
    await fetch("https://localhost:7277/Zaal/get")
    .then(response => response.json())
    .then(responseData => {
        console.log(responseData);
        setZaalData(responseData)
    })
}

useEffect(() => {
    zalen()
}, [])

//... Create Voorstelling Form ...//
export function CreateVoorstellingForm() {
    const [name, setName] = useState();
    const [date, setDate] = useState();
    const [description, setDescription] = useState();
    // const [image, setImage] = useState();
    //const [image, setSelectedImage] = useState(null);
    //const [file, setFileName] = useState();



    const formatDate = (dateStr) => {
        const datum = new Date(dateStr);
        return datum.toLocaleString();
    }
    const dateConvert = formatDate(date);

    function VoorstellingAanmaken() {
        console.log("Datum Normaal-->  " + date);
        console.log("Datum Convert-->  " + dateConvert);
        fetch("https://localhost:7295/Voorstelling/create", {

            method: "POST",
            mode: "cors",
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "naamVoorstelling": name,
                "datumtijd": date,
                "beschrijving": description
                // "afbeelding": image
            })
        })
            .then(response => response.json())
            .then(data => console.log(data));
    }



    return (
        <div id="createVoorstelling">

            <label htmlFor="name">Naam voorstelling:</label>
            <input type="text" id="name" name="name" value={name} onChange={(e) => setName(e.target.value)} />
            <br />

            <label htmlFor="dateTime">Datum & tijd:</label>
            <br />
            <input type="datetime-local" id="date" name="date" value={date} onChange={(e) => setDate(e.target.value)} />
            {/* <input type="time" id="time" name="time" value={time} onChange={(e) => setTime(e.target.value)} /> */}

            <br />
            <label htmlFor="description">Beschrijving van de voorstelling:</label>
            <input type="text" id="description" name="description" value={description} onChange={(e) => setDescription(e.target.value)} />
            <br />

            {/* <label htmlFor="image">Afbeelding van de voorstelling:</label>                  
                <br />
                <input
                    type="file"
                    name="image"
                    onChange={(event) => {
                        console.log(event.target.files[0]);
                        setSelectedImage(event.target.files[0]);
                    }}
                /> */}
            <br />

            {/* <input type="file" id="image" name="image" value={image} onChange={(e) => setImage(e.target.value)} /> */}
            <br />


            <label htmlFor="zaal">Zaal:   </label>
            {/* <input type="text" id="description" name="description" value={password} onChange={(e) => setPassword(e.target.value)} /> */}



            <select name="zaal" id="zaal">
                <option value="zaalId">Hendrikszaal</option>
                <option value="zaalId">Willemzaal</option>
                <option value="zaalId">Wereldzaal</option>
            </select>

            <br />

            <button type="submit" id="submitbutton" value="Submit" onClick={() => VoorstellingAanmaken()}>Maak voorstelling aan</button>
        </div>
    );
}
