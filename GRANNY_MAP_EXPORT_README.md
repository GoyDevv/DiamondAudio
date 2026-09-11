# Granny Forsaken map export

This branch contains a GitHub Actions pipeline that uses AssetRipper 2.0.0 to extract the supplied Granny Forsaken V1.2.7 Unity/IL2CPP build as primary content and produce GLB output.

## Input

Put this file in the repository root:

`granny-forsaken-v1.2.7-no-effects.zip`

The archive should contain the `Granny Forsaken.exe` and its `Granny Forsaken_Data` directory.

## Run

Open **Actions -> Granny Forsaken -> textured GLB**, then choose **Run workflow**.

The `granny-forsaken-v1.2.7-map` artifact contains the selected map GLB. The `granny-forsaken-v1.2.7-all-assets` artifact contains the complete primary-content export, including other GLBs and decoded textures where AssetRipper can export them.

AssetRipper's primary-content exporter supports GLB model export; the project also contains scene/level-aware GLB generation. If the game has multiple level scenes, the workflow prefers a scene/level/map-named GLB and otherwise falls back to the largest exported GLB.
