
import './Dropdown.css';
import { Select } from 'antd';
import React from 'react';

const { Option } = Select;


const Dropdown_Schedule = (props) => {
    return (
        <Select
            style={{
                width: "200px"
            }}
            showSearch
            placeholder={props.title}
            optionFilterProp="children"
            onChange={props.onChange}
            filterOption={(input, option) => option.children.toLowerCase().includes(input.toLowerCase())}
        >
            {props.options.map((option) => <Option key={option.key}>{option.name}</Option>)}
        </Select>
    );
};

export default Dropdown_Schedule;

