import React, { FunctionComponent } from "react";

interface Props {
    values: Array<string>;
}

export const ValueTable: FunctionComponent<Props> = ({ values }) => {
    return (
        <div className="flex justify-center w-4/5">
            {/* <div className="m-10"> */}
                <div className="flex ml-20">
                    {/* DrawColumn */}
                    {values.map((element: string) => (
                        <div className="p-2 border border-solid border-gray-600  flex justify-center w-auto">
                            {element}
                        </div>
                    ))}
                </div>
                <div>
                    {values.map((element: string) => (
                        <div className="flex">
                            {/* DrawRow*/}
                            <div className="p-2 border border-solid border-gray-600  flex justify-start w-auto">
                                {element}
                            </div>
                            {/* DrawSquersHorizontaly */}
                            {values.map(() => (
                                <input className="p-2 border border-solid border-gray-600 flex justify-start w-auto"></input>
                            ))}
                        </div>
                    ))}
                </div>
            {/* </div> */}
        </div>
    );
};
