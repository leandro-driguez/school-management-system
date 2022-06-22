import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";


const BasicMean = () => {

    var json = [
        {
            title: 'Type',
            dataIndex: 'type',
            width: '15%',
            editable: true,
            dataType: 'text'
        },
        {
            title: 'Origin',
            dataIndex: 'origin',
            width: '15%',
            editable: true,
            dataType: 'text'
        },
        {
            title: 'Devaluation in time',
            dataIndex: 'devaluationInTime',
            width: '15%',
            editable: true,
            dataType: 'int'
        }
    ];

    return (

        <div>
            <NavBar></NavBar>
            <CRUD_Table
                url={"https://localhost:5001/api/BasicMean"}
                headers={json}
            > </CRUD_Table>
        </div>
    );
};

export default BasicMean;
