import React from 'react';
import './App.css';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Home from './pages/Home';
import Students from './pages/Students';
import StudentDetails from './pages/StudentDetails';
import Workers from './pages/Workers';
import WorkerDetails from './pages/WorkerDetails';
import CoursesInformation from './pages/CoursesInformation';
import CourseDetails from './pages/CourseDetails';
import Schedules from './pages/Schedules';
import Income from './pages/Income';
import CoursesPayment from './pages/CoursesPayment';
import SalaryPayment from './pages/SalaryPayment';
import Expenses from './pages/Expenses';
import Debtors from './pages/Debtors'
import Users from './pages/Users';
import BasicMeans from './pages/BasicMeans';
import Positions from './pages/Positions';
import Classrooms from './pages/Classrooms';
import Login from  './pages/Login';

function App() {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<Login/>}/>
                <Route path='/Home' element={<Home/>}/>
                <Route path='/Home/Students' element={<Students/>}/>
                <Route path='/Home/Students/StudentDetails' element={<StudentDetails/>}/>
                <Route path='/Home/Workers' element={<Workers/>}/>
                <Route path='/Home/Workers/WorkerDetails' element={<WorkerDetails/>}/>
                <Route path='/Home/CoursesInformation' element={<CoursesInformation/>}/>
                <Route path='/Home/CoursesInformation/CourseDetails' element={<CourseDetails/>}/>
                <Route path='/Home/Schedules' element={<Schedules/>}/>
                <Route path='/Home/Income' element={<Income/>}/>
                <Route path='/Home/CoursesPayment' element={<CoursesPayment/>}/>
                <Route path='/Home/SalaryPayment' element={<SalaryPayment/>}/>
                <Route path='/Home/Expenses' element={<Expenses/>}/>
                <Route path='/Home/Debtors' element={<Debtors/>}/>
                <Route path='/Home/Users' element={<Users/>}/>
                <Route path='/Home/Positions' element={<Positions/>}/>
                <Route path='/Home/BasicMeans' element={<BasicMeans />}/>
                <Route path='/Home/Classrooms' element={<Classrooms/>}/>
            </Routes>
        </Router>
    );
}

export default App;