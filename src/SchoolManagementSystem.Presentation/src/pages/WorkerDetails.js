import React from "react";
import NavBar from "../components/NavBar/NavBar";
import { Tabs } from "antd";
import { useParams } from "react-router-dom";
import CRUD_Table from "../components/Table/CRUD_Table";

const { TabPane } = Tabs;

const onChange = (key) => {
    console.log(key);
};

const WorkerDetails = () => {

    const { id } = useParams();

    const positionsColumns = [
        {
            title: 'Cargo',
            dataIndex: 'position',
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
            title: 'Salario fijo',
            dataIndex: 'fixedSalary',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.salary - b.salary
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca salario",
                }
            ]
        }
    ];
    const positionsTableID = 'PositionsTable';
    const positionsSearchboxID = 'PositionsSearchbox';

    const acumulatedSalaryColumns = [
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
            dataIndex: 'totalFixSalary',
            width: '15%',
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.fixedSalary - b.fixedSalary
            },
        },
        {
            title: 'Salario Porcentual',
            dataIndex: 'totalCoursesPorcentualPayment',
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
    const acumulatedSalaryTableID = 'AcumulatedSalaryTable';
    const acumulatedSalarySearchboxID = 'AcumulatedSalarySearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <Tabs centered defaultActiveKey="1" onChange={onChange}>
                <TabPane tab="Cargos actuales" key="1">
                    <CRUD_Table title={"Cargos"}
                                columns={positionsColumns}
                                operations={["edit","delete","add"]}
                                url={"https://localhost:5001/api/WorkerPositionRelation/" + `${id}`}
                                tableID={positionsTableID}
                                searchboxID={positionsSearchboxID}
                    ></CRUD_Table>
                </TabPane>
                <TabPane tab="Control de salario" key="2">
                    <CRUD_Table title={"Salario Acumulado"}
                                columns={acumulatedSalaryColumns}
                                operations={[]}
                                url={"https://localhost:5001/api/ConsultWorkerSalary/"+ `${id}`}
                                tableID={acumulatedSalaryTableID}
                                searchboxID={acumulatedSalarySearchboxID}
                    ></CRUD_Table>
                </TabPane>
            </Tabs>
        </div>
    );
};

export default WorkerDetails;