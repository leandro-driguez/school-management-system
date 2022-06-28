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
            dataIndex: 'teacherIDCardNo',
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
            dataIndex: 'teacherName',
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
            dataIndex: 'teacherLastName',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca apellidos",
                },
                {
                    whitespace: true,
                    message: "Introduzca apellidos"
                }
            ],
        },
        {
            title: 'Porciento salarial',
            dataIndex: 'correspondingPorcentage',
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
            dataIndex: 'teacherName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.teacher.localeCompare(b.teacher)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca profesor",
                },
                {
                    whitespace: true,
                    message: "Introduzca profesor"
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
                    message: "Introduzca capacidad",
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
                    message: "Introduzca cantidad actual de estudiantes",
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
                    message: "Introduzca fecha de inicio",
                },
                {
                    whitespace: true,
                    message: "Introduzca fecha de inicio"
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
                    message: "Introduzca fecha de terminación",
                },
                {
                    whitespace: true,
                    message: "Introduzca fecha de terminación"
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
        window.location.replace("http://localhost:3000/");

    const tmp = [
        {
        "idCardNo": "75934499884",
        "key": "2374c000-ff26-43f9-97ff-f2d12611f77c",
        "name": "Teresa",
        "lastName": "Graveran",
        "phoneNumber": 59821123,
        "address": "Espada No.404 e/ San Benito y Esperanza",
        "dateBecomedMember": "9/5/2008 12:00:00 AM"
        },
        {
        "idCardNo": "00032834123",
        "key": "24ba6072-ea76-4109-882f-81476e899172",
        "name": "marcos",
        "lastName": "tirador",
        "phoneNumber": 76444081,
        "address": "Calle Cotilla",
        "dateBecomedMember": "5/14/2020 12:00:00 AM"
        },
        {
        "idCardNo": "00523573122",
        "key": "87e032fa-bb28-48f1-b7b7-a2394fb0211f",
        "name": "marcos",
        "lastName": "tirador",
        "phoneNumber": 76444081,
        "address": "Calle Cotilla",
        "dateBecomedMember": "5/14/2020 12:00:00 AM"
        },
        {
        "idCardNo": "78493402348",
        "key": "997df9ed-a026-47fd-acc5-88396a527045",
        "name": "Teresa",
        "lastName": "Graveran",
        "phoneNumber": 59821123,
        "address": "Espada No.404 e/ San Benito y Esperanza",
        "dateBecomedMember": "9/5/2008 12:00:00 AM"
        },
        {
        "idCardNo": "00522627123",
        "key": "99b88208-ef53-47d8-a116-0a3971489025",
        "name": "juanito",
        "lastName": "tirador",
        "phoneNumber": 76444081,
        "address": "Calle Cotilla",
        "dateBecomedMember": "5/14/2020 12:00:00 AM"
        },
        {
        "idCardNo": "65423476345",
        "key": "a4514034-f1c3-4cba-b8f2-80d0cea77ef6",
        "name": "marcos",
        "lastName": "tirador",
        "phoneNumber": 76444081,
        "address": "Calle Cotilla",
        "dateBecomedMember": "5/14/2020 12:00:00 AM"
        },
        {
        "idCardNo": "95012393872",
        "key": "bfb05d43-243a-4757-9fa1-cb6bb3958bac",
        "name": "Rebeca",
        "lastName": "Portales",
        "phoneNumber": 59821123,
        "address": "Espada No.404 e/ San Benito y Esperanza",
        "dateBecomedMember": "9/5/2008 12:00:00 AM"
        },
        {
        "idCardNo": "71022200221",
        "key": "d587b8b1-f81e-4e28-87ee-32a067c614bf",
        "name": "Teresa",
        "lastName": "Graveran",
        "phoneNumber": 59821123,
        "address": "Espada No.404 e/ San Benito y Esperanza",
        "dateBecomedMember": "9/5/2008 12:00:00 AM"
        },
        {
        "idCardNo": "90871238292",
        "key": "e785715e-9c2b-446b-b3e1-5db778aad074",
        "name": "Juan",
        "lastName": "Rodriguz",
        "phoneNumber": 57891234,
        "address": "Calle Paz",
        "dateBecomedMember": "9/21/2015 12:00:00 AM"
        },
        {
        "idCardNo": "091283928",
        "key": "fab1255c-55fd-4674-9a84-5d60d3e403ef",
        "name": "Carmen",
        "lastName": "Gonzalez",
        "phoneNumber": 58981234,
        "address": "Calle Conchita",
        "dateBecomedMember": "9/21/2012 12:00:00 AM"
        }
    ]

    return (
        <div>
            <NavBar></NavBar>
            <Divider className={"detailsHeader"}>
                <strong>Nombre</strong> <Divider type="vertical" />
                Tipo <Divider type="vertical" />
                Precio <Divider type="vertical" />
                <EditTwoTone /> <Divider type="vertical" />
                <DeleteTwoTone/>
            </Divider>
            <Tabs centered defaultActiveKey="1" onChange={onChange} >
                <TabPane tab="Profesores" key="1">
                    <CRUD_Table title={"Profesores"}
                        columns={teachersColumns}
                        operations={["edit","delete","add","details"]}
                        url={"https://localhost:5001/api/TeacherCourseRelation/" + `${id}`}
                        tableID={teachersTableID}
                        searchboxID={teachersSearchboxID}
                        link={"../WorkerDetails"}
                        thereIsDropdown={true}
                        dropDownUrl={'https://localhost:5001/api/Teachers'}
                        dropDownHeaders={['teacherName', 'teacherLastName', 'teacherIDCardNo']}
                    ></CRUD_Table>
                </TabPane>

                <TabPane tab="Grupos" key="2">
                    <CRUD_Table title={"Grupos"}
                        columns={groupsColumns}
                        operations={["edit","delete","add","details"]}
                        url={"https://localhost:5001/api/CourseCourseGroupRelation/" + `${id}`}
                        tableID={groupsTableID}
                        searchboxID={groupsSearchboxID}
                        link={"../GroupDetails"}
                        thereIsDropdown={false}
                    ></CRUD_Table>
                </TabPane>
            </Tabs>


        </div>
    );
};

export default CourseDetails;