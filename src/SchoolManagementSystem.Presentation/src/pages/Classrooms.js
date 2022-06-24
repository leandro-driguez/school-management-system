import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";

const Classrooms = () => {
    const columns = [
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
            title: 'Capacidad',
            dataIndex: 'capacity',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.capacity - b.capacity
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca capacidad",
                }
            ]
        }
    ];

    const tableID = 'ClassroomsTable';
    const searchboxID = 'ClassroomsSearchbox';

    // const originData = [
    //     {key:"bc9f1407-812d-4f34-92f7-05d01076db9d",name:"Aula 1",capacity:30},
    //     {key:"c65b4ed0-8e30-472a-9166-59558f5d014c",name:"Aula 2",capacity:20},
    //     {key:"f73f890b-08cc-4135-be02-b4e59dd4d4af",name:"Aula 3",capacity:16},
    //     {key:"03dcfe00-2f31-4282-a703-a35487e408bb",name:"Aula 4",capacity:25},
    //     {key:"cc6fad04-91a4-412e-bdfb-f78f8c6631e1",name:"Aula 5",capacity:18},
    //     {key:"c2ce1b10-5a9c-46d0-90de-6e871fbeaee9",name:"Aula 6",capacity:22}
    // ];

    // for (let i = 0; i < 100; i++) {
    //     originData.push({
    //         key: i.toString(),
    //         name: `Aula ${i}`,
    //         capacity: 32,
    //     });
    // }

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Title"} 
                columns={columns} 
                // data={originData} 
                operations={["edit","delete"]}
                url={"https://localhost:5001/api/Classrooms"}
                tableID={tableID}
                searchboxID={searchboxID}
            >
            </CRUD_Table>
        </div>
    );
};

export default Classrooms;