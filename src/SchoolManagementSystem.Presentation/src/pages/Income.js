import React, {useEffect, useState} from "react";
import NavBar from "../components/NavBar/NavBar";
import {Collapse} from "antd";
import CRUD_Table from "../components/Table/CRUD_Table";
import "./collapse.css";
import axios from "axios";
import Dropdown_NameOnly from "../components/Dropdown_NameOnly/Dropdown";

const { Panel } = Collapse;

const onChange = (key) => {
    console.log(key);
};

const Income = () => {
    const columns = [
        {
            title: 'Grupo',
            dataIndex: 'group',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
        },
        {
            title: 'Ingreso',
            dataIndex: 'income',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.income.localeCompare(b.income)
            },
        }
    ];

    const TableID = 'courseIncomeTable';
    const SearchboxID = 'courseIncomeSearchbox';

    const [courses, setCourses] = useState([]);

    const [courseSelected, setCourseSelected] = useState();

    const getData = async () =>
        await axios.get('https://localhost:5001/api/Courses')
            .then(resp=>{
                setCourses(resp.data);
            });

    useEffect(()=>{
        getData();
    },[]);

    return (
        <div>
            <NavBar></NavBar>
            <Collapse defaultActiveKey={['1']} onChange={onChange} ghost>

                <Panel header="Ingresos por curso" key="1">
                    <Dropdown_NameOnly
                        title={"Curso"}
                        options={courses}
                        onChange={setCourseSelected}
                    />

                    <CRUD_Table title={""}
                                columns={columns}
                                operations={["details"]}
                                url={"https://localhost:5001/api/TeacherCourseRelation"}
                                tableID={TableID}
                                searchboxID={SearchboxID}
                                link={"../GroupDetails"}
                    ></CRUD_Table>
                </Panel>
            </Collapse>
        </div>
    );
};

export default Income;