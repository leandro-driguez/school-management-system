
import {Button, Modal, Form, InputNumber, Input, Popconfirm, Table, Typography} from 'antd';
import {DeleteTwoTone, EditTwoTone, SaveTwoTone, CloseSquareTwoTone, ExclamationCircleTwoTone } from "@ant-design/icons";
import {useContext, useEffect, useRef, createContext, useState} from 'react';
import axios from 'axios'
import "./CRUD_Table.css";

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
    
    const inputNode = inputType === 'int' ? <InputNumber/> : <Input/>;
    
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

const CRUD_Table = (
        props
    ) => {
    
    const [form] = Form.useForm();
    const [data, setData] = useState([]);
    const [editingId, setEditingId] = useState('');
    const [columns, setColumns] = useState(() =>{

        var operations = [
            {
                title: 'operation',
                dataIndex: 'operation',
                width: '10%',
                render: (_, record) =>
                    data.length >= 1 ? (
                        <Popconfirm title="¿Está seguro de que quiere eliminar esta fila?" cancelText={"Cancelar"}
                                    okText={"Aceptar"} onConfirm={() => Delete(record.id)}
                                    icon={<ExclamationCircleTwoTone twoToneColor="#eb2f96"/>}>
                            <DeleteTwoTone />
                        </Popconfirm>
                    ) : null,
            },
            {
                title: 'operation',
                dataIndex: 'operation',
                width: '10%',
                render: (_, record) => {
                    const editable = isEditing(record);
                    return editable ? (
                        <span>
                            <Typography.Link
                                onClick={() => save(record.id)}
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
                        <Typography.Link disabled={editingId !== ''} onClick={() => edit(record)}>
                            <EditTwoTone />
                        </Typography.Link>
                    );
                },
            }
        ];

        var output = [];

        // columns = props.headers;

        for (let index = 0; index < props.headers.length; index++) {
           output.push(props.headers[index]); 
        }
        
        output.push(operations[0]);
        output.push(operations[1]); 
        
        console.log(output);

        return output;
    });
    

    const isEditing = (record) => record.id === editingId;

    const edit = (record) => {
        form.setFieldsValue({
            name: '',
            capacity: '',
            ...record,
        });
        setEditingId(record.id);
    };

    const cancel = () => {
        setEditingId('');
    };

    const save = async (id) => {
        try {
            const row = await form.validateFields();
            const newData = [...data];
            const index = newData.findIndex((item) => id === item.id);

            if (index > -1) {
                const item = newData[index];
                newData.splice(index, 1, {...item, ...row});
                setData(newData);
                setEditingId('');
            } else {
                newData.push(row);
                setData(newData);
                setEditingId('');
            }
        } catch (errInfo) {
            console.log('Validate Failed:', errInfo);
        }
    };

    const Delete = (id) => {
        const newData = data.filter((item) => item.id !== id);
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
                inputType: col.dataType,
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
    );
};

export default CRUD_Table;
