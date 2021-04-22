export interface INodeObject{
    Value:string;
    Children?:Array<NodeObject>;
}

export class NodeObject implements INodeObject{
    constructor(value:string, children?:Array<NodeObject>){
        this.Value = value;
        if (children) {
            this.Children = children;
        }
    }
    

    public Value:string;
    public Children?:Array<NodeObject>;
}