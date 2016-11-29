using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;


public class AtlasGenerator : EditorWindow
{
    public bool AlgorithmOne = false;
    public bool AlgorithmTwo = false;
    public bool AlgorithmThree = false;

    public Texture2D[] atlasTextures;
    

    public Texture2D genAtlas;


    ////  FILES  //

    //private static string filepath = "Assets/Project/Textures & Images/";
    //private static string filename = "";

    ////  BASE AND RESULT TEXTURES  //

    //private static Texture2D baseTex;
    //private static Texture2D resultTex;

    ////  MASKING  //

    //private static Texture2D maskTex;
    //private static Color maskTint = Color.white;

    ////  SOLID TINTING/BLENDING  //

    //private static Color tint = Color.white;




    //  LAYOUT  //

    private static GUILayoutOption[] buttonStyle =
    {
        GUILayout.Width(256), GUILayout.Height(32)
    };

    private static GUILayoutOption[] texSelectStyle =
    {
        GUILayout.Width(256), GUILayout.Height(32)
    };

    private static GUILayoutOption[] texPreviewStyle =
    {
        GUILayout.Width(256), GUILayout.Height(256)
    };

    private static GUILayoutOption[] blankStyle = { };

    [MenuItem("Window/AtlasGenerator", false, 25)]
    public static void ShowWindow()
    {
        AtlasGenerator window = GetWindow<AtlasGenerator>();
        window.titleContent.text = "Atlas Generator";
        window.minSize = new Vector2(350.0f, 500.0f);
    }

    void OnGUI()
    {
        if (GUILayout.Toggle(AlgorithmOne, "Algorithm 1", texSelectStyle))
        {
            AlgorithmOne = true;
            AlgorithmTwo = false;
            AlgorithmThree = false;
        }

        if (GUILayout.Toggle(AlgorithmTwo, "Algorithm 2", texSelectStyle))
        {
            AlgorithmTwo = true;
            AlgorithmOne = false;
            AlgorithmThree = false;
        }

        if (GUILayout.Toggle(AlgorithmThree, "Algorithm 3", texSelectStyle))
        {
            AlgorithmThree = true;
            AlgorithmOne = false;
            AlgorithmTwo = false;
        }
        
        if (GUILayout.Button("AddTextures", buttonStyle))
        {
            atlasTextures = Resources.LoadAll<Texture2D>("Textures");
            Debug.Log(atlasTextures.Length);
        }

        if (GUILayout.Button("Generate", buttonStyle))
        {
            genAtlas = new Texture2D(1024, 1024);
            genAtlas.PackTextures(atlasTextures, 0, 1024);
            //genAtlas = Texture2D.PackTectures(atlasTextures, 0, 8192);
            Debug.Log("Generated atlas.");
            Debug.Log(genAtlas.width);
        }

        GUILayout.Label(genAtlas, texPreviewStyle);
    }
}
