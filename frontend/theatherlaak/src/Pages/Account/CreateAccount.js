import React, { useState } from 'react';

//... Create Account Form ...//

export function CreateAccountForm() {
  const [name, setName] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  function createAccount() {
    fetch("https://localhost:7295/Account/create", {
      method: "POST",
      mode: "cors",
      headers: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        "username": name,
        "emailAddress": email,
        "password": password
      })
    })
      .then(response => response.json())
      .then(data => console.log(data));
  }

  return (
    <div id="createAccountForm">
      <label htmlFor="name">Name:</label>
      <input type="text" id="name" name="name" value={name} onChange={(e) => setName(e.target.value)} />
      <br />
      <label htmlFor="password">Password:</label>
      <input type="password" id="paswword" name="password" value={password} onChange={(e) => setPassword(e.target.value)} />
      <br />
      <label htmlFor="email">Email:</label>
      <input type="email" id="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)} />
      <br />
      <button type="submit" value="Submit" onClick={() => createAccount()}>Create Account</button>
    </div>
  );
}




