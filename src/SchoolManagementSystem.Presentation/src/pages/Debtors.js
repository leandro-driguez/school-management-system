import React from "react";
import NavBar from "../components/NavBar/NavBar";

const Debtors = () => {
    const columns = [
        {
            title: 'CI',
            dataIndex: 'CI',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.CI.localeCompare(b.CI)
            },
        },
        {
            title: 'Nombre',
            dataIndex: 'name',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
        },
        {
            title: 'Apellidos',
            dataIndex: 'lastName',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
            },
        },
        {
            title: 'Grupo',
            dataIndex: 'group',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.group.localeCompare(b.group)
            },
        },
        {
            title: 'Deuda',
            dataIndex: 'debt',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.debt.localeCompare(b.debt)
            },
        }
    ];

    const tableID = 'CoursesTable';
    const searchboxID = 'CoursesSearchbox';

    return (
        <div>
            <NavBar></NavBar>
        </div>
    );
};

export default Debtors;