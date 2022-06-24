import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CollapsePanels from "../components/CollapsePanels/CollapsePanels";

import {Collapse, Table} from "antd";

const CoursesPayment = () => {
    const components = () => {
        return (
            <div>
        <Table title={"JNDFKJSN"}></Table>
        <Table title={"JNDFKJSN"}></Table>
        <Table title={"JNDFKJSN"}></Table>
            </div>
    );
    };

    return (
        <div>
            <NavBar></NavBar>

            <Collapse ghost>
                <CollapsePanels titles={["a", "b", "c"]} components={components()}></CollapsePanels>
            </Collapse>
        </div>
    );
};

export default CoursesPayment;