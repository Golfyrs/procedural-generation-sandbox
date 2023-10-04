namespace Infrastructure.Terrains.Core
{
  /// <summary>
  ///   The data for a generated terrain.
  /// </summary>
  public readonly struct TerrainData
  {
    /// <summary>
    ///   A 2D array representing the heightmap of the terrain.
    /// </summary>
    /// <remarks>
    ///   The values in the heightmap typically range from 0 (lowest point) to 1 (highest point).
    /// </remarks>
    public readonly float[,] Heights;

    /// <summary>
    ///   The width of the terrain.
    /// </summary>
    public readonly int HeightmapWidth;

    /// <summary>
    ///   The height of the terrain.
    /// </summary>
    public readonly int HeightmapHeight;

    public TerrainData(float[,] heights)
    {
      Heights = heights;

      HeightmapWidth = heights.GetLength(0);
      HeightmapHeight = heights.GetLength(1);
    }

    // TODO: Add biomes, resources,
  }
}