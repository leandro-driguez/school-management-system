import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Courses = () => {
    const columns = [
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
                operations={["edit","delete"]}
                url={"https://localhost:5001/api/Courses"}
                tableID={tableID}
                searchboxID={searchboxID}
            >
            </CRUD_Table>
        </div>
    );
};

export default Courses;