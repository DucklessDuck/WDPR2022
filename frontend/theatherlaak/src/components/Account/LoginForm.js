import React, { useState } from 'react';

function LoginForm() {
  const [formData, setFormData] = useState({});

  const handleChange = event => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value})
  }
}
