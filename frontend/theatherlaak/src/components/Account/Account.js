import React, { useState } from 'react';
import axios from 'axios';

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
  const [formData, setFormData] = useState({});

  const handleChange = event => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = event => {
    event.preventDefault();
    fetch('https://api.example.com/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        username: formData.username,
        password: formData.password,
      }),
    })
      .then(response => response.json())
      .then(data => console.log(data))
      .catch(error => console.error(error));
  };

  return (
    <form>
      <label htmlFor="username">Username:</label>
      <input type="text" id="username" name="username" onChange={handleChange} />
      <br />
      <label htmlFor="password">Password:</label>
      <input type="password" id="password" name="password" onChange={handleChange} />
      <br />
      <button type="submit" onChange={handleSubmit}>Log In</button>
    </form>
  );
}

//... Get Account ...//
async function getAccounts() {
  try {
    const response = await fetch('https://api.example.com/accounts');
    const data = await response.json();
    console.log(data);
    // TODO Show data on page
  } catch (error) {
    console.error(error);
  }
}


