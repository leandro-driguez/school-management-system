import React from 'react';
import './App.css';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Home from './pages/Home';
import Students from './pages/Students';
import StudentDetails from './pages/StudentDetails';
import Workers from './pages/Workers';
import WorkerDetails from './pages/WorkerDetails';
import Courses from './pages/Courses';
import CourseDetails from './pages/CourseDetails';
import Schedules from './pages/Schedules';
import Income from './pages/Income';
import CoursesPayment from './pages/CoursesPayment';
import SalaryPayment from './pages/SalaryPayment';
import Expenses from './pages/Expenses';
import Debtors from './pages/Debtors'
import Users from './pages/Users';
import BasicMean from './pages/BasicMean';
import Positions from './pages/Positions';
import Classrooms from './pages/Classrooms';
import Login from  './pages/Login';

function App() {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<Login/>}/>
                <Route path='/Home' element={<Home/>}/>
                <Route path='/Students' element={<Students/>}/>
                <Route path='/Students/StudentDetails' element={<StudentDetails/>}/>
                <Route path='/Workers' element={<Workers/>}/>
                <Route path='/Workers/WorkerDetails' element={<WorkerDetails/>}/>
                <Route path='/Courses' element={<Courses />}/>
                <Route path='/CoursesInformation/CourseDetails' element={<CourseDetails/>}/>
                <Route path='/Schedules' element={<Schedules/>}/>
                <Route path='/Income' element={<Income/>}/>
                <Route path='/CoursesPayment' element={<CoursesPayment/>}/>
                <Route path='/SalaryPayment' element={<SalaryPayment/>}/>
                <Route path='/Expenses' element={<Expenses/>}/>
                <Route path='/Debtors' element={<Debtors/>}/>
                <Route path='/Users' element={<Users/>}/>
                <Route path='/Positions' element={<Positions/>}/>
                <Route path='/BasicMean' element={<BasicMean />}/>
                <Route path='/Classrooms' element={<Classrooms/>}/>
            </Routes>
        </Router>
    );
}
// á, é, í, ó, ú
export default App;