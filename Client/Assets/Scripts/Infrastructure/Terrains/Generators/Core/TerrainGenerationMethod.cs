namespace Infrastructure.Terrains.Generators.Core
{
  /// <summary>
  ///   The terrain generation method.
  /// </summary>
  public enum TerrainGenerationMethod
  {
    /// <summary>
    ///   Terrain generated using the Perlin noise algorithm, which produces smooth, continuous terrains.
    /// </summary>
    PerlinNoise,

    /// <summary>
    ///   Terrain generated using the Simplex noise algorithm, an improvement over Perlin noise, especially efficient in higher dimensions.
    /// </summary>
    SimplexNoise,

    /// <summary>
    ///   Terrain generated using the Diamond-Square algorithm, a recursive division method producing fractal-like terrains.
    /// </summary>
    DiamondSquare,

    /// <summary>
    ///   Terrain generated based on Voronoi diagrams, splitting space into regions based on distance to seed points.
    /// </summary>
    Voronoi,

    /// <summary>
    ///   Terrain generated using cellular automata, evolving a grid of cells in steps based on neighboring cell states.
    /// </summary>
    CellularAutomata,

    /// <summary>
    ///   Terrain generated using the midpoint displacement method, a type of fractal generation.
    /// </summary>
    MidpointDisplacement,

    /// <summary>
    ///   Terrain generated using Fractal Brownian Motion, combining multiple layers of noise functions.
    /// </summary>
    FractalBrownianMotion,

    /// <summary>
    ///   Terrain generated using Worley or Cellular noise, producing organic and cellular patterns.
    /// </summary>
    WorleyNoise,

    /// <summary>
    ///   Terrain generated using value noise, interpolating between a lattice of random values.
    /// </summary>
    ValueNoise,
  }
}