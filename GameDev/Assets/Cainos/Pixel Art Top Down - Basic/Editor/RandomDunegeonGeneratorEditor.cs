using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Creates a custom editor in the Unity engine to create maps without running the program
[CustomEditor(typeof(AbstractDungeonGenerator), true)]
public class RandomDunegeonGeneratorEditor : Editor
{
    AbstractDungeonGenerator generator;

    private void Awake()
    {
        generator = (AbstractDungeonGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //if the button named "Create Dungeon is pressed then the dungeon will generate"
        if (GUILayout.Button("Create Dungeon"))
        {
            generator.GenerateDungeon();
        }
    }
}
