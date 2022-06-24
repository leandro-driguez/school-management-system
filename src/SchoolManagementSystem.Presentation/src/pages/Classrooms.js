import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Classrooms = () => {
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
            width: '15%',
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
            ]
        }
    ];

    const tableID = 'ClassroomsTable';
    const searchboxID = 'ClassroomsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Aulas"} 
                columns={columns} 
                operations={["edit","delete"]}
                url={"https://localhost:5001/api/Classrooms"}
                tableID={tableID}
                searchboxID={searchboxID}
            >
            </CRUD_Table>
        </div>
    );
};

export default Classrooms;