import React from "react";
import './NavBar.css';
import 'antd/dist/antd.css';
import Logo from "../NavBar/images/Logo.jpg"
import Help from "../NavBar/images/Help.jpg"
import Account from "../NavBar/images/Account.jpg"
import Notifications from "../NavBar/images/Notification.jpg"
import Logout from "../NavBar/images/Logout.png"
import {Dropdown, Menu, Space} from "antd";
import {DownOutlined} from "@ant-design/icons";
import { Button, Drawer, List, Alert } from 'antd';
import { useState,  useEffect } from 'react';
import axios from 'axios';

import { Badge } from 'antd';

const NavBar = (props) => {
    
    const [visibleCount, setVisibleCount] = useState(false);
    const [visibleNoti, setVisibleNoti] = useState(false);
    const [data, setData] = useState([])

    const showDrawerCount = () => {
        setVisibleCount(true);
    };

    const onCloseCount = () => {
        setVisibleCount(false);
    };

    const showDrawerNoti = () => {
        setVisibleNoti(true);
    };

    const onCloseNoti = () => {
        setVisibleNoti(false);
    };

    const getData = async () => 
        await axios.get("https://localhost:5001/api/DebtorsNotification")
            .then(resp=>{ 
                setData([resp.data]);
            });

    const menu = (
        <Menu
            items={[
                {
                    label: <p>{localStorage["username"]}</p>,                    
                    key: '0',
                },
                {
                    label: <a href="https://localhost:3000/" onClick={() => localStorage.clear()}>Cerrar sesión</a>,
                    key: '1',
                },
            ]}
        />
    );

    useEffect(()=>{
        getData();
    },[]);

    //const data = [
    //    {
    //      title: 'Título de Notificación 1',
    //      description: 'Descripción 1'
    //    },
    //    {
    //        title: 'Título de Notificación 2',
    //        description: 'Descripción 2'
    //    },
    //    {
    //        title: 'Título de Notificación 3',
    //        description: 'Descripción 3'
    //    }
    //  ];
    
    
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
                <Badge count = {data.length} className="navb_right"
                    offset={[-10,15]}>
                <a onClick={showDrawerNoti}>
                    <img
                    className="navb_right"
                    src={Notifications}
                    alt="Notificaciones"
                    />
                </a>
                </Badge>
            
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

           

        <Drawer title= {<p className="notiName"><b>Notificaciones</b></p>}
                placement="right"
                onClose={onCloseNoti} visible={visibleNoti}>
        
        <List
            itemLayout="horizontal"            
            dataSource={data}
            renderItem={(item) => (
            <List.Item>                
                <Alert
                message={item.title}
                description={item.descrpition}
                type="warning"
                showIcon
                closable
                />               
            </List.Item>
            )}
        />
        </Drawer>

        </nav>
    );
}


export default NavBar;
