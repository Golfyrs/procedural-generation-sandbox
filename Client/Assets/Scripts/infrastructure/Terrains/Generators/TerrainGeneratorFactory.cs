using infrastructure.Terrains.Generators.Core;

namespace infrastructure.Terrains.Generators
{
  /// <summary>
  ///   Provides factory methods to create instances of terrain generators based on specified generation methods.
  /// </summary>
  /// <remarks>
  ///   The <see cref="TerrainGeneratorFactory"/> class centralizes the creation logic for different terrain generator implementations.
  ///   When adding new terrain generation methods, extend the <see cref="TerrainGenerationMethod"/> enumeration and update the factory method accordingly.
  /// </remarks>
  public static class TerrainGeneratorFactory
  {
    /// <summary>
    ///   Creates an instance of <see cref="ITerrainGenerator"/> based on the specified generation method and parameters.
    /// </summary>
    /// <param name="method">The method of terrain generation to use.</param>
    /// <param name="seed">The seed value for terrain generation.</param>
    /// <param name="scale">The scale factor for the terrain.</param>
    /// <param name="amplitude">The amplitude for terrain generation.</param>
    /// <param name="frequency">The frequency for terrain generation.</param>
    /// <returns>An instance of <see cref="ITerrainGenerator"/> configured with the specified parameters.</returns>
    public static ITerrainGenerator Create(TerrainGenerationMethod method, int seed, float scale, float amplitude, float frequency)
    {
      return null;
    }
  }
}