
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
                            <DeleteTwoTone/>
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
                    
        for (let i = 0; i < props.headers.length; i++) {
            output.push({
                title: props.headers[i]['title'],
                dataIndex: props.headers[i]['title'],
                width: props.headers[i]['width'],
                editable: props.headers[i]['editable'],
                sorter: {
                    compare: props.headers[i]['dataType'] == 'text' ? 
                    (a, b) => a[props.headers[i]['title']].localeCompare(b[props.headers[i]['title']]) :
                    (a, b) => a[props.headers[i]['title']] - b[props.headers[i]['title']]
                },
                dataType: props.headers[i]['dataType']
            });
        }
        
        output.push(operations[0]);
        output.push(operations[1]);
        
        console.log(output);

        return output;

        // return [
        //     {
        //         title: 'name',
        //         dataIndex: 'name',
        //         width: '15%',
        //         editable: true,
        //         sorter: {
        //             compare: (a, b) => a.name.localeCompare(b.name),
        //         },
        //     },
        //     {
        //         title: 'age',
        //         dataIndex: 'age',
        //         width: '15%',
        //         editable: true,
        //         sorter: (a, b) => a.age - b.age,
        //         // ellipsis: true,
        //     },
        //     {
        //         title: 'address',
        //         dataIndex: 'address',
        //         width: '15%',
        //         editable: true,
        //         sorter: {
        //             compare: (a, b) => a.address.localeCompare(b.address),
        //         },
        //     },
        //     {
        //         title: 'operation',
        //         dataIndex: 'operation',
        //         width: '10%',
        //         render: (_, record) =>
        //             data.length >= 1 ? (
        //                 <Popconfirm title="¿Está seguro de que quiere eliminar esta fila?" cancelText={"Cancelar"}
        //                             okText={"Aceptar"} onConfirm={() => Delete(record.key)}
        //                             icon={<ExclamationCircleTwoTone twoToneColor="#eb2f96"/>}>
        //                     <DeleteTwoTone/>
        //                 </Popconfirm>
        //             ) : null,
        //     },
        //     {
        //         title: 'operation',
        //         dataIndex: 'operation',
        //         width: '10%',
        //         render: (_, record) => {
        //             const editable = isEditing(record);
        //             return editable ? (
        //                 <span>
        //         <Typography.Link
        //             onClick={() => save(record.key)}
        //             style={{
        //                 marginRight: 8,
        //             }}
        //         >
        //           <SaveTwoTone />
        //         </Typography.Link>
        //         <Popconfirm title="¿Está seguro que quiere cancelar?" onConfirm={cancel}>
        //           <a><CloseSquareTwoTone /></a>
        //         </Popconfirm>
        //       </span>
        //             ) : (
        //                 <Typography.Link disabled={editingKey !== ''} onClick={() => edit(record)}>
        //                     <EditTwoTone />
        //                 </Typography.Link>
        //             );
        //         },
        //     }];
    });
    

    const isEditing = (record) => record.id === editingId;

    const edit = (record) => {
        form.setFieldsValue({
            name: '',
            age: '',
            address: '',
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
