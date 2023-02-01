const WachtwoordVeranderen = () => {
  return <main>
    <div class="box">
      <div class="wrapper">
        <div class="title">Wachtwoord Resetten</div>
        <form action="#">
          <div class="passwordField">
            <input type="password" required></input>
            <label>Uw huidige wachtwoord</label>
          </div>
          <div class="passwordField">
            <input type="password" required></input>
            <label>Uw nieuwe wachtwoord</label>
          </div>
          <div class="passwordField">
            <input type="password" required></input>
            <label>Herhaal uw nieuwe wachtwoord</label>
          </div>
          <div class="WachtwoordResettenField">
            <input type="submit" value="Opslaan"></input>
          </div>
        </form>
      </div>
    </div>
  </main>
};

export default WachtwoordVeranderen;
