import React from "react";
import {Collapse} from "antd";
import CRUD_Table from "../Table/CRUD_Table";
const { Panel } = Collapse;

const CollapsePanels = (props) => {
    const titles = props.titles;
    const components = props.components

    return(<Collapse ghost>
        {titles.map(
            (title) => { return (<Panel header={title} key={title}>
                <CRUD_Table></CRUD_Table>
            </Panel>); }
        )}
    </Collapse>);
};

export default CollapsePanels;