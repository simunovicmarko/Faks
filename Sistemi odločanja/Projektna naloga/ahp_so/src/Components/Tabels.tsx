import React, { FunctionComponent } from "react";
import { Cell } from "./Cell";

interface Props {
    rows: Array<string>;
    columns: Array<string>;
    tableName?: string;
}

const drawRows = (rows: Array<string>, columns: Array<string>) => {
    return rows.map((cell: string) => (
        <div className="flex">
            <Cell value={cell} />
            {columns.map((innerCell: string) => (
                <Cell />
            ))}
        </div>
    ));
};
const drawColumns = (columns: Array<string>, tableName?: string) => {
    return [
        <Cell value={tableName} />,
        columns.map((cell: string) => <Cell value={cell} />),
    ];
};

export const Tabels: FunctionComponent<Props> = ({
    rows,
    columns,
    tableName,
}) => {
    return (
        <div className="w-4/5 border border-black mb-5">
            <div id="columns" className="flex min-w-max">
                {drawColumns(columns)}
            </div>
            <div id="rows flex flex-col">{drawRows(rows, columns)}</div>
        </div>
    );
};
