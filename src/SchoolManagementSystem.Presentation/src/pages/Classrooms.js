import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Classrooms = () => {
    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table></CRUD_Table>
        </div>
    );
};

export default Classrooms;