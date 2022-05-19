/*using System.Collections.Generic;
using UnityEngine;

public class Directions: MonoBehaviour
{
    List<Vector2Int> dirs;
    Vector2Int UP = new Vector2Int(0, 1);
    Vector2Int LEFT = new Vector2Int(-1, 0);
    Vector2Int DOWN = new Vector2Int(0, -1);
    Vector2Int RIGHT = new Vector2Int(1, 0);
    Vector2Int LEFT_UP = new Vector2Int(-1, 1);
    Vector2Int RIGHT_UP = new Vector2Int(1, 1);
    Vector2Int LEFT_DOWN = new Vector2Int(-1, -1);
    Vector2Int RIGHT_DOWN = new Vector2Int(1, -1);

    void Start()
    {
        dirs.AddRange(new List<Vector2Int> { UP, DOWN, LEFT, RIGHT, LEFT_UP, RIGHT_UP, LEFT_DOWN, RIGHT_DOWN });
    }

    public List<Vector2Int> getValidDirections(Vector2Int pos, Vector2Int output_size) // Represents the size of the output matrix
    {
        float x = pos.x;
        float y = pos.y;

        List<Vector2Int> validDirections = new List<Vector2Int>();

        if (x == 0)
        {
            validDirections.Add(RIGHT);
            if (y == 0) validDirections.AddRange(new List<Vector2Int>{DOWN, RIGHT_DOWN});
            else if (y == output_size.y - 1) validDirections.AddRange(new List<Vector2Int>{UP, RIGHT_UP});
            else validDirections.AddRange(new List<Vector2Int>{ DOWN, RIGHT_DOWN, UP, RIGHT_UP});
        }
        else if (x == output_size[0] - 1)
        {
            validDirections.Add(LEFT);
            if (y == 0) validDirections.AddRange(new List<Vector2Int> { DOWN, LEFT_DOWN});
            else if (y == output_size.y - 1) validDirections.AddRange(new List<Vector2Int> { UP, LEFT_UP});
            else validDirections.AddRange(new List<Vector2Int> { DOWN, LEFT_DOWN, UP, LEFT_UP});
        }
        else
        {
            validDirections.AddRange(new List<Vector2Int> { LEFT, RIGHT});
            if (y == 0) validDirections.AddRange(new List<Vector2Int> { DOWN, LEFT_DOWN, RIGHT_DOWN});
            else if (y == output_size[1] - 1) validDirections.AddRange(new List<Vector2Int> { UP, LEFT_UP, RIGHT_UP});
            else validDirections.AddRange(new List<Vector2Int> { UP, LEFT_UP, RIGHT_UP, DOWN, LEFT_DOWN, RIGHT_DOWN});
        }
        return validDirections;
    }
}
*/