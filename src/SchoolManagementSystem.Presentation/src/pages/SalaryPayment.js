import React, { useEffect } from "react";
import NavBar from "../components/NavBar/NavBar";
import {useState} from 'react';
import "./collapse.css";
import CRUD_Table from "../components/Table/CRUD_Table";
import {Button, Collapse, DatePicker, Modal} from "antd";
import moment from "moment";
import Dropdown from "../components/Dropdown/Dropdown";
import axios from "axios";

const { Panel } = Collapse;

const dateFormat = 'DD/MM/YYYY';

const disabledDate = (current) => {
    return current && current >= moment().endOf('day');
};

const SalaryPayment = () => {

    const [workers, setWorkers] = useState([]);

    const [workerSelected, setWorkerSelected] = useState();

    console.log(`selected ${workerSelected}`);

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

    const getData = async () => 
        await axios.get('https://localhost:5001/api/Workers')
            .then(resp=>{ 
                setWorkers(resp.data);
            });

    useEffect(()=>{
            getData();
        },[]);

    return (
        <div>
            <NavBar />
            
            <DatePicker placeholder={"Seleccione la fecha"}
                        disabledDate={disabledDate}
                        defaultValue={moment()}
                        format={dateFormat}
                        style={{
                            marginLeft: "5%",
                            borderRadius: "10px"
                        }}
            />
            
            <Dropdown title={"Select a person"} options={workers} onChange={setWorkerSelected} />

            <Collapse onChange={(key) => console.log(key)} ghost>
                <Panel header="Salario fijo: $___" key="1">
                    <CRUD_Table title={""}
                                columns={fixedSalaryPaymentColumns}
                                operations={[]}
                                url={"https://localhost:5001/api/TeacherCourseRelation" + `/${workerSelected}`}
                                tableID={fixedSalaryPaymentColumnsTableID}
                                searchboxID={fixedSalaryPaymentColumnsSearchboxID}
                    ></CRUD_Table>
                </Panel>

                <Panel header="Salario porcentual: $___" key="2">
                    <CRUD_Table title={""}
                                columns={percentageSalaryPaymentColumns}
                                operations={[]}
                                url={"https://localhost:5001/api/TeacherCourseRelation" + `/${workerSelected}`}
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
            <Modal title={"Confirmar registro de pago"}
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