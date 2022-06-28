
import './Dropdown.css';
import { Select } from 'antd';
import React from 'react';

const { Option } = Select;


const Dropdown_NameOnly = (props) => {
    return (
        <Select
            style={{
                marginLeft: "6%",
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

export default Dropdown_NameOnly;

