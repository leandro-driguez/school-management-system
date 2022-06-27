import React from "react";
import NavBar from "../components/NavBar/NavBar";
import Menu from "../components/Menu/Menu";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";


const Home = () => {

    const [loggedIn] = useState(()=>{
        if (localStorage['token'] == null)
            return false;

        let respOk = true;

        const JWT = JSON.parse(localStorage['token']);

        axios.get("https://localhost:5001/api/Authenticate/loggedIn", 
                    { headers: { "Authorization": `Bearer ${JWT.token}` } })
                .catch((err) => {
                respOk = false;
                console.log(err.response);
            });

        return respOk;
    });
         
    if (!loggedIn)
        return <Login />;

    return (
        <div>
            <NavBar></NavBar>
            <Menu></Menu>
        </div>
    );
};

export default Home;