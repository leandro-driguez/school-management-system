import React from "react";
import { useParams } from "react-router-dom";
import NavBar from "../components/NavBar/NavBar";

const CourseDetails = () => {

    const { id } = useParams();

    return (
        <div>
            <h1>{id}</h1>
            <NavBar></NavBar>
            <p>Detalles del curso</p>
        </div>
    );
};

export default CourseDetails;