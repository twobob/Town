using Town.Geom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Town
{
    //public static class Polyfills
    //{
    //    public static T GetCustomAttribute<T>(this Type type) where T : Attribute
    //    {
    //        // Send inherit as false if you want the attribute to be searched only on the type. If you want to search the complete inheritance hierarchy, set the parameter to true.
    //        object[] attributes = type.GetCustomAttributes(true);
    //        return attributes.OfType<T>().FirstOrDefault();
    //    }

       
    //}



    public class Building
    {
        public Building(string description, Polygon shape)
        {
            Shape = shape;
            Description = description;
        }

        public Polygon Shape { get; set; }
        public string Description { get; set; }
    }

    public class BuildingPlacer
    {

        public static CurrentCustomAttributes CustomAttributes;
        public static int estimatedPopulation;

        private readonly List<Polygon> _buildings;
        private readonly float _avgPopulationPrBuilding;

        public BuildingPlacer(List<Polygon> buildings, float avgPopulationPrBuilding = 10)
        {
            _buildings = buildings.OrderByDescending(b => b.Area()).ToList();
            _avgPopulationPrBuilding = avgPopulationPrBuilding;
        }

        public List<Building> PopulateBuildings()
        {
            var populated = new List<Building>();

            estimatedPopulation = (int)(_avgPopulationPrBuilding * _buildings.Count);

            var values = Enum.GetValues(typeof(BuildingType));


            Array.Reverse(values);

            foreach (BuildingType value in values)
            {
          //      var buildingType = typeof(BuildingType).GetField(value.ToString()) ;//).GetCustomAttribute<BuildingStatsAttribute>();


                //var fieldInfo = typeof(BuildingType).GetField(value.ToString(), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);


                //if (fieldInfo == null)
                //{
                  
                //    continue;
                //}

                SetupCustomAttributes(value);


           //     BuildingStatsAttribute buildingTypeGetCustomAttributes = (BuildingStatsAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(BuildingStatsAttribute),false);



            //    var numOfType = (int)Math.Ceiling(estimatedPopulation / (float)buildingTypeGetCustomAttributes.Population);
                var numOfType = (int)Math.Ceiling(estimatedPopulation / (float)CustomAttributes.Population);

                for (var i = 0; i < numOfType; i++)
                {
                    if (_buildings.Count > 0)
                    {
                     //   var building = new Building(buildingTypeGetCustomAttributes.Description, _buildings[0]);

                        var building = new Building(CustomAttributes.Description, _buildings[0]);

                        populated.Add(building);
                        _buildings.RemoveAt(0);
                    }
                }
            }

            return populated;

        }


        private void SetupCustomAttributes(BuildingType buildingType   ) {

            CurrentCustomAttributes returnedCurrentCustomAttributes = new CurrentCustomAttributes();

            switch (buildingType)
            {
                case BuildingType.Empty:
              // do nothing
                    break;
                case BuildingType.Home:
                    returnedCurrentCustomAttributes.Population = 10;
                    returnedCurrentCustomAttributes.Description = "Home";
                    break;
                case BuildingType.Shoemakers:
                    returnedCurrentCustomAttributes.Description = "Shoemakers";
                    returnedCurrentCustomAttributes.Population = 150;
                    break;
                case BuildingType.Furriers:
                    returnedCurrentCustomAttributes.Description = "Furriers";
                        returnedCurrentCustomAttributes.Population = 250;
                    break;
                case BuildingType.Maidservants:
                    returnedCurrentCustomAttributes.Description = "Maidservants";
                    returnedCurrentCustomAttributes.Population = 250;
                    break;
                case BuildingType.Tailors:
                    returnedCurrentCustomAttributes.Description = "Tailors";
                    returnedCurrentCustomAttributes.Population = 250;
                    break;
                case BuildingType.Barbers:
                    returnedCurrentCustomAttributes.Description = "Barbers";
                    returnedCurrentCustomAttributes.Population = 350;
                    break;
                case BuildingType.Healer:
                    returnedCurrentCustomAttributes.Description = "Healer";
                    returnedCurrentCustomAttributes.Population = 350;
                    break;
                case BuildingType.Jewelers:
                    returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 400;
                    break;
                case BuildingType.OldClothes:
                          returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 400;
                    break;
                case BuildingType.TavernsRestaurants:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 400;
                    break;
                case BuildingType.Masons:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 500;
                    break;
                case BuildingType.Pastrycooks:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 500;
                    break;
                case BuildingType.Shrine:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 500;
                    break;
                case BuildingType.Carpenters:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 550;
                    break;
                case BuildingType.Weavers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 600;
                    break;
                case BuildingType.Barrelmaker:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 700;
                    break;

                case BuildingType.Chandlers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 700;
                    break;
                case BuildingType.Textiletrader:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 700;
                    break;
                case BuildingType.Bakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 800;
                    break;
                case BuildingType.Scabbardmakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 850;
                    break;
                case BuildingType.Watercarriers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 900;
                    break;
                case BuildingType.WineSellers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 950;
                    break;
                case BuildingType.Hatmakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1000;
                    break;
                case BuildingType.ChickenButchers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1100;
                    break;
                case BuildingType.Saddlers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1200;
                    break;
                case BuildingType.Pursemakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1200;
                    break;
                case BuildingType.Butchers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1400;
                    break;
                case BuildingType.Fishmongers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1400;
                    break;
                case BuildingType.BeerSellers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1400;
                    break;
                case BuildingType.BuckleMakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1400;
                    break;
                case BuildingType.Plasterers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1400;
                    break;
                case BuildingType.SpiceMerchants:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1400;
                    break;
                case BuildingType.Blacksmiths:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1500;
                    break;
                case BuildingType.Painters:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1500;
                    break;
                case BuildingType.Doctors:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1700;
                    break;
                case BuildingType.Roofers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1800;
                    break;
                case BuildingType.Bathers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1900;
                    break;
                case BuildingType.Locksmiths:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1900;
                    break;
                case BuildingType.Ropemakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 1900;
                    break;

                case BuildingType.Copyists:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 2000;
                    break;
                case BuildingType.HarnessMakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
 returnedCurrentCustomAttributes.Population = 2000;
                    break;
                case BuildingType.Inns:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
 returnedCurrentCustomAttributes.Population = 2000;
                    break;
                case BuildingType.Rugmakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
 returnedCurrentCustomAttributes.Population = 2000;
                    break;
                case BuildingType.Sculptors:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
 returnedCurrentCustomAttributes.Population = 2000;
                    break;
                case BuildingType.Tanners:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
 returnedCurrentCustomAttributes.Population = 2000;
                    break;
                case BuildingType.Bleachers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
 returnedCurrentCustomAttributes.Population = 2100;
                    break;
                case BuildingType.Cutlers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 2300;
                    break;
                case BuildingType.HayMerchants:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 230;
                    break;
                case BuildingType.Glovemakers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 2400;
                    break;
                case BuildingType.Woodcarvers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 2400;
                    break;
                case BuildingType.Woodsellers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 2800;
                    break;
                case BuildingType.MagicShops:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 3000;
                    break;
                case BuildingType.Bookbinders:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 3000;
                    break;
                case BuildingType.Illuminators:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 3900;
                    break;
                case BuildingType.Temple:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 6000;
                    break;
                case BuildingType.Booksellers:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 6300;
                    break;
                case BuildingType.University:
                                           returnedCurrentCustomAttributes.Description = buildingType.ToString().Replace("BuildingType","");
                    returnedCurrentCustomAttributes.Population = 10000;
                    break;
                default:
                    break;
            }


            BuildingPlacer.CustomAttributes = returnedCurrentCustomAttributes;

        }


    }

    public class CurrentCustomAttributes {

      public  float Population = 1;
        public float MinSize = 1;
        public string Description = "Empty";

    }

    public enum BuildingType
    {
        [BuildingStats(MinSize = 1, Population = 1, Description = "Empty")] Empty,
        [BuildingStats(MinSize = 1, Population = 10, Description = "Home")] Home,
        [BuildingStats(MinSize = 1, Population = 150, Description = "Shoemakers")] Shoemakers,
        [BuildingStats(MinSize = 1, Population = 250, Description = "Furriers")] Furriers,
        [BuildingStats(MinSize = 1, Population = 250, Description = "Maidservants")] Maidservants,
        [BuildingStats(MinSize = 1, Population = 250, Description = "Tailors")] Tailors,
        [BuildingStats(MinSize = 1, Population = 350, Description = "Barbers")] Barbers,
        [BuildingStats(MinSize = 1, Population = 350, Description = "Healer")] Healer,
        [BuildingStats(MinSize = 1, Population = 400, Description = "Jewelers")] Jewelers,
        [BuildingStats(MinSize = 1, Population = 400, Description = "Old-Clothes")] OldClothes,
        [BuildingStats(MinSize = 2, Population = 400, Description = "Taverns/Restaurants")] TavernsRestaurants,
        [BuildingStats(MinSize = 1, Population = 500, Description = "Masons")] Masons,
        [BuildingStats(MinSize = 1, Population = 500, Description = "Pastrycooks")] Pastrycooks,
        [BuildingStats(MinSize = 1, Population = 500, Description = "Shrine")] Shrine,
        [BuildingStats(MinSize = 2, Population = 550, Description = "Carpenters")] Carpenters,
        [BuildingStats(MinSize = 2, Population = 600, Description = "Weavers")] Weavers,
        [BuildingStats(MinSize = 2, Population = 700, Description = "Barrel maker (cooper)")] Barrelmaker,
        [BuildingStats(MinSize = 1, Population = 700, Description = "Chandlers")] Chandlers,
        [BuildingStats(MinSize = 2, Population = 700, Description = "Textile trader (mercer)")] Textiletrader,
        [BuildingStats(MinSize = 2, Population = 800, Description = "Bakers")] Bakers,
        [BuildingStats(MinSize = 1, Population = 850, Description = "Scabbardmakers")] Scabbardmakers,
        [BuildingStats(MinSize = 1, Population = 850, Description = "Watercarriers")] Watercarriers,
        [BuildingStats(MinSize = 1, Population = 900, Description = "Wine-Sellers")] WineSellers,
        [BuildingStats(MinSize = 1, Population = 950, Description = "Hatmakers")] Hatmakers,
        [BuildingStats(MinSize = 3, Population = 1000, Description = "Chicken Butchers")] ChickenButchers,
        [BuildingStats(MinSize = 2, Population = 1000, Description = "Saddlers")] Saddlers,
        [BuildingStats(MinSize = 2, Population = 1100, Description = "Pursemakers")] Pursemakers,
        [BuildingStats(MinSize = 3, Population = 1200, Description = "Butchers")] Butchers,
        [BuildingStats(MinSize = 2, Population = 1200, Description = "Fishmongers")] Fishmongers,
        [BuildingStats(MinSize = 2, Population = 1400, Description = "Beer-Sellers")] BeerSellers,
        [BuildingStats(MinSize = 2, Population = 1400, Description = "Buckle Makers")] BuckleMakers,
        [BuildingStats(MinSize = 1, Population = 1400, Description = "Plasterers")] Plasterers,
        [BuildingStats(MinSize = 1, Population = 1400, Description = "Spice Merchants")] SpiceMerchants,
        [BuildingStats(MinSize = 2, Population = 1500, Description = "Blacksmiths")] Blacksmiths,
        [BuildingStats(MinSize = 1, Population = 1500, Description = "Painters")] Painters,
        [BuildingStats(MinSize = 2, Population = 1700, Description = "Doctors")] Doctors,
        [BuildingStats(MinSize = 1, Population = 1800, Description = "Roofers")] Roofers,
        [BuildingStats(MinSize = 3, Population = 1900, Description = "Bathers")] Bathers,
        [BuildingStats(MinSize = 1, Population = 1900, Description = "Locksmiths")] Locksmiths,
        [BuildingStats(MinSize = 2, Population = 1900, Description = "Ropemakers")] Ropemakers,
        [BuildingStats(MinSize = 2, Population = 2000, Description = "Copyists")] Copyists,
        [BuildingStats(MinSize = 2, Population = 2000, Description = "Harness-Makers")] HarnessMakers,
        [BuildingStats(MinSize = 3, Population = 2000, Description = "Inns")] Inns,
        [BuildingStats(MinSize = 2, Population = 2000, Description = "Rugmakers")] Rugmakers,
        [BuildingStats(MinSize = 3, Population = 2000, Description = "Sculptors")] Sculptors,
        [BuildingStats(MinSize = 3, Population = 2000, Description = "Tanners")] Tanners,
        [BuildingStats(MinSize = 3, Population = 2100, Description = "Bleachers")] Bleachers,
        [BuildingStats(MinSize = 2, Population = 2300, Description = "Cutlers")] Cutlers,
        [BuildingStats(MinSize = 3, Population = 2300, Description = "Hay Merchants")] HayMerchants,
        [BuildingStats(MinSize = 2, Population = 2400, Description = "Glovemakers")] Glovemakers,
        [BuildingStats(MinSize = 2, Population = 2400, Description = "Woodcarvers")] Woodcarvers,
        [BuildingStats(MinSize = 2, Population = 2400, Description = "Woodsellers")] Woodsellers,
        [BuildingStats(MinSize = 2, Population = 2800, Description = "Magic-Shops")] MagicShops,
        [BuildingStats(MinSize = 2, Population = 3000, Description = "Bookbinders")] Bookbinders,
        [BuildingStats(MinSize = 2, Population = 3900, Description = "Illuminators")] Illuminators,
        [BuildingStats(MinSize = 4, Population = 6000, Description = "Temple")] Temple,
        [BuildingStats(MinSize = 2, Population = 6300, Description = "Booksellers")] Booksellers,
        [BuildingStats(MinSize = 4, Population = 10000, Description = "University")] University,
    }

    public class BuildingStatsAttribute : Attribute
    {
        public int MinSize { get; set; }
        public int Population { get; set; }
        public string Description { get; set; }
    }

  
}