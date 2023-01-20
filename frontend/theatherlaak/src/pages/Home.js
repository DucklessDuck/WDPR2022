import React from "react";
import "react-responsive-carousel/lib/styles/carousel.min.css"; // requires a loader
import { Carousel } from 'react-responsive-carousel';

function Home() {
        return (
          <div>
            
            <h2>Theather Laak</h2>
            <Carousel>
                <div>
                    <img src="public/logo512.png" />
                    <p className="legend">Legend 1</p>
                </div>
                <div>
                    <img src="public/logo512.png" />
                    <p className="legend">Legend 2</p>
                </div>
                <div>
                    <img src="public/logo512.png" />
                    <p className="legend">Legend 3</p>
                </div>
            </Carousel>
          </div>
        );
    }
export default Home;