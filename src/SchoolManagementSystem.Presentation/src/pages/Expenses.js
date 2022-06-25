import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Expenses = () => {
    const columns = [
        {
            title: 'Categoría',
            dataIndex: 'category',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.category.localeCompare(b.category)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la categoría",
                },
                {
                    whitespace: true,
                    message: "Introduzca la categoría"
                }
            ],
        },
        {
            title: 'Descripción',
            dataIndex: 'description',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.description.localeCompare(b.description)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la descripción",
                },
                {
                    whitespace: true,
                    message: "Introduzca la descripción"
                }
            ]
        }
    ];

    const tableID = 'ExpensesTable';
    const searchboxID = 'ExpensesSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Gastos"} 
                columns={columns} 
                operations={["edit","delete","add"]}
                url={"https://localhost:5001/api/Expenses"}
                tableID={tableID}
                searchboxID={searchboxID}
            >
            </CRUD_Table>
        </div>
    );
};

export default Expenses;