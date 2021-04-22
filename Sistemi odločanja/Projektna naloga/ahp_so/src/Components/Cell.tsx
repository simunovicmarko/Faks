import { classnames } from "@material-ui/data-grid";
import React, { FunctionComponent, useState } from "react";

interface Props {
    value?: any;
    className?:string;
}



export const Cell: FunctionComponent<Props> = ({ value, className }) => {
    const [cellValue, setCellValue] = useState<any | undefined>(value);

    // console.log("border border-black p-2 w-full flex justify-center overflow-hidden cell" + className);
    return (
        <div className={"border border-black p-2 w-full flex justify-center cell " + className} >
            {cellValue ? cellValue : undefined}
        </div>
    );
};
