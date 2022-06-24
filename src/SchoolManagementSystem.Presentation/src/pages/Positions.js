import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Positions = () => {
    const columns = [
        {
            title: 'Nombre del cargo',
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
                    message: "Introduzca el nombre del cargo",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre del cargo"
                }
            ],
        }
    ];

    const tableID = 'PositionsTable';
    const searchboxID = 'PositionsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Cargos"} 
                columns={columns} 
                operations={["edit","delete"]}
                url={"https://localhost:5001/api/Positions"}
                tableID={tableID}
                searchboxID={searchboxID}
            >
            </CRUD_Table>
        </div>
    );
};

export default Positions;