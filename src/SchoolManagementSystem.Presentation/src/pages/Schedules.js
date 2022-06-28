import 'react-app-polyfill/ie11';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import {add, format} from 'date-fns';
import NavBar from "../components/NavBar/NavBar";
import {WeeklyCalendar,} from 'antd-weekly-calendar';
import {Button, Card, DatePicker, Form, Input, Modal, Popconfirm, Space, Typography} from 'antd';
import {useState} from "react";
import moment from "moment";
import * as PropTypes from "prop-types";
import {CloseSquareTwoTone, DeleteTwoTone, ExclamationCircleTwoTone, SaveTwoTone} from "@ant-design/icons";
import FormItem from "antd/es/form/FormItem";
import axios from "axios";

//Date Range Picker
const {RangePicker} = DatePicker;

RangePicker.propTypes = {
    onChange: PropTypes.func,
    showTime: PropTypes.shape({format: PropTypes.string}),
    format: PropTypes.string,
    onOk: PropTypes.any
};

var date = new Date("2016-01-04 23:34");

var formattedDate = format(date, "yyyy-MM-dd HH:mm");

console.log(formattedDate);

const Schedules = () => {
    //Modals visibility
    const [isEventModalVisible, setIsEventModalVisible] = useState(false);
    const [isAddModalVisible, setIsAddModalVisible] = useState(false);

    //initial events
    const events = [
        {
            eventId: '1',
            description: "Profesor: Rodrigo Segura",
            startTime: new Date("2022-06-27 10:34"),
            endTime: new Date("2022-06-27 18:34"),
            title: 'Francés',
        },
        {
            eventId: '2',
            description: "Profesor: Marta Suárez",
            startTime: new Date("2022-06-28 18:34"),
            endTime: new Date("2022-06-28 20:30"),
            title: 'Álgebra Lineal I',
            backgroundColor: 'green',
        }
    ];

    //initial data
    const [data, setData] = useState(events);

    //current event
    const [currentEvent, setCurrentEvent] = useState(events[0]);

    //Operations
    //create
    const createEvent = () => {
        setIsAddModalVisible(true);
    };

    //read
    const EventDetails = () => {
        setIsEventModalVisible(true);
    };

    //update
    const updateEvent = () => {

    };

    //delete
    const deleteEvent = () => {
        const newData = data.filter((item) => item.eventId !== currentEvent.eventId);
        setData(newData);
        setIsEventModalVisible(false);
    };

    return (
        <div>
            <NavBar></NavBar>

            <Card>
                <Button onClick={createEvent}
                        style={{
                            marginTop: "10px",
                            marginLeft: "80%",
                            marginBottom: "10px"
                        }}>
                    Añadir turno
                </Button>
                <WeeklyCalendar
                    events={data}
                    weekends={true}
                    onEventClick={event => {
                        setCurrentEvent(event);
                        EventDetails();
                        console.log('current', currentEvent)
                    }}
                />{' '}
            </Card>

            <Modal
                title={"Añadir turno"}
                visible={isAddModalVisible}
                centered={true}
                onCancel={() => setIsAddModalVisible(false)}
                footer={null}
            >
                <Form name="scheduleForm" autoComplete={"off"}
                      labelCol={{
                          span: 4,
                      }}
                      wrapperCol={{
                          span: 14,
                      }}>

                    <FormItem name={"Título"} label={"Título"}
                              rules={[
                                  {
                                      required: true,
                                      message: "Introduzca el título"
                                  }
                              ]}
                              hasFeedback={true}>

                        <Input
                            placeholder={"Título"}>
                        </Input>
                    </FormItem>

                    <FormItem name={"Descripción"} label={"Descripción"}><Input.TextArea
                        placeholder={"Descripción"}></Input.TextArea></FormItem>

                    <FormItem name={"Horario"} label={"Horario"}>
                        <Space direction="vertical" size={10}>
                            <RangePicker
                                style={{marginBottom: "13px"}}
                                visible={false}
                                showTime={{
                                    format: 'HH:mm',
                                }}
                                format="YYYY-MM-DD HH:mm"
                                //onChange={onChange}
                                //onOk={onOk}
                            />
                        </Space>
                    </FormItem>
                </Form>
                <div style={{marginLeft: "17%"}}>
                    <Button type="primary"
                            onClick={() => setIsAddModalVisible(false)}
                            htmlType="submit"
                            style={{marginRight: "5px"}}
                    >Guardar</Button>
                    <Button onClick={() => {
                        setIsAddModalVisible(false);
                    }}>Cancelar</Button>
                </div>
            </Modal>

            <Modal
                title={currentEvent.title}
                visible={isEventModalVisible}
                centered={true}
                cancelText={"Cancelar"}
                onCancel={() => setIsEventModalVisible(false)}
                okText={"Aceptar"}
                onOk={() => setIsEventModalVisible(false)}
            >
                <Popconfirm title="¿Está seguro de que quiere eliminar este evento?" cancelText={"Cancelar"}
                            okText={"Aceptar"} onConfirm={() => deleteEvent()}
                            icon={<ExclamationCircleTwoTone twoToneColor="#eb2f96"/>}>
                    <DeleteTwoTone/>
                </Popconfirm>

                <Form>
                    <FormItem>
                    <Input.TextArea
                        defaultValue={currentEvent.description}>
                    </Input.TextArea>
                </FormItem>
                    <FormItem>
                    <Space direction="vertical" size={10}>
                        <RangePicker
                            style={{marginBottom: "13px"}}
                            visible={false}
                            showTime={{
                                format: 'HH:mm',
                            }}
                            format="YYYY-MM-DD HH:mm"
                            defaultValue={[
                                moment(currentEvent.startTime.toString()),
                                moment(currentEvent.endTime.toString())]}
                            //onChange={onChange}
                            //onOk={onOk}
                        />
                    </Space>
                    </FormItem>
                </Form>
            </Modal>
        </div>
    );
};

export default Schedules;