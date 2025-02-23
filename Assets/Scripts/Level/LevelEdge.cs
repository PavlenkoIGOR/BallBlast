using UnityEngine;

public enum EdgeType
{
    Bottom,
    Left,
    Right
}

public class LevelEdge : MonoBehaviour
{
    [SerializeField] private EdgeType edgeType;

    public EdgeType EdgeType => edgeType;


}
