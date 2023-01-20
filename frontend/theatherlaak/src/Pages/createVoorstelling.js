import React, { useState } from 'react';

//... Create Account Form ...//


export function CreateVoorstellingForm() {
    const [name, setName] = useState();
    const [date, setDate] = useState();
    const [description, setDescription] = useState();
    // const [image, setImage] = useState();
    
    const [image, setSelectedImage] = useState(null);
    


        function VoorstellingAanmaken() {
            var dateString = date;
            var dateTimer = new Date(dateString);
            console.log(dateString);

            var x = document.getElementById("date").value;
            console.log(x);

            fetch("https://localhost:7295/Voorstelling/create", {

                method: "POST",
                mode: "cors",
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    "naamVoorstelling": name,
                    "datumEntijd": x,
                    "beschrijving": description,
                    "afbeelding": image
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
                <input type="datetime-local" id="date" name="date" value={date} onChange={(e) => setDate(e.target.value)} />
                {/* <input type="time" id="time" name="time" value={time} onChange={(e) => setTime(e.target.value)} /> */}
                <br />

                <label htmlFor="description">Beschrijving van de voorstelling:</label>
                <input type="text" id="description" name="description" value={description} onChange={(e) => setDescription(e.target.value)} />
                <br />

                <label htmlFor="image">Afbeelding van de voorstelling:</label>
                <input
                    type="file"
                    name="image"
                    onChange={(event) => {
                        console.log(event.target.files[0]);
                        setSelectedImage(event.target.files[0]);
                    }}
                />
                <br />

                {/* <input type="file" id="image" name="image" value={image} onChange={(e) => setImage(e.target.value)} /> */}
                <br />


                <label htmlFor="zaal">Zaal</label>
                {/* <input type="text" id="description" name="description" value={password} onChange={(e) => setPassword(e.target.value)} /> */}

                <select name="zaal" id="zaal">
                    <option value="zaalId">Hendrikszaal</option>
                    <option value="zaalId">Willemzaal</option>
                    <option value="zaalId">Wereld zaal</option>
                </select>

                <br />

                <button type="submit" id="submitbutton" value="Submit" onClick={() => VoorstellingAanmaken()}>Maak voorstelling aan</button>
            </div>
        );
    }



