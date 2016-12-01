using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

using System;


public class AtlasGenerator : EditorWindow
{
    public bool AlgorithmOne = false;
    public bool AlgorithmTwo = false;
    public bool AlgorithmThree = false;

    public int atlasSize = 6144;

    public Texture2D[] atlasTextures;
    

    public Texture2D genAtlas;

    public static int compareText(Texture2D t1, Texture2D t2)
    {
        if (t1.height > t2.height)
        {
            return -1;
        }
        if (t1.height == t2.height)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    void algorithmOne()
    {
        genAtlas = new Texture2D(atlasSize, atlasSize);
        
        int texWidth = 0;
        int texWidth2 = 0;
        int texWidth3 = 0;
        int texWidth4 = 0;

        int totalHeight = 0;
        int totalHeight2 = 0;
        int testHeight = atlasTextures[0].height;

        for (int i = 0; i < atlasTextures.Length; i++)
        {
            texWidth = texWidth + atlasTextures[i].width;

            if (texWidth <= atlasSize)
            {
                Color[] placePixels = atlasTextures[i].GetPixels();
                genAtlas.SetPixels((texWidth - atlasTextures[i].width), 0, atlasTextures[i].width, atlasTextures[i].height, placePixels, 0); 
            }

            if (texWidth > atlasSize)
            {
                if (totalHeight <= testHeight)
                {
                    totalHeight = testHeight + atlasTextures[i].height;
                }

                texWidth = texWidth - atlasTextures[i].width;
                texWidth2 = texWidth2 + atlasTextures[i].width;

                if (texWidth2 <= atlasSize)
                {

                    Color[] placePixels = atlasTextures[i].GetPixels();
                    genAtlas.SetPixels((texWidth2 - atlasTextures[i].width), atlasTextures[0].height, atlasTextures[i].width, atlasTextures[i].height, placePixels, 0);

                }

                if (texWidth2 > atlasSize)
                {
                    if (totalHeight2 <= totalHeight)
                    {
                        totalHeight2 = totalHeight + atlasTextures[i].height;
                    }

                    texWidth2 = texWidth2 - atlasTextures[i].width;
                    texWidth3 = texWidth3 + atlasTextures[i].width;

                    if (texWidth3 <= atlasSize)
                    {
                        Color[] placePixels = atlasTextures[i].GetPixels();
                        genAtlas.SetPixels((texWidth3 - atlasTextures[i].width), totalHeight, atlasTextures[i].width, atlasTextures[i].height, placePixels, 0);
                    }

                    if (texWidth3 > atlasSize)
                    {
                        texWidth3 = texWidth3 - atlasTextures[i].width;
                        texWidth4 = texWidth4 + atlasTextures[i].width;

                        Color[] placePixels = atlasTextures[i].GetPixels();
                        genAtlas.SetPixels((texWidth4 - atlasTextures[i].width), totalHeight2, atlasTextures[i].width, atlasTextures[i].height, placePixels, 0);
                    }
                }
            }

            else
            {
            }

        }

        genAtlas.Apply();
    }

    void algorithmTwo()
    {
        genAtlas = new Texture2D(atlasSize, atlasSize);

        int texWidth = 0;
        int texWidth2 = 0;
        int texWidth3 = 0;
        int texWidth4 = 0;

        int totalHeight = 0;
        int totalHeight2 = 0;
        int testHeight = atlasTextures[0].height;

        for (int i = 0; i < atlasTextures.Length; i++)
        {
            texWidth = texWidth + atlasTextures[i].width;

            if (texWidth <= atlasSize)
            {
                Color[] placePixels = atlasTextures[i].GetPixels();
                genAtlas.SetPixels((texWidth - atlasTextures[i].width), 0, atlasTextures[i].width, atlasTextures[i].height, placePixels, 0);

            }

            if (texWidth > atlasSize)
            {
                if (totalHeight <= testHeight)
                {
                    totalHeight = testHeight + atlasTextures[i].height;
                }

                texWidth2 = texWidth2 + atlasTextures[i].width;

                if (texWidth2 <= atlasSize)
                {

                    Color[] placePixels = atlasTextures[i].GetPixels();
                    genAtlas.SetPixels((texWidth2 - atlasTextures[i].width), atlasTextures[0].height, atlasTextures[i].width, atlasTextures[i].height, placePixels, 0);

                }

                if (texWidth2 > atlasSize)
                {
                    if (totalHeight2 <= totalHeight)
                    {
                        totalHeight2 = totalHeight + atlasTextures[i].height;
                    }

                    texWidth3 = texWidth3 + atlasTextures[i].width;

                    if (texWidth3 <= atlasSize)
                    {
                        Color[] placePixels = atlasTextures[i].GetPixels();
                        genAtlas.SetPixels((texWidth3 - atlasTextures[i].width), totalHeight, atlasTextures[i].width, atlasTextures[i].height, placePixels, 0);
                    }

                    if (texWidth3 > atlasSize)
                    {
                        texWidth4 = texWidth4 + atlasTextures[i].width;

                        Color[] placePixels = atlasTextures[i].GetPixels();
                        genAtlas.SetPixels((texWidth4 - atlasTextures[i].width), totalHeight2, atlasTextures[i].width, atlasTextures[i].height, placePixels, 0);
                    }
                }
            }

            else
            {
            }

        }

        genAtlas.Apply();
    }

    void algorithmThree()
    {

    }


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
            Debug.Log("Textures added: " + atlasTextures.Length);
            Array.Sort(atlasTextures, compareText);
        }

        if (GUILayout.Button("Generate", buttonStyle))
        {
            //genAtlas.PackTextures(atlasTextures, 0, atlasSize);
            //genAtlas = Texture2D.PackTectures(atlasTextures, 0, 8192);
            Debug.Log("Generated atlas.");
           

            if (AlgorithmOne == true)
            {
                algorithmOne();
            }

            if (AlgorithmTwo == true)
            {
                algorithmTwo();
            }
        }

        if (GUILayout.Button("Save", buttonStyle))
        {
            if (!Directory.Exists(Application.dataPath + "/Atlases"))
            {
                Directory.CreateDirectory(Application.dataPath + "/Atlases");
            }
            byte[] bytes = genAtlas.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/Atlases/TestAtlas.png", bytes);


            Debug.Log("Saved!");
        }

        if (GUILayout.Button("Display Memory Savings", buttonStyle))
        {
            if(genAtlas)
            {
                float g_fileSize = 0;
                var a_fileSize = new System.IO.FileInfo(Application.dataPath + "/Atlases/TestAtlas.png");
                var info = new DirectoryInfo(Application.dataPath + "/Assets/Resources/Textures");
                FileInfo[] fileInfo = info.GetFiles("*.*");
                foreach(FileInfo f in fileInfo)
                {
                    g_fileSize += f.Length;
                }

                float mem_save = a_fileSize.Length / g_fileSize * 100;
                float g_MB_fileSize = (g_fileSize / 1024) / 1024;
                float a_MB_fileSize = (a_fileSize.Length / 1024) / 1024;
                Debug.Log("Textures total file size: " + g_MB_fileSize.ToString("F2") + "MB");
                Debug.Log("Atlas total file size: " + a_MB_fileSize.ToString("F2") + "MB");
                Debug.Log("Memory saved with texture atlas: " + mem_save.ToString("F2") + "%");


            }
        }

        GUILayout.Label(genAtlas, texPreviewStyle);
    }
}
