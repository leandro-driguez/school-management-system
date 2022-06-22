import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";


const Classrooms = () => {

    var headers = [
        {
            title: 'Name',
            dataIndex: 'name',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name) 
            },
        },
        {
            title: 'Capacity',
            dataIndex: 'capacity',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.capacity - b.capacity 
            },
        }
    ];

    return (

        <div>
            <NavBar></NavBar>
            <CRUD_Table
                url={"https://localhost:5001/api/Classrooms"}
                headers={headers}
            > </CRUD_Table>
        </div>
    );
};

export default Classrooms;
