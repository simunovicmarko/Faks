import React, { ChangeEvent, FunctionComponent, useState } from "react";
import { INodeObject, NodeObject } from "../Classes/NodeObject";

interface Props {
    node: NodeObject;
}

export const TreeNode: FunctionComponent<Props> = ({ node }) => {
    const [value, setValue] = useState<string>(node.Value);

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        setValue(e.target.value);
    };

    const drawChildren = (node: NodeObject) => {
        return  node.Children ? (
            <div className="flex">
                {node.Children.map((element: INodeObject) => (
                    <TreeNode node={element} />
                ))}
            </div>
        ) : (
            <></>
        );
    };

    return (
        <div className="flex flex-col items-center w-full">
            <input
                value={value}
                onChange={handleChange}
                className="rounded-full bg-gray-500 p-3 w-20 flex justify-center text-white text-center font-bold text-lg m-5 "
            />
            {drawChildren(node)}
        </div>
    );
};
