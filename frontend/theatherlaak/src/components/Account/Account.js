import React, { useState } from 'react';
// import axios from 'axios';


//... Create Account Form ...//
export function CreateAccountForm() { 
  const [account, setAccount] = useState({});
  const handleChange = event => {
    const { name, value } = event.target;
    setAccount({ ...account, [name]: value });
  };

  const handleSubmit = event => {
    
  };

  return (
    <form onSubmit={handleSubmit}>
      <label htmlFor="name">Name:</label>
      <input type="text" id="name" name="name" onChange={handleChange} />
      <br />
      <label htmlFor="email">Email:</label>
      <input type="email" id="email" name="email" onChange={handleChange} />
      <br />
      <button type="submit">Create Account</button>
    </form>
  );
}

//... Login Form ..//
export function LoginForm() {
    // get the values of the input fields
    const handleSubmit = (event) => {
    event.preventDefault();
    const form = event.target;
    const username = form.elements.username.value;
    const password = form.elements.password.value;

      fetch('/login', {
        method: 'POST',
        body: JSON.stringify({ username, password }),
        headers: { 'Content-Type': 'application/json' },
      });
    };

    // axios.post('/login', {
    //   username: 'admin',
    //   password: 'password123',
    // });
   
    return (
      <div>
      <form onSubmit={handleSubmit}>
        <label htmlFor="username">Username:</label>
        <input type="text" name="username" />
        <br />
        <label htmlFor="password">Password:</label>
        <input type="password" name="password" />
        <br />
        <button type="submit">Log In</button>
      </form>
      </div>
    );
  }

  

//... Get Account ...//
export async function getAccounts() {
    try {
      const response = await fetch('https://api.example.com/accounts');
      const data = await response.json();
      console.log(data);
      // TODO Show data on page
    } catch (error) {
      console.error(error);
    }
}



