import {Button, Modal, Form, InputNumber, Input, Popconfirm, Table, Typography} from 'antd';
import {DeleteTwoTone, EditTwoTone, SaveTwoTone, CloseSquareTwoTone, ExclamationCircleTwoTone } from "@ant-design/icons";
import {useContext, useEffect, useRef, createContext, useState} from 'react';
import "./CRUD_Table.css";
import axios from 'axios';
import { render } from 'react-dom';

const EditableContext = createContext(null);


const EditableCell = ({
                          editing,
                          dataIndex,
                          title,
                          inputType,
                          record,
                          index,
                          children,
                          ...restProps
                      }) => {
    const inputNode = inputType === 'number' ? <InputNumber/> : <Input/>;
    return (
        <td {...restProps}>
            {editing ? (
                <Form.Item
                    name={dataIndex}
                    style={{
                        margin: 0,
                    }}
                    rules={[
                        {
                            required: true,
                            message: `Please Input ${title}!`,
                        },
                    ]}
                >
                    {inputNode}
                </Form.Item>
            ) : (
                children
            )}
        </td>
    );
};

const CRUD_Table = (props) => {
    const [form] = Form.useForm();
    const [data, setData] = useState([]);
    const [editingKey, setEditingKey] = useState('');

    const columns = [];

    const temp = props.columns;
    for (let i = 0; i < temp.length; i++) {
        columns.push(temp[i]);
    }

    columns.push(
        {
            title: 'operation',
            dataIndex: 'operation',
            width: "1%",
            render: (_, record) =>
                data.length >= 1 ? (
                    <Popconfirm title="¿Está seguro de que quiere eliminar esta fila?" cancelText={"Cancelar"}
                                okText={"Aceptar"} onConfirm={() => Delete(record.key)}
                                icon={<ExclamationCircleTwoTone twoToneColor="#eb2f96"/>}>
                        <DeleteTwoTone/>
                    </Popconfirm>
                ) : null,
        },
        {
            title: 'operation',
            dataIndex: 'operation',
            width: "1%",
            render: (_, record) => {
                const editable = isEditing(record);
                return editable ? (
                    <span>
            <Typography.Link
                onClick={() => save(record.key)}
                style={{
                    marginRight: 8,
                }}
            >
              <SaveTwoTone />
            </Typography.Link>
            <Popconfirm title="¿Está seguro que quiere cancelar?" onConfirm={cancel}>
              <a><CloseSquareTwoTone /></a>
            </Popconfirm>
          </span>
                ) : (
                    <Typography.Link disabled={editingKey !== ''} onClick={() => edit(record)}>
                        <EditTwoTone />
                    </Typography.Link>
                );
            },
        },
    );
    
    const [isEditingModalVisible, setIsEditingModalVisible] = useState(false);

    const newData = [];

    const add = () => {
        const newDat = {
            key: data.length,
            name: newData[0],
            capacity: newData[1],
        };
        setData([...data, newDat]);
    };

    const isEditing = (record) => record.key === editingKey;

    const edit = (record) => {
        form.setFieldsValue({
            name: '',
            capacity: '',
            ...record,
        });
        setEditingKey(record.key);
    };

    const cancel = () => {
        setEditingKey('');
    };

    const save = async (key) => {
        try {
            const row = await form.validateFields();
            const newData = [...data];
            const index = newData.findIndex((item) => key === item.key);
            
            if (index > -1) {
                const item = newData[index];
                newData.splice(index, 1, {...item, ...row});
                setData(newData);
                setEditingKey('');
            } else {
                newData.push(row);
                setData(newData);
                setEditingKey('');
            }
            axios.put(props.url, newData[index]);

        } catch (errInfo) {
            console.log('Validate Failed:', errInfo);
        }
    };


    const Delete = (key) => {
        if (editingKey === key){
            setEditingKey('');
        }

        const index = data.findIndex((item) => key === item.key);

        axios.delete(props.url + `/${data[index].key}`);
        
        const newData = data.filter((item) => item.key !== key);

        setData(newData);
    };

    const mergedColumns = columns.map((col) => {
        if (!col.editable) {
            return col;
        }

        return {
            ...col,
            onCell: (record) => ({
                record,
                //inputType: col.dataIndex === 'capacity' ? 'number' : 'text',
                dataIndex: col.dataIndex,
                title: col.title,
                editing: isEditing(record),
            }),
        };
    });


    useEffect(()=>{
        axios.get(props.url)
            .then(resp=>{ 
                setData(resp.data);
            });
    },[]);


    return (
        <div>
            <div className={"container"}>
                <div className="box_title">
                    <p><strong>Aulas</strong></p>
                </div>

                <div className="box">
                    <i className="fa fa-search" aria-hidden="true"></i>
                    <input
                        type="search"
                        id="myInput"
                        placeholder="Buscar"
                    />
                </div>

                <div className="box">
                    <a className="table_options">
                        <i className="fa fa-plus-square-o"
                           aria-hidden="true"
                           onClick={() => setIsEditingModalVisible(true)}>
                    </i>
                    </a>
                </div>

                <div className="box">
                    <p><strong>Total:</strong> {data.length}</p>
                </div>
            </div>

        <Form form={form} component={false}>
            <Table
                components={{
                    body: {
                        cell: EditableCell,
                    },
                }}
                bordered
                dataSource={data}
                columns={mergedColumns}
                rowClassName="editable-row"
                pagination={{
                    position: ["bottomCenter"],
                    pageSizeOptions: ["5", "10", "20", "50", "100"],
                    showQuickJumper: true,
                    onChange: cancel,
                }}
            />
        </Form>

        <Modal className={"editModal"}
                   title={"Añadir nueva aula"}
                   visible={isEditingModalVisible}
                   centered={true}
                   onCancel={() => setIsEditingModalVisible(false)}
                   footer={null}
                   >
                <Form name="hey" autoComplete={"off"}>
                    <Form.Item
                        label={"Nombre"}
                        name={"name"}
                        rules={[
                            {
                                required: true,
                                message: "Introduzca nombre",
                            },
                            {
                                whitespace: true,
                                message: "Introduzca nombre"
                            }
                        ]}
                        hasFeedback={true}
                    >
                        <Input onChange={(e) => {
                            newData[0] = e.target.value;
                        }}>
                        </Input>
                    </Form.Item>

                    <Form.Item
                        label={"Capacidad"}
                        name={"capacity"}
                        rules={[
                            {
                                required: true,
                                message: "Introduzca capacidad",
                            },
                            {
                                whitespace: true,
                                message: "Introduzca capacidad"
                            }
                        ]}
                        hasFeedback={true}
                    >
                        <Input onChange={(e) => {
                            newData[1] = e.target.value;
                            console.log(newData)
                        }}>
                        </Input>
                    </Form.Item>
                    <Button type="primary" htmlType="submit" onClick={() => {add(); setIsEditingModalVisible(false);}}>Guardar</Button>
                    <Button onClick={() => {setIsEditingModalVisible(false);}}>Cancelar</Button>
                </Form>
            </Modal>
            
        </div>
    );
};

export default CRUD_Table;
