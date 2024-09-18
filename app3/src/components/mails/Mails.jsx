import {React, useState, useContext} from "react";
import { GlobalContext } from "../GlobalState";
import "./mails.css"

const Mails = ({mailsArr}) => {
    const {isLoggedIn} = useContext(GlobalContext);
    const [mails, setMails] = useState(mailsArr);
    const [selectedMails, setSelectedMails] = useState([]);

    const selectMail = (mail) => {
        setMails(mails.filter((m) => m !== mail));
        setSelectedMails([...selectedMails, mail]);
    };

    const deselectMail = (mail) => {
        setSelectedMails(selectedMails.filter((m) => m !== mail));
        setMails([...mails, mail]);
    };

    return (
        <div className="mails-container">
            <table className="base_mails-container">
                <thead>
                    <tr>
                        <th>All mails</th>
                        {isLoggedIn ? <th>Action</th> : ""}
                    </tr>
                </thead>
                <tbody>
                    {mails.length > 0 ? (
                        mails.map((mail, index) => (
                            <tr>
                                <td key={index}>{mail}</td>
                                {isLoggedIn && (<td><button onClick={() => selectMail(mail)}>Select</button></td>)}
                            </tr>
                            
                        ))
                    ) : (<tr>No letters</tr>)
                    }
                </tbody>
            </table>
            <table className="selected_mails-container">
                <thead>
                    <tr>
                        <th>Selected Mails</th>
                        {isLoggedIn ? <th>Action</th> : ""}
                    </tr>
                </thead>
                <tbody>
                    {selectedMails.length > 0 ? (
                        selectedMails.map((mail, index) => (
                            <tr>
                                <td key={index}>{mail}</td>
                                {isLoggedIn && (<td><button onClick={() => deselectMail(mail)}>Deselect</button></td>)}
                            </tr>
                        ))
                    ) : (<tr>We dont have selected</tr>)
                    }
                </tbody>
            </table>
        </div>
    );
}

export {Mails}