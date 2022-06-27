import React from "react";
import {useContext, useEffect, useRef, createContext, useState} from 'react';
import NavBar from "../components/NavBar/NavBar";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";
import "./collapse.css";
import CRUD_Table from "../components/Table/CRUD_Table";
import {Button, Collapse, Modal} from "antd";

const { Panel } = Collapse;

const onChange = (key) => {
    console.log(key);
};

const SalaryPayment = () => {
    const fixedSalaryPaymentColumns = [
        {
            title: 'Cargo',
            dataIndex: 'position',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.position.localeCompare(b.position)
            },
        },
        {
            title: 'Importe',
            dataIndex: 'income',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.income.localeCompare(b.income)
            },
        }
    ];

    const fixedSalaryPaymentColumnsTableID = 'fixedSalaryPaymentColumnsTable';
    const fixedSalaryPaymentColumnsSearchboxID = 'fixedSalaryPaymentColumnsSearchbox';

    const percentageSalaryPaymentColumns = [
        {
            title: 'Grupo',
            dataIndex: 'group',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.group.localeCompare(b.group)
            },
        },
        {
            title: 'Ingreso del grupo',
            dataIndex: 'groupIncome',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.groupIncome.localeCompare(b.groupIncome)
            },
        },
        {
            title: 'Importe',
            dataIndex: 'income',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.income.localeCompare(b.income)
            },
        }
    ];

    const percentageSalaryPaymentColumnsTableID = 'percentageSalaryPaymentColumnsTable';
    const percentageSalaryPaymentColumnsSearchboxID = 'percentageSalaryPaymentColumnsSearchbox';

    const [isConfirmationModalVisible, setIsConfirmationModalVisible] = useState(false);

    return (
        <div>
            <NavBar></NavBar>
            <Collapse onChange={onChange} ghost>
                <Panel header="Salario fijo: $___" key="1">
                    <CRUD_Table title={""}
                                columns={fixedSalaryPaymentColumns}
                                operations={[]}
                                url={"https://localhost:5001/api/TeacherCourseRelation"}
                                tableID={fixedSalaryPaymentColumnsTableID}
                                searchboxID={fixedSalaryPaymentColumnsSearchboxID}
                    ></CRUD_Table>
                </Panel>

                <Panel header="Salario porcentual: $___" key="2">
                    <CRUD_Table title={""}
                                columns={percentageSalaryPaymentColumns}
                                operations={[]}
                                url={"https://localhost:5001/api/TeacherCourseRelation"}
                                tableID={percentageSalaryPaymentColumnsTableID}
                                searchboxID={percentageSalaryPaymentColumnsSearchboxID}
                    ></CRUD_Table>
                </Panel>
            </Collapse>
            <div className={"checkout"}>
            <p className={"total"}><strong>Total: $___</strong></p>
                <Button className={"checkout_button"} onClick={()=>setIsConfirmationModalVisible(true)}>
                    <strong>Registrar pago</strong>
                </Button>
            </div>
            <Modal title={"Confirmar registro"}
                   visible={isConfirmationModalVisible}
                   centered={true}
                   cancelText={"Cancelar"}
                   onCancel={() => setIsConfirmationModalVisible(false)}
                   okText={"Aceptar"}
                   onOk={() => setIsConfirmationModalVisible(false)}
            >
            <p>
                ¿Está seguro de que quiere registar el pago de salario en la fecha _________ al trabajador __________
                con un importe de $___?
            </p>
            </Modal>
        </div>
    );
};

export default SalaryPayment;