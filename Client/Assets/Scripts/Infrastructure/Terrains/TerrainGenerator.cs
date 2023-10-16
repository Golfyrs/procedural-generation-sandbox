using System.Collections.Generic;
using Infrastructure.Terrains.Core;
using Infrastructure.Terrains.Generators;
using Infrastructure.Terrains.Generators.Core;
using UnityEngine;

namespace Infrastructure.Terrains
{
  /// <summary>
  ///   Generates a terrain using a <see cref="ITerrainGenerator"/>.
  ///   Transform the generated terrain into a texture with regions and apply it to a <see cref="Renderer"/>.
  /// </summary>
  public class TerrainGenerator : MonoBehaviour
  {
    [SerializeField] public List<TerrainRegion> regions = new List<TerrainRegion>
    {
      new TerrainRegion { Name = "Deep Water",    Height = 0.2f, Color = new Color(0/255f, 0/255f, 128/255f, 1) },
      new TerrainRegion { Name = "Shallow Water", Height = 0.3f, Color = new Color(0/255f, 0/255f, 255/255f, 1) },
      new TerrainRegion { Name = "Beach",         Height = 0.35f, Color = new Color(240/255f, 230/255f, 140/255f, 1) },
      new TerrainRegion { Name = "Plains",        Height = 0.5f, Color = new Color(34/255f, 139/255f, 34/255f, 1) },
      new TerrainRegion { Name = "Forest",        Height = 0.6f, Color = new Color(0/255f, 128/255f, 0/255f, 1) },
      new TerrainRegion { Name = "Hills",         Height = 0.75f, Color = new Color(139/255f, 69/255f, 19/255f, 1) },
      new TerrainRegion { Name = "Mountains",     Height = 0.85f, Color = new Color(128/255f, 128/255f, 128/255f, 1) },
      new TerrainRegion { Name = "Snow Peaks",    Height = 1.0f, Color = new Color(255/255f, 250/255f, 250/255f, 1) }
    };

    [SerializeField] private Renderer renderer;

    [Range(1, 2500)] [SerializeField] private int width = 256;
    [Range(1, 2500)] [SerializeField] private int height = 256;

    [SerializeField] private int seed = 0;

    [Range(0.01f, 100)] [SerializeField] private float scale = 1f;
    [Range(0.01f, 100)] [SerializeField] private float scaleDivider = 100f;

    [Range(0.001f, 10)] [SerializeField] private float amplitude = 1;
    [Range(0.001f, 10)] [SerializeField] private float frequency = 1;

    public void Regenerate()
    {
      var generator = TerrainGeneratorFactory.Create(TerrainGenerationMethod.PerlinNoise, seed, scale / scaleDivider, amplitude, frequency);
      var terrainData = generator.Create(width, height);

      var texture = new Texture2D(width, height);
      var colors = new Color[width * height];

      for (var x = 0; x < width; x++)
      for (var y = 0; y < height; y++)
      {
        var height = terrainData.Heights[x, y];

        var assignedColor = regions[^1].Color;

        foreach (var region in regions)
        {
          if (height <= region.Height)
          {
            assignedColor = region.Color;
            break;
          }
        }

        colors[y * width + x] = assignedColor;
      }

      texture.filterMode = FilterMode.Point;
      texture.wrapMode = TextureWrapMode.Clamp;
      texture.SetPixels(colors);
      texture.Apply();

      renderer.sharedMaterial.mainTexture = texture;
    }
  }
}