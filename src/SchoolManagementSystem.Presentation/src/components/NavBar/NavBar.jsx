import React from "react";
import './NavBar.css';
import Logo from "../NavBar/images/Logo.jpg"
import Help from "../NavBar/images/Help.jpg"
import Account from "../NavBar/images/Account.jpg"
import Notifications from "../NavBar/images/Notification.jpg"
import Logout from "../NavBar/images/Logout.png"
import {Dropdown, Menu, Space} from "antd";
import {DownOutlined} from "@ant-design/icons";

const NavBar = () => {
    const menu = (
        <Menu
            items={[
                {
                    label: <a href="https://www.antgroup.com">Mi cuenta</a>,
                    key: '0',
                },
                {
                    label: <a onClick={() => localStorage.clear()}>Cerrar sesión</a>,
                    key: '1',
                },
            ]}
        />
    );

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

            <Dropdown overlay={menu} trigger={['click']}>
                <a
                    style={{
                        padding: "0",
                        border: "none",
                        margin: "0",
                        float: "right"
                    }}
                    onClick={(e) => e.preventDefault()}>
                    <Space>
                        <img className="navb_right" src={Account} alt="Mi cuenta"
                        />
                    </Space>
                </a>
            </Dropdown>

            <hr/>
        </nav>
    );
}

export default NavBar;