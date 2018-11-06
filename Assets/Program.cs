using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using UnityEngine;

//using CommandLine;

namespace Town
{
    public class Program : MonoBehaviour
    {
   

      public void RunItInstance() {

            RunIt();
        }

        public static void RunIt()
        {
            TownRendererProxy proxy = GameObject.FindObjectOfType<TownRendererProxy>();


            TownOptions townOptions = new TownOptions
            {
                Overlay = true,// options.Overlay,
                Patches = 32,//options.Patches,
                Walls = true,//options.Walls,
                Water = true,//options.Water,
                Seed = /*options.Seed ?? */ new System.Random().Next()
            };

            Town town = new Town(townOptions);

            //   var img = new TownRenderer(town, townOptions).DrawTown();

            TownRenderer Trenderer = new TownRenderer(town, townOptions);

            proxy.townRenderer = Trenderer;

            proxy.DoShit();

        //    File.WriteAllText(@"C:\temp\town.svg", img);

        }
  
    }
}
