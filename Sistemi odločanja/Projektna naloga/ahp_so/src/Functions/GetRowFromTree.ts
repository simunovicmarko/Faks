import { NodeObject } from "../Classes/NodeObject";

export const GetRowsFromTree = (root: NodeObject, Row?: Array<string>, Depth?:number) => {
    // let depth:number|undefined;
    if (!Row) {
        Depth = 1;
        Row = [];
        Row.push(root.Value);
        GetValuesFromChildren(root, Row,Depth);
    } else {
        console.log(Depth)
        Row.push(root.Value);
        if (Depth !== undefined) {
            GetValuesFromChildren(root, Row,Depth);
        }
    }

    return Row;
};
function GetValuesFromChildren(root: NodeObject, Row: string[] | undefined, depth:number) {
    if (root.Children) {
        root.Children.map((element: NodeObject) =>
            GetRowsFromTree(element, Row, depth+1)
        );
    }
}
