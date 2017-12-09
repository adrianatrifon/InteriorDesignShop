using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository;

namespace UMT360.InteriorDesignWebApp
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
            colorRepository.Update(color1);

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
            Color color3 = colorRepository.GetById(color2.Id);
            Console.WriteLine("{0}  {1}", color3.Id, color3.Name);
            colorRepository.Delete(color3.Id);
            /*
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
            materialRepository.Update(material1);

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

            Console.WriteLine("---------------------Brand Repository TEST----------------------------");
            List<Brand> brands = new List<Brand>();
            BrandRepository brandRepository = new BrandRepository();
            Brand brand = new Brand();
            Guid id2 = Guid.NewGuid();
            brand.Id = id2;
            brand.Name = "TestBrand";
            Brand brand1 = new Brand() { Id = id2, Name = "TestBrand1" };

            Console.WriteLine("---------Insert------------");
            brandRepository.Insert(brand);
            brands = brandRepository.ReadAll();

            foreach (Brand bran in brands)
            {
                Console.WriteLine("{0} ---- {1}", bran.Id, bran.Name);
            }


            Console.WriteLine("---------Update------------");
            brandRepository.Update(brand1);

            brands = brandRepository.ReadAll();

            foreach (Brand bran in brands)
            {
                Console.WriteLine("{0} ---- {1}", bran.Id, bran.Name);
            }

            Console.WriteLine("---------Delete------------");
            brandRepository.Delete(brand.Id);

            brands = brandRepository.ReadAll();

            foreach (Brand bran in brands)
            {
                Console.WriteLine("{0} ---- {1}", bran.Id, bran.Name);
            }

            Console.WriteLine("---------GetById------------");
            Brand brand2 = new Brand() { Id = id, Name = "TestBrand2" };
            brandRepository.Insert(brand2);
            brands = brandRepository.ReadAll();

            foreach (Brand bran in brands)
            {
                Console.WriteLine("{0} ---- {1}", bran.Id, bran.Name);
            }
            Console.WriteLine("-------------------------------------------------");
            Brand brand3 = brandRepository.GetById(brand2.Id);
            Console.WriteLine("{0}  {1}", brand3.Id, brand3.Name);
            brandRepository.Delete(brand3.Id);
            */
            
          /*
            List<Photo> photos = new List<Photo>();
            PhotoRepository photoRepository = new PhotoRepository();         
            photos = photoRepository.ReadAll();
           
            foreach (Photo col in photos)
           {
                string hexValue = BitConverter.ToString(col.Image,0,col.Image.Length);
                Console.Write(hexValue);
               // Console.WriteLine("{0} ---- {1}", col.Id, hexValue);
           }
           */
            Console.ReadLine();

        }

       
    }
}
