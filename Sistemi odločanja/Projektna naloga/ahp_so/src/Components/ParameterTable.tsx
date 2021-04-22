import React, { FunctionComponent } from "react";
import { Cell } from "./Cell";

interface Props {
    rows: Array<string>;
    columns: Array<string>;
    tableName?: string;
}

const drawColumns = (columns: Array<string>, tableName?: string) => {
    return [
        <Cell value={tableName} />,
        columns.map((cell: string) => <Cell value={cell} />),
        columns.map((cell: string) => (
            <Cell value={cell} className="bg-green-400 red" />
        )),
    ];
};
const drawRows = (rows: Array<string>, columns: Array<string>) => {
    return rows.map((cell: string) => (
        <div className="flex w-full min-w-max">
            <Cell value={cell} />
            {columns.map((innerCell: string) => (
                <>
                    <Cell />
                    <Cell />
                </>
            ))}
        </div>
    ));
};

// function* draw(x: number) {
//     for (let i = 0; i < x; i++) {
//         yield <Cell />;
//     }
// }

export const ParameterTable: FunctionComponent<Props> = ({
    rows,
    columns,
    tableName,
}) => {
    return (
        <div className="w-4/5 border border-black mb-5 overflow-scroll">
            <div id="columns" className="flex min-w-max">
                {drawColumns(columns)}
            </div>
            <div className="rows flex flex-col w-full ">
                {drawRows(rows, columns)}
            </div>
        </div>
    );
};
