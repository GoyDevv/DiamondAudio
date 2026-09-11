using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityGLTF;

public static class GrannyExport
{
    public static void ExportScene()
    {
        const string scenePath = "Assets/Scene/1_Scenes/Scene.unity";
        const string outputDir = "Export";

        Directory.CreateDirectory(outputDir);
        var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
        var roots = scene.GetRootGameObjects();
        var transforms = new Transform[roots.Length];
        for (var i = 0; i < roots.Length; i++) transforms[i] = roots[i].transform;

        GLTFSceneExporter.ExportNames = true;
        GLTFSceneExporter.ExportFullPath = false;
        GLTFSceneExporter.ExportPhysicsColliders = false;

        var options = new ExportOptions
        {
            ExportInactivePrimitives = true,
            TexturePathRetriever = texture => texture != null ? texture.name : "texture"
        };

        var exporter = new GLTFSceneExporter(transforms, options);
        exporter.SaveGLB(outputDir, "granny_map");

        AssetDatabase.Refresh();
        Debug.Log("GRANNY_EXPORT_DONE: " + Path.GetFullPath(Path.Combine(outputDir, "granny_map.glb")));
        EditorApplication.Exit(0);
    }
}
