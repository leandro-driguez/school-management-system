import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";


const Courses = () => {

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
            title: 'Nombre',
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
                    message: "Introduzca la capacidad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la capacidad."
                }
            ]
        },
        {
            title: 'Tipo',
            dataIndex: 'type',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.type.localeCompare(b.type)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el tipo de curso.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el tipo de curso."
                }
            ],
        },
        {
            title: 'Precio',
            dataIndex: 'price',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.price - b.price
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el precio.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el precio."
                }
            ]
        }
    ];

    const tableID = 'CoursesTable';
    const searchboxID = 'CoursesSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Cursos"} 
                columns={columns} 
                operations={["edit","delete","add","details"]}
                url={"https://localhost:5001/api/Courses"}
                tableID={tableID}
                searchboxID={searchboxID}
                link={"../CourseDetails"}
            >
            </CRUD_Table>
        </div>
    );
};

export default Courses;