using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

//A child class of AbstractDugneonGenerator more specifically the simple random walk algorithm
public class SimpleRandomWalkMapGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    private SimpleRandomWalkData randomWalkParameters;


    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParameters.iterations; i++)   
        {
            var path = ProceduralGenerationAlgorithm.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            //unionWith ensures that when path and floorpositions are combined, there are no duplicates
            floorPositions.UnionWith(path);
            if (randomWalkParameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }

}
