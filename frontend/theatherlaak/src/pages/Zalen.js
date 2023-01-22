import React, { useState } from 'react';
const Zalen = () => {
  const [halls, setHalls] = useState([
    { name: "Hall 1", seats: { ranking1: 20, ranking2: 100, ranking3: 120 } },
    { name: "Hall 2", seats: { ranking1: 20, ranking2: 160, ranking3: 0 } },
    { name: "Hall 3", seats: { ranking1: 10, ranking2: 80, ranking3: 0 } },
    { name: "Hall 4", seats: { ranking1: 40, ranking2: 0, ranking3: 0 } },
  ]);

  const addHall = (name, ranking1Seats, ranking2Seats, ranking3Seats) => {
    setHalls([...halls, { name, seats: { ranking1: ranking1Seats, ranking2: ranking2Seats, ranking3: ranking3Seats } }]);
  };

  const updateHall = (index, name, ranking1Seats, ranking2Seats, ranking3Seats) => {
    const updatedHalls = [...halls];
    updatedHalls[index] = { name, seats: { ranking1: ranking1Seats, ranking2: ranking2Seats, ranking3: ranking3Seats } };
    setHalls(updatedHalls);
  };

  const deleteHall = (index) => {
    const updatedHalls = [...halls];
    updatedHalls.splice(index, 1);
    setHalls(updatedHalls);
  };

  return (
    <div>
      <h1>Performance Halls</h1>
      <div>
        {halls.map((hall, index) => (
          <div key={index}>
            <p>Name: {hall.name}</p>
            <p>Seats - Ranking 1: {hall.seats.ranking1}</p>
            <p>Seats - Ranking 2: {hall.seats.ranking2}</p>
            <p>Seats - Ranking 3: {hall.seats.ranking3}</p>
            <button onClick={() => updateHall(index, hall.name, hall.seats.ranking1, hall.seats.ranking2, hall.seats.ranking3)}>
              Update
            </button>
            <button onClick={() => deleteHall(index)}>Delete</button>
          </div>
        ))}
      </div>
      <div>
        <h2>Add Performance Hall</h2>
        <p>
          <label>
            Name:
            <input type="text" id="name" />
          </label>
        </p>
        <p>
          <label>
            Seats - Ranking 1:
            <input type="number" id="ranking1Seats" />
          </label>
        </p>
        <p>
          <label>
            Seats - Ranking 2:
            <input type="number" id="ranking2Seats" />
          </label>
        </p>
        <p>
          <label>
            Seats - Ranking 3:
            <input type="number" id="ranking3Seats" />
          </label>
        </p>
        <button onClick={() => addHall(document.getElementById('name').value, document.getElementById('ranking1Seats').value, document.getElementById('ranking2Seats').value, document.getElementById('ranking3Seats').value)}>
          Add
        </button>
      </div>
    </div>
  );
        };
export default Zalen;