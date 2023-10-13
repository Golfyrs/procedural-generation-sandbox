using UnityEditor;
using UnityEngine;

namespace Infrastructure.Terrains.Generators.Editor
{
  [CustomEditor(typeof(TerrainGenerator))]
  public class TerrainGeneratorEditor : UnityEditor.Editor
  {
    public override void OnInspectorGUI()
    {
      var generator = (TerrainGenerator) target;

      // Button to refresh the visualization.
      if (GUILayout.Button("Regenerate"))
        generator.Regenerate();

      // Draw the default inspector.
      DrawDefaultInspector();
    }
  }
}