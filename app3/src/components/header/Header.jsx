import {React, useContext} from "react";
import { GlobalContext } from "../GlobalState";
import "./header.css";
import avatar from "./66146554_p8.jpg"

const Header = () => {
    const { isLoggedIn, toggleLogin } = useContext(GlobalContext);

    return (<>
        <header>
            <section className="image-block">
                <img src={avatar} alt="profilepic" />
            </section>
            <nav>
                <a href="/">Home</a>
                <a href="/About">About</a>
                <a href="/Mails">Mails</a>
                <a href="/Products">Products</a>
                <a href="/Random">Random</a>
            </nav>
            <section>
                <button onClick={toggleLogin}>
                    {isLoggedIn ? "Login" : "Logout"}
                </button>
            </section>
        </header>
    </>)
}

export {Header}