import React from "react";
import './NavBar.css';
import Logo from "../NavBar/images/Logo.jpg"
import Help from "../NavBar/images/Help.jpg"
import Account from "../NavBar/images/Account.jpg"
import Notifications from "../NavBar/images/Notification.jpg"

const NavBar = () => {
    return (
        <nav>
            <img
                className="navb_left"

                src={Logo}
                alt="Logo y nombre D'Clase"
            />

            <a href="students.html"
            ><img className="navb_right" src={Help} alt="Ayuda"
            /></a>

            <a href="students.html"
            ><img
                className="navb_right"
                src={Notifications}
                alt="Notificaciones"
            /></a>

            <a href="students.html"
            ><img className="navb_right" src={Account} alt="Mi cuenta"
            /></a>

            <hr/>
        </nav>
    );
}

export default NavBar;