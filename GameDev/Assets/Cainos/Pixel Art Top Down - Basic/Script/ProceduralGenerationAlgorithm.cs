using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithm
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength) {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        var previousPosition = startPosition;

        //Walk length is how much it is going to walk and create a procedural generation

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardianlDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }

}

//class used to get a random direction
public static class Direction2D
{
    public static List<Vector2Int> cardianlDirectionsList = new List<Vector2Int> 
    {
        new Vector2Int(0,1), //UP
        new Vector2Int(1,0), //RIGHT
        new Vector2Int(0,-1), //DOWN
        new Vector2Int(-1,0), //LEFT
    };

    public static Vector2Int GetRandomCardianlDirection()
    {
        return cardianlDirectionsList[Random.Range(0, cardianlDirectionsList.Count)];
    }
}
