import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Students = () => {
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
                    message: "Introduzca el nombre.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre."
                }
            ]
        },
        {
            title: 'Apellidos',
            dataIndex: 'lastName',
            width: '15%',
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
                }
            ]
        },
        {
            title: 'Carnet ID',
            dataIndex: 'key',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.key.localeCompare(b.key)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el carnet ID.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el carnet ID."
                }
            ]
        },
        {
            title: 'Teléfono',
            dataIndex: 'phoneNumber',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.phoneNumber - b.phoneNumber
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el número de teléfono.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el número de teléfono."
                }
            ]
        },
        {
            title: 'Dirección',
            dataIndex: 'address',
            width: '15%',
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
                }
            ]
        },
        {
            title: 'Grado de escolaridad',
            dataIndex: 'scholarityLevel',
            width: '15%',
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
                }
            ],
        },
        {
            title: 'Fecha de inicio en la sede',
            dataIndex: 'dateBecomedMember',
            width: '15%',
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
                }
            ]
        },
        {
            title: 'Fondos',
            dataIndex: 'founds',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.founds - b.founds
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca los fondos.",
                },
                {
                    whitespace: true,
                    message: "Introduzca los fondos."
                }
            ]
        },
        {
            title: 'Nombre del tutor',
            dataIndex: 'tuitorName',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.tuitorName.localeCompare(b.tuitorName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el nombre del tutor.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre del tutor."
                }
            ],
        },
        {
            title: 'Teléfono del tutor',
            dataIndex: 'tuitorPhoneNumber',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.tuitorPhoneNumber - b.tuitorPhoneNumber
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el teléfono del tutor",
                },
                {
                    whitespace: true,
                    message: "Introduzca el teléfono del tutor"
                }
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
                operations={["edit","delete","add","details"]}
                url={"https://localhost:5001/api/Students"}
                tableID={tableID}
                searchboxID={searchboxID}
                link={"../StudentDetails"}
            >
            </CRUD_Table>
        </div>
    );
}

export default Students;