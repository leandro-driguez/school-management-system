import React, {Component} from "react";
import './Menu.css';
import Personal from "../Menu/images/Personal.jpg";
import Offers from "../Menu/images/Offers.jpg";
import Finances from "../Menu/images/Finances.jpg";
import Administration from "../Menu/images/Administration.jpg";

export default class Menu extends Component {
    render() {
        return (
            <div className="container">
                <div className="dropdown" align="left">
                    <button>
                        <img src={Personal} alt="Personal"/>
                    </button>

                    <div className="dropdown-content">
                        <a href="../Students">Estudiantes</a>
                        <a href="../Workers">Trabajadores</a>
                    </div>
                </div>

                <div className="dropdown" align="left">
                    <button>
                        <img src={Offers} alt="Ofertas"/>
                    </button>

                    <div className="dropdown-content">
                        <button data-toggle="dropdown">Cursos</button>
                        <div
                          className="dropdown-sec">
                            <a href="../CoursesInformation">Información</a>
                            <a href="../Schedules">Horarios</a>
                        </div>
                    </div>
                </div>

                <div className="dropdown" align="left">
                    <button>
                        <img src={Finances} alt="Finanzas"/>
                    </button>

                    <div className="dropdown-content">
                        <button>
                            <a href="../Income">Ingresos</a>
                        </button>
                        <div className="dropdown-sec">
                            <a href="../CoursesPayment">Efectuar Cobro de Cursos</a>
                        </div>
                        <a href="../SalaryPayment">Efectuar Pago de Salarios</a>
                        <a href="../Expenses">Gastos</a>
                        <a href="../Debtors">Deudores</a>
                    </div>
                </div>

                <div className="dropdown" align="left">
                    <button>
                        <img src={Administration} alt="Administración"/>
                    </button>

                    <div className="dropdown-content">
                        <a href="../Users">Usuarios</a>
                        <a href="../Positions">Cargos</a>
                        <a href="../BasicMean">Medios Básicos</a>
                        <a href="../Classrooms">Aulas</a>
                    </div>
                </div>
            </div>
        );
    }
}