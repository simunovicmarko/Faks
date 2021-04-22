import React, { FunctionComponent } from "react";
import { INodeObject } from "../Classes/NodeObject";
import { TreeNode } from "./TreeNode";

interface Props {
    node: INodeObject;
}

export const Tree: FunctionComponent<Props> = ({ node }) => {
    return (
        <div className="flex flex-col items-center w-4/5">
            <div>
                <TreeNode node={node}/>
            </div>
        </div>
    );
};
