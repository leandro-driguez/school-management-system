import React from "react";
import { useParams } from "react-router-dom";
import NavBar from "../components/NavBar/NavBar";

const StudentDetails = () => {
    
    const { id } = useParams();

    return (
        <div>
            <h1>{id}</h1>
            {/* <NavBar></NavBar>
            <p>Detalles del estudiante</p> */}
        </div>
    );
};

export default StudentDetails;