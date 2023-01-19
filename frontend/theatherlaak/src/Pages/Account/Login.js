


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

function LoginForm() {
    return (
      <div>

        <form onSubmit={handleSubmit}>
          <div class="container">
            <label htmlFor="username"><b>Gebruikersnaam</b></label>
            <input type="text" placeholder="Vul Gebruikersnaam in. " name="username" alt="Gebruikersnaam invulvak" required /><br/>
              
            <label htmlFor="password"><b>Wachtwoord</b></label>
            <input type="password" placeholder="Vul Wachtwoord in. " name="password" alt="Wachtwoord invulvak" required /><br/>
              
            <button type="submit">Login</button>
            <label>
              <input type="checkbox" checked="checked" name="remember" /> Remember me
            </label>
          </div>

          <div class="container" style="background-color:#f1f1f1">
            <button type="button" class="cancelbtn">Cancel</button>
            <span class="psw">Forgot <a href="#">password?</a></span>
          </div>

        </form>
      </div>
    );
  }

export default LoginForm;