import React from "react";
import NavBar from "../components/NavBar/NavBar";
import {Divider, Tabs} from "antd";
import { useParams } from "react-router-dom";
import CRUD_Table from "../components/Table/CRUD_Table";
import "./detailsHeader.css";
import {DeleteTwoTone, EditTwoTone} from "@ant-design/icons";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";

const { TabPane } = Tabs;

const onChange = (key) => {
    console.log(key);
};

const CourseDetails = () => {

    const { id } = useParams();

    const teachersColumns = [
        {
            title: 'Carnet de identidad',
            dataIndex: 'CI',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.CI.localeCompare(b.CI)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        },
        {
            title: 'Nombre',
            dataIndex: 'name',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        },
        {
            title: 'Apellidos',
            required: true,
            dataIndex: 'lastName',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        },
        {
            title: 'Porciento salarial',
            dataIndex: 'salaryPercentage',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.salaryPercentage.localeCompare(b.salaryPercentage)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca porciento salarial",
                }
            ]
        }
    ];

    const teachersTableID = 'teachersTable';
    const teachersSearchboxID = 'teachersSearchbox';

    const groupsColumns = [
        {
            title: 'Nombre',
            dataIndex: 'name',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        },
        {
            title: 'Profesor',
            dataIndex: 'teacher',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.teacher.localeCompare(b.teacher)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        },
        {
            title: 'Capacidad',
            dataIndex: 'capacity',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.capacity - b.capacity
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca salario",
                }
            ],
        },
        {
            title: 'Cantidad actual de estudiantes',
            dataIndex: 'totalStudents',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.totalStudents - b.totalStudents
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                }
            ],
        },
        {
            title: 'Fecha de inicio',
            dataIndex: 'startDate',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.startDate.localeCompare(b.startDate)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        },
        {
            title: 'Fecha de terminación',
            dataIndex: 'endDate',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.endDate.localeCompare(b.endDate)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        }
    ];
    const groupsTableID = 'groupsTable';
    const groupsSearchboxID = 'groupsSearchbox';


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
            <p>Detalles del curso</p>
        </div>
    );
};

export default CourseDetails;