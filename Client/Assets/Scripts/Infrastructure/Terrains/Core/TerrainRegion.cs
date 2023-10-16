using System;
using UnityEngine;

namespace Infrastructure.Terrains.Core
{
  /// <summary>
  ///   A region of a terrain with a set of properties.
  /// </summary>
  [Serializable]
  public class TerrainRegion
  {
    public string Name;
    public float Height;
    public Color Color;
  }
}