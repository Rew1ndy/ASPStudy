import React from "react";
import "./home.css";

const pallete = ["red", "orange", "black", "purple"];

const Home = () => {
    return (<>
        <section className="Home">
            <h1>Home Page!</h1>
            <div className="clour-wrapper">
            {
                pallete.map(value => (
                    <>
                        <div className="colour-pallete">
                            <div className="colour-stile" style={{backgroundColor: `${value}`}}></div>
                            <div className="colour-name" style={{color: `${value}`}}>{value}</div>
                        </div>
                    </>
                ))
            }
            </div>
        </section>
    </>)
}

export {Home}