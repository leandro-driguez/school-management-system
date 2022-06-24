import React from "react";
import logo from "./images/dclase_icon.ico";
import './Login.css';
import {ArrowRightOutlined, LockOutlined, MailOutlined, UserOutlined} from "@ant-design/icons";

const Login = () => {
    return(
        <div className="container">
            <div className="screen">
                <div className="screen__content">
                    <form className="login">
                        <div className="login__field">
                            <UserOutlined />
                            <input
                                type="text"
                                className="login__input"
                                placeholder="Usuario / correo"
                            />
                        </div>
                        <div className="login__field">
                            <LockOutlined />
                            <input
                                type="password"
                                className="login__input"
                                placeholder="Contraseña"
                            />
                        </div>
                        <button className="button login__submit">
                            <span className="button__text">Iniciar sesión</span>
                            <i className="button__icon"> <ArrowRightOutlined /></i>
                        </button>
                    </form>
                    <img className="social-login" src={logo} alt="dclase_icon"/>
                </div>
                <div className="screen__background">
          <span
              className="screen__background__shape screen__background__shape4"
          ></span>
                    <span
                        className="screen__background__shape screen__background__shape3"
                    ></span>
                    <span
                        className="screen__background__shape screen__background__shape2"
                    ></span>
                    <span
                        className="screen__background__shape screen__background__shape1"
                    ></span>
                </div>
            </div>
        </div>
    );
};

export default Login;