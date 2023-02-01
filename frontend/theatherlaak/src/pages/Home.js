import React, { Component } from "react";
import Slider from "react-slick";

function getUserRole(){
  const [userRole, setUserRole] = useState("");

useEffect(() => {
    async function fetchData() {
        const response = await fetch("/api/user/role");
        userRole = await response.json();
        setUserRole(role);
    }
    fetchData();
}, []);
}

export default class Home extends Component {

  render() {

    return (
      <div>

        <link rel="stylesheet" type="text/css" charset="UTF-8" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick.min.css" />
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick-theme.min.css" />

        <div id="bannerHome">
          <img id="bannerHomeImage" src="https://haagsevaders.nl/wp-content/uploads/2018/01/hvnl_homeslide_Laaktheater.png" />
          <p></p>
          <a id="bannerHomeBtn">Bekijk onze voorstellingen! </a>
        </div>


        <div class="eventBox">

          <div class="eventTitleBox">
            <div class="eventTitle">Aankomende Voorstellingen</div>
          </div>

          <div class="eventBoxes">

            <div id="eventBox">
              <img src="https://www.theaterkrant.nl/wp-content/uploads/2021/09/URLAND-Gabber-Opera-scenefotosnJulian-Maiwald-scaled-e1631261799626.jpg" alt="foto van voorstelling" />
                <div class="eventBoxesContainers">
                  <h4>Evenement 1</h4>
                  <p>Tekst</p>
                </div>
            </div>

            <div id="eventBox">
              <img src="https://www.theaterkrant.nl/wp-content/uploads/2021/09/URLAND-Gabber-Opera-scenefotosnJulian-Maiwald-scaled-e1631261799626.jpg" alt="foto van voorstelling" />
                <div class="eventBoxesContainers">
                  <h4 >Evenement 2</h4>
                  <p>Tekst</p>
                </div>
            </div>

            <div id="eventBox">
              <img src="https://www.theaterkrant.nl/wp-content/uploads/2021/09/URLAND-Gabber-Opera-scenefotosnJulian-Maiwald-scaled-e1631261799626.jpg" alt="foto van voorstelling" />
                <div class="eventBoxesContainers">
                  <h4>Evenement 3</h4>
                  <p>Tekst</p>
                </div>
            </div>

          </div>
        </div>


      </div>
    );
  }
}