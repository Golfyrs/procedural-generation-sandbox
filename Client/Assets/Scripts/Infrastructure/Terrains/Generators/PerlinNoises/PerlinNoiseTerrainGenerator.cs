using Infrastructure.Terrains.Generators.Core;
using UnityEngine;
using Random = System.Random;
using TerrainData = Infrastructure.Terrains.Core.TerrainData;

namespace Infrastructure.Terrains.Generators.PerlinNoises
{
  public class PerlinNoiseTerrainGenerator : ITerrainGenerator
  {
    private readonly int _seed;
    private readonly float _scale;
    private readonly float _amplitude;
    private readonly float _frequency;

    private readonly Random _random;

    public PerlinNoiseTerrainGenerator(int seed, float scale, float amplitude, float frequency)
    {
      _seed = seed;
      _scale = scale;
      _amplitude = amplitude;
      _frequency = frequency;

      _random = new Random(seed);
    }

    public TerrainData Create(int width, int height)
    {
      var heights = new float[width,height];
      for (var x = 0; x < width; x++)
      for (var y = 0; y < height; y++)
      {
        var perlinValue = PerlinNoise(x * _scale * _frequency, y * _scale * _frequency) * _amplitude;
        heights[x, y] = perlinValue;
      }

      return new(heights);

    }

    public TerrainData CreateChunk(int startX, int startY, int chunkWidth, int chunkHeight)
    {
      var heights = new float[chunkWidth,chunkHeight];
      for (var x = 0; x < chunkWidth; x++)
      for (var y = 0; y < chunkHeight; y++)
      {
        var perlinValue = PerlinNoise((startX + x) * _scale * _frequency, (startY + y) * _scale * _frequency) * _amplitude;
        heights[x, y] = perlinValue;
      }

      return new(heights);
    }

    // TODO: Replace with actual Perlin noise implementation. Also better to use double instead of float.
    private static float PerlinNoise(float x, float y) =>
      Mathf.PerlinNoise(x, y);
  }
}