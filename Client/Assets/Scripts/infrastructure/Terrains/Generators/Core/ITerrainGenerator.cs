using infrastructure.Terrains.Core;

namespace infrastructure.Terrains.Generators.Core
{
  /// <summary>
  ///   Provides methods for generating terrain data, supporting both full terrain and chunk-based generation.
  /// </summary>
  /// <remarks>
  ///   Implementations of this interface should provide mechanisms to generate terrain based on various algorithms or techniques.
  ///   The interface supports generating the entire terrain using the <see cref="Create"/> method or specific chunks of the terrain using the <see cref="CreateChunk"/> method.
  ///   Chunk-based generation is particularly useful in scenarios like open-world games where loading or generating the entire map at once might be inefficient.
  ///   When implementing this interface, consider thread-safety, especially if terrain generation is expected to occur in parallel or asynchronous scenarios.
  /// </remarks>
  public interface ITerrainGenerator
  {
    /// <summary>
    ///   Generates the entire terrain based on the specified width and height.
    /// </summary>
    /// <param name="width">The width of the terrain to generate.</param>
    /// <param name="height">The height of the terrain to generate.</param>
    /// <returns>A <see cref="TerrainData"/> object containing the generated terrain data.</returns>
    TerrainData Create(int width, int height);

    /// <summary>
    ///   Generates a specific chunk or segment of the terrain.
    /// </summary>
    /// <param name="startX">The starting X-coordinate of the chunk.</param>
    /// <param name="startY">The starting Y-coordinate of the chunk.</param>
    /// <param name="chunkWidth">The width of the chunk to generate.</param>
    /// <param name="chunkHeight">The height of the chunk to generate.</param>
    /// <returns>A <see cref="TerrainData"/> object containing the generated terrain data for the specified chunk.</returns>
    TerrainData CreateChunk(int startX, int startY, int chunkWidth, int chunkHeight);
  }
}