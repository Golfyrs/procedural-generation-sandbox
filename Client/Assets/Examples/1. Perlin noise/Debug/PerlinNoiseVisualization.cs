using Infrastructure.Terrains.Generators;
using Infrastructure.Terrains.Generators.Core;
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
    [SerializeField] private int seed = 0;
    [SerializeField] private float scale = 1f;
    [SerializeField] private float amplitude = 1;
    [SerializeField] private float frequency = 1;

    [SerializeField] public bool AutoUpdate = true;

    public void Visualize()
    {
      var generator = TerrainGeneratorFactory.Create(TerrainGenerationMethod.PerlinNoise, seed, scale, amplitude, frequency);
      var terrainData = generator.Create(width, height);

      var texture = new Texture2D(width, height);
      var colors = new Color[width * height];

      for (var x = 0; x < width; x++)
      for (var y = 0; y < height; y++)
      {
        var sample = terrainData.Heights[x, y];
        colors[y * width + x] = new(sample, sample, sample);
      }

      texture.SetPixels(colors);
      texture.Apply();

      renderer.material.mainTexture = texture;
    }
  }
}