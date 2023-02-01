import Authentication from '../../components/Authentication'
import { useNavigate } from 'react-router-dom';
//... Login Form ..//
// get the values of the input fields
const handleSubmit = (event) => {
  event.preventDefault();
  const form = event.target;
}

  //   fetch('api/Login/login', {
  //     method: 'POST',
  //     body: JSON.stringify({ email, password }),
  //     headers: { 'Content-Type': 'application/json' },
  //   });
  // };
  // }

  const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [rememberMe, setRememberMe] = useState(false);
    const { loggedIn, setLoggedIn } = useContext(Authentication);

    const navigation = useNavigate();

    useEffect(() => {
      if (roles) {
        navigation('/Portal/LayoutUser')
      } else {

      }
    })


    const handleSubmit = async (e) => {
      e.preventDefault();
      try {
        const data = {
          emailAdress: email,
          password: password
        }

        const loginResponse = await axios.post('https://localhost:7295/Login', data)
        const token = loginResponse.token
        localStorage.setItem('token', token)
        const { roles } = jwtDecode(token);
        loggedIn = true
        document.cookie = `loggedIn=${JSON.stringify({ loggedIn })}`
        document.cookie = `roles=${JSON.stringify({ roles })}`
        document.cookie = `token=${token}`
      }
      catch (error) {
        console.log(error)
      }
    }
  }



    function LoginForm() {
      return (
        <div>
          <h2>Inloggen</h2>
          <form onSubmit={handleSubmit}>
            <div class="container">
              <label htmlFor="username"><b>Gebruikersnaam</b></label>
              <input type="text" placeholder="Vul Gebruikersnaam in. " name="username" alt="Gebruikersnaam invulvak" required />
              <br />
              <label htmlFor="password"><b>Wachtwoord</b></label>
              <input type="password" placeholder="Vul Wachtwoord in. " name="password" alt="Wachtwoord invulvak" required />
              <br />
              <button className="buttonRed" type="submit">Login</button>
              <label>
                <input type="checkbox" checked="checked" name="remember" /> Onthoud mij
              </label>
            </div>

          </form>
        </div>
      );
    }
  export default LoginForm;