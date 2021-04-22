import React, { FunctionComponent } from "react";
import { NodeObject } from "../Classes/NodeObject";
import { Tree } from "./Tree";
// import { ValueTable } from "./ValueTable";
import { GetRowsFromTree } from "../Functions/GetRowFromTree";
// import { Tabels } from "./Tabels";
import { ParameterTable } from "./ParameterTable";

interface Props {}

export const Main: FunctionComponent<Props> = () => {
    let node = new NodeObject("neki");
    node.Children = [
        new NodeObject("neki4", [
            new NodeObject("Temp"),
            new NodeObject("Temp2"),
        ]),
        new NodeObject("neki2", [
            new NodeObject("Temp4"),
            new NodeObject("Temp5"),
            new NodeObject("Temp6"),
            new NodeObject("Temp8"),
        ]),
        new NodeObject("neki3"),
    ];

    let rows = GetRowsFromTree(node);

    return (
        <div className="Main flex flex-col items-center">
            <Tree node={node}></Tree>
            <ParameterTable rows={rows} columns={rows}/>
        </div>
    );
};
