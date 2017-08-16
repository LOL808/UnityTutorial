using Actions;

public partial class Node
{
    public string Key { get; private set; }

    public AIAction upperAction;

    public float cost = 0f;
    public Node parent;

    public Node()
    {
    }

    public Node(string key)
    {
        Key = key;
    }

    public Node(float _cost, Node _parent, AIAction _upperAction)
    {
        cost = _cost;
        parent = _parent;
        upperAction = _upperAction;
    }

    public Node(string _key, float _cost, Node _parent, AIAction _upperAction)
    {
        Key = _key;
        cost = _cost;
        parent = _parent;
        upperAction = _upperAction;
    }

    public override string ToString()
    {
        return string.Format("Key = {0}",
            Key);
    }
}