//... Login Form ..//
    // get the values of the input fields
    const handleSubmit = (event) => {
    event.preventDefault();
    const form = event.target;
    const username = form.elements.username.value;
    const password = form.elements.password.value;

      fetch('api/Login/login', {
        method: 'POST',
        body: JSON.stringify({ username, password }),
        headers: { 'Content-Type': 'application/json' },
      });
    };

    // axios.post('/login', {
    //   username: 'admin',
    //   password: 'password123',
    // });

export function LoginForm() {
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