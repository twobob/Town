using System.Collections.Generic;
using Town.Geom;

namespace Town
{
    public class TownGeometry
    {
        public TownGeometry()
        {
            Buildings = new List<Building>();
            Walls = new List<Edge>();
            Towers = new List<Vector2>();
            Gates = new List<Vector2>();
            Roads = new List<List<Vector2>>();
            Overlay = new List<Patch>();
            Water = new List<Polygon>();
        }

        public List<Building> Buildings { get; private set; }
        public List<Edge> Walls { get; private set; }
        public List<Vector2> Towers { get; private set; }
        public List<Vector2> Gates { get; private set; }
        public List<List<Vector2>> Roads { get; private set; }
        public List<Patch> Overlay { get; private set; }
        public List<Polygon> Water { get; private set; }
        public Polygon WaterBorder { get; set; }
    }
}