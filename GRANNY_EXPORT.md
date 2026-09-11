# Granny map export pipeline

This branch does not vendor the upstream binary source archive into Git. The GitHub connector cannot write arbitrary binary blobs, so the workflow downloads the public `BasHeemskerk/Granny-Decompiled` `vita` branch at run time and copies the exporter into that project. This also avoids committing a huge pile of generated Unity Library files.

## What it does

1. Downloads the `vita` source project.
2. Uses the project's Unity version: **2018.2.19f1**.
3. Adds the legacy Khronos/Hortor UnityGLTF exporter, which was designed for Unity 2018+.
4. Opens `Assets/Scene/1_Scenes/Scene.unity` in batch mode.
5. Exports the complete scene hierarchy to `granny_map.glb`, including mesh/material/texture data that UnityGLTF can resolve.
6. Packages the GLB in a tiny Godot project. Godot 4 supports GLB/glTF 2.0 directly and can turn the imported GLB into an editable scene.

## GitHub Actions setup

The workflow is manual: **Actions → Granny Map Export → Run workflow**.

The Unity 2018 runner needs Unity licensing credentials as repository Actions secrets:

- `UNITY_EMAIL`
- `UNITY_PASSWORD`
- `UNITY_SERIAL`

Do not put these values in the repository or workflow YAML.

## Output

The workflow artifact is `granny-map-godot` and contains:

- `granny_map.glb` - self-contained Godot-friendly map export.
- `project.godot` - minimal Godot 4 project.
- `README.md` - import/edit notes.

If the Unity exporter fails on a legacy asset/shader, the Actions log is the place to inspect the exact object/material causing it. The exporter is deliberately scene-wide so the next iteration can add targeted exclusions or shader-to-PBR material conversion without re-ripping the original game.
