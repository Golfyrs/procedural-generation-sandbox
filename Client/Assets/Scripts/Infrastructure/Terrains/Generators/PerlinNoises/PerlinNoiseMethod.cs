using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Random = System.Random;

namespace Infrastructure.Terrains.Generators.PerlinNoises
{
  public class PerlinNoiseMethod
  {
    private readonly int _width;
    private readonly int _height;
    private readonly Random _random;
    private readonly List<float2> _corners;

    public PerlinNoiseMethod(int seed, int width, int height)
    {
      _width = width;
      _height = height;
      _random = new(seed);
      _corners = new((_width + 1) * (_height + 1));
    }

    public PerlinNoiseMethod Initialize()
    {
      Randomize(_corners, _random, _width + 1, _height + 1);

      return this;

      static void Randomize(List<float2> corners, Random random, int width, int height)
      {
        // Generate a random value in circle for all corners
        for (var x = 0; x <= height; x++)
        for (var y = 0; y < width; y++)
        {
          var randomAngle = random.NextDouble() * 2 * Math.PI;

          var randomX = (float) Math.Cos(randomAngle);
          var randomY = (float) Math.Sin(randomAngle);

          corners.Add(new float2(randomX, randomY));
        }
      }
    }

    public float Value(float x, float y)
    {
      var gridIndexX = (int)math.floor(x);
      var gridIndexY = (int)math.floor(y);

      var topLeft = Corner(_corners, gridIndexX, gridIndexY, _width);
      var topRight = Corner(_corners, gridIndexX + 1, gridIndexY, _width);
      var bottomLeft = Corner(_corners, gridIndexX, gridIndexY + 1, _width);
      var bottomRight = Corner(_corners, gridIndexX + 1, gridIndexY + 1, _width);

      var localX = x - gridIndexX;
      var localY = y - gridIndexY;

      var dotTopLeft = math.dot(topLeft, new float2(localX, localY));
      var dotTopRight = math.dot(topRight, new float2(localX - 1, localY));
      var dotBottomLeft = math.dot(bottomLeft, new float2(localX, localY - 1));
      var dotBottomRight = math.dot(bottomRight, new float2(localX - 1, localY - 1));

      // var smoothX = localX * localX * (3 - 2 * localX);
      // var smoothY = localY * localY * (3 - 2 * localY);

      var smoothX = Fade(localX);
      var smoothY = Fade(localY);

      var left = math.lerp(dotTopLeft, dotBottomLeft, smoothY);
      var right = math.lerp(dotTopRight, dotBottomRight, smoothY);

      return math.lerp(left, right, smoothX) + 0.5f;

      // Optimized version (less multiplications) of fade function.
      float Fade(float t) => ((6 * t - 15) * t + 10) * t * t * t;
    }

    private static int ToOneDimensionalIndex(int cornerX, int cornerY, int width) =>
      cornerY * (width + 1) + cornerX;

    private static float2 Corner(List<float2> corners, int cornerX, int cornerY, int width) =>
      corners![ToOneDimensionalIndex(cornerX, cornerY, width)];
  }
}