using System.Collections.Generic;
using System.Linq;
using System.Text;
using Town.Geom;
using Town;
using UnityEngine;

namespace Town
{
    public class TownRendererProxy : MonoBehaviour
    {
        public GameObject Prefab;

        public Transform CityHolder;

        public Shader shader;

        public TownRenderer townRenderer;


        public void DoShit()
        {

            foreach (Transform child in CityHolder)
            {
                GameObject.DestroyImmediate(child.gameObject);
            }


            // populate geometry for now...
            townRenderer.DrawTown();

            foreach (var building in townRenderer.geometry.Buildings)
            {

                    GameObject spawned = Instantiate<GameObject>(Prefab, new Vector3(building.Shape.Center.x, 0, building.Shape.Center.y), Quaternion.identity, CityHolder);


                spawned.name = building.Description;


                int counter = 0;

                foreach (var item in townRenderer.geometry.Buildings)
                {
                    if (item.GetType() == building.GetType())
                    {

                        counter++;
                    }

                }



               

                spawned.GetComponent<Renderer>().sharedMaterial = new Material(shader);
                spawned.GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV(0, 1 / BuildingPlacer.estimatedPopulation * counter );


                //   var hover = $"onmouseover =\"document.getElementById('building{id}').style.visibility = 'visible'\" onmouseout=\"document.getElementById('building{id}').style.visibility = 'hidden'\"";
                //    sb.Append(building.Shape.ToSvgPolygon("building", hover));
                //    id++;
            }



        }
    }



}
