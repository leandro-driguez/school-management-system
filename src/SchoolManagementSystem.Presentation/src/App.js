// import logo from './logo.svg';
import './App.css';
import React from 'react';
import axios from 'axios';
import {
    Table,
    // Row,
  } from "react-bootstrap";

function App(){
    return(
        <Classrooms />
    );
}

export default App;


class Classrooms extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Rows: []
        };
    }
    
    componentDidMount() {
        axios.get("https://localhost:5001/api/Classrooms")
            .then(resp=>{
                this.setState({
                    Rows: resp.data
                }); 
            });
    }

    render() {
        return(
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Capacity</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.Rows.map(row =>
                        <RowClassroom
                            key={row.id} 
                            name={row.name} 
                            capacity={row.capacity}
                        />)}
                </tbody>
            </Table>
        );
    }
}

class RowClassroom extends React.Component{
    constructor(props){
        super(props);
    }

    render(){
        return (
            <tr
                id={this.props.id}
            >
                <td>{this.props.name}</td>
                <td>{this.props.capacity}</td>
            </tr>
        );
    }
}
