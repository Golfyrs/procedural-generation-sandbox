using System.Text;
using Infrastructure.Terrains.Generators.Core;
using UnityEngine;
using TerrainData = Infrastructure.Terrains.Core.TerrainData;

namespace Infrastructure.Terrains.Generators.PerlinNoises
{
  public class PerlinNoiseTerrainGenerator : ITerrainGenerator
  {
    private readonly int _seed;
    private readonly float _scale;
    private readonly float _amplitude;
    private readonly float _frequency;

    public PerlinNoiseTerrainGenerator(int seed, float scale, float amplitude, float frequency)
    {
      _seed = seed;
      _scale = scale;
      _amplitude = amplitude;
      _frequency = frequency;
    }

    public TerrainData Create(int width, int height)
    {
      var method = new PerlinNoiseMethod(_seed, width, height).Initialize();

      var heights = new float[width,height];
      for (var x = 0; x < width; x++)
      for (var y = 0; y < height; y++)
      {
        var posX = x * _scale * _frequency;
        var posY = y * _scale * _frequency;

        // var perlinValue = Mathf.PerlinNoise(posX + _seed * 10, posY + _seed * 10) * _amplitude;
        var perlinValue = method.Value(posX, posY) * _amplitude;
        heights[x, y] = perlinValue;
      }

      return new(heights);
    }

    public TerrainData CreateChunk(int startX, int startY, int chunkWidth, int chunkHeight)
    {
      var method = new PerlinNoiseMethod(_seed, chunkWidth, chunkHeight).Initialize();

      var heights = new float[chunkWidth,chunkHeight];
      for (var x = 0; x < chunkWidth; x++)
      for (var y = 0; y < chunkHeight; y++)
      {
        var posX = (startX + x) * _scale * _frequency;
        var posY = (startY + y) * _scale * _frequency;

        // var perlinValue = Mathf.PerlinNoise(posX + _seed * 10, posY + _seed * 10) * _amplitude;
        var perlinValue = method.Value(posX, posY) * _amplitude;
        heights[x, y] = perlinValue;
      }

      return new(heights);
    }
  }
}