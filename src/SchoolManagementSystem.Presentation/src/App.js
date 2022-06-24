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

function App() {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<Home/>}/>
                <Route path='/Students' element={<Students/>}/>
                <Route path='/Students/StudentDetails' element={<StudentDetails/>}/>
                <Route path='/Workers' element={<Workers/>}/>
                <Route path='/Workers/WorkerDetails' element={<WorkerDetails/>}/>
                <Route path='/CoursesInformation' element={<CoursesInformation/>}/>
                <Route path='/CoursesInformation/CourseDetails' element={<CourseDetails/>}/>
                <Route path='/Schedules' element={<Schedules/>}/>
                <Route path='/Income' element={<Income/>}/>
                <Route path='/CoursesPayment' element={<CoursesPayment/>}/>
                <Route path='/SalaryPayment' element={<SalaryPayment/>}/>
                <Route path='/Expenses' element={<Expenses/>}/>
                <Route path='/Debtors' element={<Debtors/>}/>
                <Route path='/Users' element={<Users/>}/>
                <Route path='/Positions' element={<Positions/>}/>
                <Route path='/BasicMeans' element={<BasicMeans />}/>
                <Route path='/Classrooms' element={<Classrooms/>}/>
            </Routes>
        </Router>
    );
}

export default App;