using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebbApp.Models;
using UMT360.InteriorDesignWebbApp.Repository;

namespace UMT360.InteriorDesignWebbApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---------------------ColorRepository TEST----------------------------");

            Console.Clear();
            List<Color> colors = new List<Color>();
            ColorRepository colorRepository = new ColorRepository();
            Color color = new Color();
            Guid id = Guid.NewGuid();
            color.Id = id;
            color.Name = "TestColor";
            Color color1 = new Color() { Id = id, Name = "TestColor1" };
            
            Console.WriteLine("---------Insert------------");
            colorRepository.Insert(color);
            colors = colorRepository.ReadAll();

            foreach (Color col in colors)
            {
                Console.WriteLine("{0} ---- {1}", col.Id, col.Name);
            }
            

            Console.WriteLine("---------Update------------");
            colorRepository.Update(color, color1.Name);

            colors = colorRepository.ReadAll();

            foreach (Color col in colors)
            {
                Console.WriteLine("{0} ---- {1}", col.Id, col.Name);
            }
            
            Console.WriteLine("---------Delete------------");
            colorRepository.Delete(color.Id);
            
            colors = colorRepository.ReadAll();
           
            foreach (Color col in colors)
            {
                Console.WriteLine("{0} ---- {1}", col.Id, col.Name);
            }

            Console.WriteLine("---------GetById------------");
            Color color2 = new Color() { Id = id, Name = "TestColor2" };
            colorRepository.Insert(color2);
            colors = colorRepository.ReadAll();

            foreach (Color col in colors)
            {
                Console.WriteLine("{0} ---- {1}", col.Id, col.Name);
            }
            Console.WriteLine("-------------------------------------------------");
            Color color3=colorRepository.GetById(color2.Id);
            Console.WriteLine("{0}  {1}", color3.Id, color3.Name);
            colorRepository.Delete(color3.Id);

            Console.WriteLine("---------------------MaterialRepository TEST----------------------------");
            List<Material> materials = new List<Material>();
            MaterialRepository materialRepository = new MaterialRepository();
            Material material = new Material();
            Guid id1 = Guid.NewGuid();
            material.Id = id1;
            material.Name = "TestMaterial";
            Material material1 = new Material() { Id = id1, Name = "TestMaterial1" };

            Console.WriteLine("---------Insert------------");
            materialRepository.Insert(material);
            materials = materialRepository.ReadAll();

            foreach (Material mat in materials)
            {
                Console.WriteLine("{0} ---- {1}", mat.Id, mat.Name);
            }


            Console.WriteLine("---------Update------------");
            materialRepository.Update(material, material1.Name);

            materials = materialRepository.ReadAll();

            foreach (Material mat in materials)
            {
                Console.WriteLine("{0} ---- {1}", mat.Id, mat.Name);
            }

            Console.WriteLine("---------Delete------------");
            materialRepository.Delete(material.Id);

            materials = materialRepository.ReadAll();

            foreach (Material mat in materials)
            {
                Console.WriteLine("{0} ---- {1}", mat.Id, mat.Name);
            }

            Console.WriteLine("---------GetById------------");
            Material material2 = new Material() { Id = id, Name = "TestMaterial2" };
            materialRepository.Insert(material2);
            materials = materialRepository.ReadAll();

            foreach (Material mat in materials)
            {
                Console.WriteLine("{0} ---- {1}", mat.Id, mat.Name);
            }
            Console.WriteLine("-------------------------------------------------");
            Material material3 = materialRepository.GetById(material2.Id);
            Console.WriteLine("{0}  {1}", material3.Id, material3.Name);
            materialRepository.Delete(material3.Id);


            Console.ReadLine();
        }
    }
}
