import React, { Component } from "react";
import Slider from "react-slick";

async function getCarouselCards() {
  var request = await fetch("https://localhost:7295/Voorstelling/getVoorstellingen", {
  method: "POST",
  mode: "cors",
  headers: {
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json'
  }})
    .then(reponse => reponse.json())
    .then(data => console.log(data));

  let result = request;
  let carouselCards = result.json();
  
  return carouselCards;
}



export default class Home extends Component {

  render() {
    const settings = {
      dots: true,
      infinite: true,
      speed: 200,
      slidesToShow: 1,
      slidesToScroll: 1
    };

    return (
      <div>

    <link rel="stylesheet" type="text/css" charset="UTF-8" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick.min.css" /> 
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick-theme.min.css" />
        <h2>Theather Laak</h2>
        <Slider class="carousel-homepage" {...settings}>
          <div>
            <img src="../public/logo521.png" />
          </div>

          <div>
            <h3>2</h3>
          </div>

          <div>
            <h3>3</h3>
          </div>

        </Slider>

      </div>
    );
  }
}