import React from "react";
import { useRouteError } from "react-router-dom";
// import "./errorPage.css";

const ErrorPage = () => {
    const error = useRouteError();
    console.error(error);

    return (<>
        <section className="ErrorPage">
            <h1>Oops!</h1>
            <p>Sorry, an unexpected error has occurred.</p>
            <p>
                <i>{error.statusText || error.message}</i>
            </p>
        </section>
    </>)
}

export {ErrorPage}