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
            <caption>
                <p className="table_title"><strong>Aulas</strong></p>

                <div className="box">
                    <i className="fa fa-search" aria-hidden="true"></i>
                    <input
                        type="search"
                        id="myInput"
                        placeholder="Buscar"
                    />
                </div>

                <div className="box">
                    <a className="table_options"><i className="fa fa-plus-square-o" aria-hidden="true">
                    </i></a>
                </div>

                <div className="box">
                    <p><strong>Total:</strong> {data.length}</p>
                </div>
            </caption>

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
        </div>
    );
};

export default CRUD_Table;
