import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";

const Students = () => {

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

    const columns = [
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
                    message: "Introduzca el nombre.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre."
                },
                {
                    pattern: /^[a-zA-Z]{2,}(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?$/,
                    message: 'El nombre solo puede contener letras (dos como mínimo). En caso de ser compuesto, deben estar separados por un único espacio.'
                },
            ]
        },
        {
            title: 'Apellidos',
            dataIndex: 'lastName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca los apellidos.",
                },
                {
                    whitespace: true,
                    message: "Introduzca los apellidos."
                },
                {
                    pattern: /^[a-zA-Z]{2,}(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?(\s[a-zA-Z]{2,})?$/,
                    message: 'Los apellidos solo pueden contener letras (dos como mínimo) y estar separados por un único espacio.'
                },
            ]
        },
        {
            title: 'Carnet de identidad',
            dataIndex: 'idCardNo',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.idCardNo.localeCompare(b.idCardNo)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el carnet de identidad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el carnet de identidad."
                },
                {
                    pattern: /^\d{11}$/,
                    message: 'El carnet de identidad solo puede contener números y tiene tamaño 11.'
                }
            ]
        },
        {
            title: 'Dirección',
            dataIndex: 'address',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.address.localeCompare(b.address)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la dirección.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la dirección."
                },
                {
                    pattern: /^[a-zA-Z0-9,#/&\-.\s]{1,100}$/,
                    message: "La dirección debe tener máximo 100 caracteres."
                }
            ]
        },
        {
            title: 'Grado de escolaridad',
            dataIndex: 'scholarityLevel',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.scholarityLevel.localeCompare(b.scholarityLevel)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el grado de escolaridad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el grado de escolaridad."
                },
                {
                    pattern: /^\bPrimaria|Secundaria|EscuelaOficios|TecnicoMedio|Preuniversitario|Universidad|Posgrado\b$/,
                    message: "El nivel escolar debe ser de uno de los siguientes tipos: Primaria, Secundaria, EscuelaOficios, " +
                        "TecnicoMedio, Preuniversitario, Universidad, Posgrado."
                }
            ],
        },
        {
            title: 'Fecha de inicio en la sede',
            dataIndex: 'dateBecomedMember',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.dateBecomedMember.localeCompare(b.dateBecomedMember)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la fecha de inicio en la sede.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la fecha de inicio en la sede."
                },
                {
                    //pattern: /^(0[1-9]|1[0-2])[-/.](0[1-9]|[12][0-9]|3[01])[-/.]\d{4}$/,
                    pattern: /^\b1[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|2[-/.](0[1-9]|[12][0-9]|2[08])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|3[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|4[-/.](0[1-9]|[12][0-9]|3[00])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|5[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|6[-/.](0[1-9]|[12][0-9]|3[00])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|7[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|8[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|9[-/.](0[1-9]|[12][0-9]|3[00])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|10[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|11[-/.](0[1-9]|[12][0-9]|3[00])[-/.](19[0-9][0-9]|20[01][0-9]|2022)|12[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19[0-9][0-9]|20[01][0-9]|2022)\b$/,
                    message: "El formato de la fecha debe ser M/d/yyyy. Ej: 4/22/2021."
                }
            ]
        },
        {
            title: 'Teléfono',
            dataIndex: 'phoneNumber',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.phoneNumber - b.phoneNumber
            },
            rules: [
                {
                    whitespace: true,
                    message: "Introduzca el número de teléfono."
                }
            ]
        },
        {
            title: 'Fondos',
            dataIndex: 'founds',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.founds - b.founds
            },
            rules: [
            ]
        },
        {
            title: 'Nombre del tutor',
            dataIndex: 'tuitorName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.tuitorName.localeCompare(b.tuitorName)
            },
            rules: [
            ],
        },
        {
            title: 'Teléfono del tutor',
            dataIndex: 'tuitorPhoneNumber',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.tuitorPhoneNumber - b.tuitorPhoneNumber
            },
            rules: [
            ]
        }        
    ];

    const tableID = 'StudentsTable';
    const searchboxID = 'StudentsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Estudiantes"} 
                columns={columns} 
                operations={["edit","delete","add","details","trash"]}
                url={"https://localhost:5001/api/Students"}
                tableID={tableID}
                searchboxID={searchboxID}
                link={"../StudentDetails"}
                recycle_link={"../StudentsRecycleBin"}
            thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
            >
            </CRUD_Table>
        </div>
    );
}

export default Students;