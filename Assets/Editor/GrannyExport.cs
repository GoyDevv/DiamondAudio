using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        var settings = new GLTFSettings();
        settings.ExportNames = true;
        settings.ExportDisabledGameObjects = true;
        settings.ExportAnimations = false;
        settings.ExportVertexColors = true;
        settings.TryExportTexturesFromDisk = true;
        settings.UseTextureFileTypeHeuristic = true;

        var context = new ExportContext(settings);
        var exporter = new GLTFSceneExporter(transforms, context);
        exporter.SaveGLB(outputDir, "granny_map");

        AssetDatabase.Refresh();
        Debug.Log("GRANNY_EXPORT_DONE: " + Path.GetFullPath(Path.Combine(outputDir, "granny_map.glb")));
        EditorApplication.Exit(0);
    }
}
