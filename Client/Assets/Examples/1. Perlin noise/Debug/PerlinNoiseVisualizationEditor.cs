using UnityEditor;
using UnityEngine;

namespace Examples._1._Perlin_noise.Debug
{
  /// <summary>
  ///   Custom editor for the PerlinNoiseVisualization component.
  /// </summary>
  [CustomEditor(typeof(PerlinNoiseVisualization))]
  public class PerlinNoiseVisualizationEditor : Editor
  {
    public override void OnInspectorGUI()
    {
      var visualization = (PerlinNoiseVisualization) target;

      // Button to refresh the visualization.
      if (GUILayout.Button("Refresh"))
        visualization.Visualize();

      // Draw the default inspector.
      if (DrawDefaultInspector())
        if (visualization.AutoUpdate)
          visualization.Visualize();
    }
  }
}