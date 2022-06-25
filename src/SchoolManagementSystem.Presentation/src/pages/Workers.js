import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Workers = () => {
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
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
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
    ];

    const tableID = 'WorkersTable';
    const searchboxID = 'WorkersSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Trabajadores"} 
                columns={columns} 
                operations={["edit","delete","add","details"]}
                url={"https://localhost:5001/api/Workers"}
                tableID={tableID}
                searchboxID={searchboxID}
                link={"../WorkerDetails"}
            >
            </CRUD_Table>
        </div>
    );
};

export default Workers;