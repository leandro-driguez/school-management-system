import React from "react";
import NavBar from "../components/NavBar/NavBar";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";
import {Divider, Tabs} from "antd";
import { useParams } from "react-router-dom";
import CRUD_Table from "../components/Table/CRUD_Table";
import {DeleteTwoTone, EditTwoTone} from "@ant-design/icons";
import "./detailsHeader.css";

const { TabPane } = Tabs;

const onChange = (key) => {
    console.log(key);
};

const StudentDetails = () => {

    const { id } = useParams();

    const currentCoursesColumns = [
        {
            title: 'Nombre',
            dataIndex: 'courseGroupCourseName',
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
            title: 'Tipo',
            dataIndex: 'courseType',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.type.localeCompare(b.type)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca tipo",
                }
            ]
        },
        {
            title: 'Grupo',
            dataIndex: 'courseGroupName',
            dataType: 'text',
            editable: true,
            sorter: {
                compare: (a, b) => a.group.localeCompare(b.group)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca grupo",
                }
            ]
        },
        {
            title: 'Fecha de inscripción',
            dataIndex: 'startDate',
            dataType: 'text',
            editable: true,
            sorter: {
                compare: (a, b) => a.startDate.localeCompare(b.startDate)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca fecha de inscripción",
                }
            ]
        }
    ];

    const currentCoursesTableID = 'currentCoursesTable';
    const currentCoursesSearchboxID = 'currentCoursesSearchbox';

    const paymentRecordColumns = [
        {
            title: 'Fecha',
            dataIndex: 'datePaid',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.datePaid.localeCompare(b.datePaid)
            },
        },
        {
            title: 'Pago',
            dataIndex: 'payment',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.payment - b.payment
            },
        },
        {
            title: 'Grupo',
            dataIndex: 'courseName',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.courseName.localeCompare(b.courseName)
            },
        }
    ];
    
    const paymentRecordTableID = 'paymentRecordTable';
    const paymentRecordSearchboxID = 'paymentRecordSearchbox';

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

    return (
        <div>
            <NavBar></NavBar>
            <Divider className={"detailsHeader"}>
                <strong>Nombre</strong> <Divider type="vertical" />
                <strong>Apellidos</strong> <Divider type="vertical" />
                CI <Divider type="vertical" />
                Teléfono <Divider type="vertical" />
                Dirección <Divider type="vertical" />
                Nivel escolar <Divider type="vertical" />
                Fecha de inicio en la sede <Divider type="vertical" />
                Fondo <Divider type="vertical" />
                Tutor <Divider type="vertical" />
                Teléfono (tutor) <Divider type="vertical" />
                <EditTwoTone /> <Divider type="vertical" />
                <DeleteTwoTone/>
            </Divider>
            <Tabs centered defaultActiveKey="1" onChange={onChange}>
                <TabPane tab="Cursos actuales" key="1">
                    <CRUD_Table title={"Cursos"}
                                columns={currentCoursesColumns}
                                operations={["edit","delete","add"]}
                                url={"https://localhost:5001/api/StudentCourseGroupRelation/" + `${id}`}
                                tableID={currentCoursesTableID}
                                searchboxID={currentCoursesSearchboxID}
                    thereIsDropdown={false}
                    ></CRUD_Table>
                </TabPane>
                <TabPane tab="Histórico de pago" key="2">
                    <CRUD_Table title={"Histórico de pago"}
                                columns={paymentRecordColumns}
                                operations={[]}
                                url={"https://localhost:5001/api/StudentPayCourseRecord/" + `${id}`}
                                tableID={paymentRecordTableID}
                                searchboxID={paymentRecordSearchboxID}
                    thereIsDropdown={false}
                    ></CRUD_Table>
                </TabPane>
            </Tabs>
        </div>
    );
};

export default StudentDetails;