import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";

const Positions = () => {

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

    const columns = [
        {
            title: 'Nombre del cargo',
            dataIndex: 'name',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el nombre del cargo",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre del cargo"
                }
            ],
        }
    ];

    const tableID = 'PositionsTable';
    const searchboxID = 'PositionsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Cargos"} 
                columns={columns} 
                operations={["edit","delete","add"]}
                url={"https://localhost:5001/api/Positions"}
                tableID={tableID}
                searchboxID={searchboxID}
            >
            </CRUD_Table>
        </div>
    );
};

export default Positions;