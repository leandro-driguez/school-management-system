import React from "react";
import NavBar from "../components/NavBar/NavBar";
import { Tabs } from "antd";
import { useParams } from "react-router-dom";
import CRUD_Table from "../components/Table/CRUD_Table";

const { TabPane } = Tabs;

const onChange = (key) => {
    console.log(key);
};

const StudentDetails = () => {

    const { id } = useParams();

    const currentCoursesColumns = [
        {
            title: 'Nombre',
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
                    message: "Introduzca nombre",
                },
                {
                    whitespace: true,
                    message: "Introduzca nombre"
                }
            ],
        },
        {
            title: 'Tipo',
            dataIndex: 'type',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.type.localeCompare(b.type)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca tipo",
                }
            ]
        },
        {
            title: 'Grupo',
            dataIndex: 'group',
            width: '15%',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.group.localeCompare(b.group)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca salario",
                }
            ]
        },
        {
            title: 'Fecha de inscripción',
            dataIndex: 'startDate',
            width: '15%',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.startDate.localeCompare(b.startDate)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca salario",
                }
            ]
        }
    ];

    const currentCoursesTableID = 'currentCoursesTable';
    const currentCoursesSearchboxID = 'currentCoursesSearchbox';

    const paymentRecordColumns = [
        {
            title: 'Fecha',
            dataIndex: 'date',
            width: '15%',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.date.localeCompare(b.date)
            },
        },
        {
            title: 'Salario Fijo',
            dataIndex: 'fixedSalary',
            width: '15%',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.fixedSalary - b.fixedSalary
            },
        },
        {
            title: 'Salario Porcentual',
            dataIndex: 'percentageSalary',
            width: '15%',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.percentageSalary - b.percentageSalary
            },
        },
        {
            title: 'Total',
            dataIndex: 'total',
            width: '15%',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.total - b.total
            },
        }
    ];
    const paymentRecordTableID = 'paymentRecordTable';
    const paymentRecordSearchboxID = 'paymentRecordSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <Tabs centered defaultActiveKey="1" onChange={onChange}>
                <TabPane tab="Cursos actuales" key="1">
                    <CRUD_Table title={"Cursos"}
                                columns={currentCoursesColumns}
                                operations={["edit","delete","add"]}
                                url={"https://localhost:5001/api/Classrooms"}
                                tableID={currentCoursesTableID}
                                searchboxID={currentCoursesSearchboxID}
                    ></CRUD_Table>
                </TabPane>
                <TabPane tab="Histórico de pago" key="2">
                    <CRUD_Table title={"Histórico de pago"}
                                columns={paymentRecordColumns}
                                operations={[]}
                                url={"https://localhost:5001/api/Classrooms"}
                                tableID={paymentRecordTableID}
                                searchboxID={paymentRecordSearchboxID}
                    ></CRUD_Table>
                </TabPane>
            </Tabs>
        </div>
    );
};

export default StudentDetails;