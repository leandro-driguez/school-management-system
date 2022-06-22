import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";


const Classrooms = () => {

    var json = [
        {
            title: 'name',
            width: '15%',
            editable: true,
            dataType: 'text'
        },
        {
            title: 'capacity',
            width: '15%',
            editable: true,
            dataType: 'int'
        }
    ];

    return (

        <div>
            <NavBar></NavBar>
            <CRUD_Table
                url={"https://localhost:5001/api/Classrooms"}
                headers={json}
            > </CRUD_Table>
        </div>
    );
};

export default Classrooms;