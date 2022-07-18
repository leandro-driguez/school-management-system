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

    const [courses, setCourses] = useState([]);

    const [courseSelected, setCourseSelected] = useState();

    const [dateSelected, setDateSelected] = useState(moment().format("YYYY-MM-DD"));

    console.log(`selected ${courseSelected}`);

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
            dataIndex: 'fixSalaryPosition',
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
            dataIndex: 'courseGroupName',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.group.localeCompare(b.group)
            },
        },
        {
            title: 'Ingreso del grupo',
            dataIndex: 'courseGroupIncome',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.groupIncome.localeCompare(b.groupIncome)
            },
        },
        {
            title: 'Importe',
            dataIndex: 'courseGroupWorkerPayment',
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.income.localeCompare(b.income)
            },
        }
    ];

    const percentageSalaryPaymentColumnsTableID = 'percentageSalaryPaymentColumnsTable';
    const percentageSalaryPaymentColumnsSearchboxID = 'percentageSalaryPaymentColumnsSearchbox';

    const [isConfirmationModalVisible, setIsConfirmationModalVisible] = useState(false);

    const [urlFixSalaryTable, setUrlFixSalaryTable] = useState("https://localhost:5001/api/WorkerPaymentGetFixSalary" + `/${workerSelected}` + `/${dateSelected}`);

    // setUrlFixSalaryTable("https://localhost:5001/api/WorkerPaymentGetFixSalary" + `/${workerSelected}` + `/${dateSelected}`);

    const [urlSalaryPerCourseTable, setUrlSalaryPerCourseTable] = useState("https://localhost:5001/api/WorkerPaymentGetSalaryPerCourse" + `/${workerSelected}` + `/${courseSelected}` + `/${dateSelected}`);

    // setUrlSalaryPerCourseTable("https://localhost:5001/api/WorkerPaymentGetSalaryPerCourse" + `/${workerSelected}` + `/${courseSelected}` + `/${dateSelected}`)

    const [totalFixedSalary, setTotalFixedSalary] = useState(0);
    const [totalPercentageSalary, setTotalPercentageSalary] = useState(0);
    const [totalSalary, setTotalSalary] = useState(0);


    const getWorkers = async () => 
        await axios.get('https://localhost:5001/api/Workers')
            .then(resp=>{ 
                setWorkers(resp.data);
            });

    const getCourses = async () =>
        await axios.get('https://localhost:5001/api/Courses')
            .then(resp=>{
                setCourses(resp.data);
            });

    const getSalary = async () =>
        await axios.get('https://localhost:5001/api/DoWorkersPayment' + `/${workerSelected}`+ `/${dateSelected}`)
            .then(resp=>{
                setTotalSalary(resp.data['total']);
                setTotalFixedSalary(resp.data['totalFixSalary']);
                setTotalPercentageSalary(resp.data['totalCoursesPorcentualPayment']);
            }); 

    const makePayment = async () =>
        await axios.post('https://localhost:5001/api/DoWorkersPayment' + `/${workerSelected}`+ `/${dateSelected}`);

    useEffect(()=>{
            getWorkers();
            getCourses();
            getSalary();
        },[]);


    console.log(urlFixSalaryTable);
    console.log(urlSalaryPerCourseTable);

    return (
        <div>
            <NavBar />

            <div style={{marginBottom: "10px"}}>
                <Dropdown
                    title={"Trabajador"}
                    options={workers}
                    onChange={worker => {
                        setWorkerSelected(worker); 
                        setUrlFixSalaryTable("https://localhost:5001/api/WorkerPaymentGetFixSalary" + `/${worker}` + `/${dateSelected}`);
                        setUrlSalaryPerCourseTable("https://localhost:5001/api/WorkerPaymentGetSalaryPerCourse" + `/${worker}` + `/${courseSelected}` + `/${dateSelected}`);
                        getSalary();
                    }}
                    print={(teacher) => (teacher.name + ' ' + teacher.lastName)}
                />
                
                <Dropdown
                    title={"Curso"}
                    options={courses}
                    onChange={course => {
                        setCourseSelected(course);
                        setUrlSalaryPerCourseTable("https://localhost:5001/api/WorkerPaymentGetSalaryPerCourse" + `/${workerSelected}` + `/${course}` + `/${dateSelected}`);
                        getSalary();
                    }}
                    print={(course) => (course.name)}
                />

                <DatePicker placeholder={"Seleccione la fecha"}
                    disabledDate={disabledDate}
                    defaultValue={moment()}
                    format={"YYYY.MM.DD"}
                    onChange={date => {
                        setDateSelected(date.format("YYYY-MM-DD"));
                        setUrlFixSalaryTable("https://localhost:5001/api/WorkerPaymentGetFixSalary" + `/${workerSelected}` + `/${dateSelected}`);
                        setUrlSalaryPerCourseTable("https://localhost:5001/api/WorkerPaymentGetSalaryPerCourse" + `/${workerSelected}` + `/${courseSelected}` + `/${date.format("YYYY-MM-DD")}`);
                        getSalary();
                    }}
                    style={{
                        float: "right",
                        marginRight: "5%",
                    }}
                />
            </div>

            <Collapse onChange={(key) => console.log(key)} ghost>
                <Panel header={"Salario fijo: $" + `${totalFixedSalary}`} key="1">
                    <CRUD_Table title={""}
                        columns={fixedSalaryPaymentColumns}
                        operations={[]}
                        url={urlFixSalaryTable}
                        tableID={fixedSalaryPaymentColumnsTableID}
                        searchboxID={fixedSalaryPaymentColumnsSearchboxID}
                        thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
                    ></CRUD_Table>
                </Panel>

                <Panel header={"Salario porcentual: $" + `${totalPercentageSalary}`} key="2">

                    <CRUD_Table title={""}
                        columns={percentageSalaryPaymentColumns}
                        operations={[]}
                        url={urlSalaryPerCourseTable}
                        tableID={percentageSalaryPaymentColumnsTableID}
                        searchboxID={percentageSalaryPaymentColumnsSearchboxID}
                        thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
                    ></CRUD_Table>
                </Panel>
            </Collapse>
            <div className={"checkout"}>
            <p className={"total"}><strong>Total: $ {totalSalary} </strong></p>
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
                onOk={() => {
                    setIsConfirmationModalVisible(false);
                    makePayment();
                }}
            >
            <p>
                ¿Está seguro de que quiere registar el pago de salario en la fecha {dateSelected} al trabajador

                con un importe de $ {totalSalary} ?
            </p>
            </Modal>
        </div>
    );
};

export default SalaryPayment;