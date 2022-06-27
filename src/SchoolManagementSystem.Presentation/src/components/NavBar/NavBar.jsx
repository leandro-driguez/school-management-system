import React from "react";
import './NavBar.css';
import Logo from "../NavBar/images/Logo.jpg"
import Help from "../NavBar/images/Help.jpg"
import Account from "../NavBar/images/Account.jpg"
import Notifications from "../NavBar/images/Notification.jpg"
import Logout from "../NavBar/images/Logout.png"

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

            <button onClick={()=>localStorage.clear()}>
                <img className="logout" src={Logout} alt="Logout"/>
            </button>

            <hr/>
        </nav>
    );
}

export default NavBar;