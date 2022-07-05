import React from "react";
import Login from "../components/Login/Login";
import { useState } from "react";
import axios from "axios";

const LoginPage = () => {

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
         
    if (loggedIn)
        window.location.replace("https://localhost:44441/Home");

    return(
        <div className={"login_page"}>
        <Login></Login>
        </div>
    );
};

export default LoginPage;