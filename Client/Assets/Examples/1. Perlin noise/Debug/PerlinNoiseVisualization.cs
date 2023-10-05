using UnityEngine;

namespace Examples._1._Perlin_noise.Debug
{
  /// <summary>
  ///   Visualizes the Perlin noise.
  /// </summary>
  public class PerlinNoiseVisualization : MonoBehaviour
  {
    [SerializeField] private Renderer renderer;

    [Range(1, 2500)] [SerializeField] private int width = 256;
    [Range(1, 2500)] [SerializeField] private int height = 256;
    [SerializeField] private float scale = 20f;
    [SerializeField] private float offsetX = 100f;
    [SerializeField] private float offsetY = 100f;

    [SerializeField] public bool AutoUpdate = true;

    public void Visualize()
    {
      var texture = new Texture2D(width, height);

      var colors = new Color[width * height];

      for (var x = 0; x < width; x++)
      for (var y = 0; y < height; y++)
      {
        var xCoord = (float) x / width * scale + offsetX;
        var yCoord = (float) y / height * scale + offsetY;
        var sample = Mathf.PerlinNoise(xCoord, yCoord);
        colors[y * width + x] = new(sample, sample, sample);
      }

      texture.SetPixels(colors);
      texture.Apply();

      renderer.material.mainTexture = texture;
    }
  }
}