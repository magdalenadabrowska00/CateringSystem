import React from 'react';
import ProgressiveImage from "react-progressive-graceful-image";
import cateringfile1 from './Pictures/cateringfile1.jpg'

function About(){
    return(
        <>
        <div>
            <h1>Hello! </h1>
            <h2>On our website you will find a variety of catering offers from the best companies on the market.</h2>
            <h2>You will definitely find what you need!</h2>
        </div>
        <ProgressiveImage src={cateringfile1}>
        {
            (src) => (
            <img 
                src={src}
                width="1200"
                height="465"
            />
        )}
        </ProgressiveImage>     
        </>
    )
}

export default About;