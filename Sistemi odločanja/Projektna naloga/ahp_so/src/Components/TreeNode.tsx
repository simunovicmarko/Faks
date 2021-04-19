import React, { ChangeEvent, FunctionComponent, useState } from "react";

interface Props {
    value: string;
}

export const TreeNode: FunctionComponent<Props> = ({ value }) => {
    const [values, setValues] = useState<string>(value);

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        setValues(e.target.value);
    };

    return (
        <input
            value={values}
            onChange={handleChange}
            className="rounded-full bg-gray-500 p-3 w-20 flex justify-center text-white text-center font-bold text-lg"
        />
    );
};
