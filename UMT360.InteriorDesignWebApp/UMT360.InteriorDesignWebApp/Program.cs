using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp
{
    class Program
    {
        static void Main(string[] args)
        {             
            Console.Clear();            
            Console.WriteLine("---------------------ColorRepository TEST----------------------------\n");
            using (BusinessContext businessContext = new BusinessContext())
            {
                Color color = new Color();
                Guid id = Guid.NewGuid();
                color.Id = id;
                color.Name = "TestColor";
                Color color1 = new Color() { Id = id, Name = "TestColor1" };

                Console.WriteLine("---------Insert------------");
                businessContext.ColorBusiness.Insert(color);
                ShowColors(businessContext);

                Console.WriteLine("---------Update------------");
                businessContext.ColorBusiness.Update(color1);
                ShowColors(businessContext);

                Console.WriteLine("---------Delete------------");
                businessContext.ColorBusiness.Delete(color.Id);
                ShowColors(businessContext);

                Console.WriteLine("---------GetById------------");
                Color color2 = new Color() { Id = id, Name = "TestColor2" };
                businessContext.ColorBusiness.Insert(color2);
                ShowColors(businessContext);

                Console.WriteLine("-------------------------------------------------");
                Color color3 = businessContext.ColorBusiness.GetById(color2.Id);
                Console.WriteLine("{0}  {1}", color3.Id, color3.Name);
                businessContext.ColorBusiness.Delete(color3.Id);

                Console.WriteLine("---------------------MaterialRepository TEST----------------------------\n");
                Material material = new Material();
                Guid id1 = Guid.NewGuid();
                material.Id = id1;
                material.Name = "TestMaterial";
                Material material1 = new Material() { Id = id1, Name = "TestMaterial1" };

                Console.WriteLine("---------Insert------------");
                businessContext.MaterialBusiness.Insert(material);
                ShowMaterials(businessContext);


                Console.WriteLine("---------Update------------");
                businessContext.MaterialBusiness.Update(material1);
                ShowMaterials(businessContext);

                Console.WriteLine("---------Delete------------");
                businessContext.MaterialBusiness.Delete(material.Id);
                ShowMaterials(businessContext);

                Console.WriteLine("---------GetById------------");
                Material material2 = new Material() { Id = id, Name = "TestMaterial2" };
                businessContext.MaterialBusiness.Insert(material2);
                ShowMaterials(businessContext);

                Console.WriteLine("-------------------------------------------------");
                Material material3 = businessContext.MaterialBusiness.GetById(material2.Id);
                Console.WriteLine("{0}  {1}", material3.Id, material3.Name);
                businessContext.MaterialBusiness.Delete(material3.Id);
                
                Console.WriteLine("---------------------Brand Repository TEST----------------------------\n");           
                Brand brand = new Brand();
                Guid id2 = Guid.NewGuid();
                brand.Id = id2;
                brand.Name = "TestBrand";
                Brand brand1 = new Brand() { Id = id2, Name = "TestBrand1" };

                Console.WriteLine("---------Insert------------");
                businessContext.BrandBusiness.Insert(brand);
                ShowBrands(businessContext);

                Console.WriteLine("---------Update------------");
                businessContext.BrandBusiness.Update(brand1);
                ShowBrands(businessContext);

                Console.WriteLine("---------Delete------------");
                businessContext.BrandBusiness.Delete(brand.Id);
                ShowBrands(businessContext);

                Console.WriteLine("---------GetById------------");
                Brand brand2 = new Brand() { Id = id2, Name = "TestBrand2" };
                businessContext.BrandBusiness.Insert(brand2);
                ShowBrands(businessContext);

                Console.WriteLine("-------------------------------------------------");
                Brand brand3 = businessContext.BrandBusiness.GetById(brand2.Id);
                Console.WriteLine("{0}  {1}", brand3.Id, brand3.Name);
                businessContext.BrandBusiness.Delete(brand3.Id);

            }
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
        
        public static void ShowColors(BusinessContext businessContext)
        {
            List<Color> colors = businessContext.ColorBusiness.ReadAll();
            foreach (Color col in colors)
            {
                Console.WriteLine("{0} ---- {1}", col.Id, col.Name);
            }
        }
        public static void ShowMaterials(BusinessContext businessContext)
        {
            List<Material> materials = businessContext.MaterialBusiness.ReadAll();
            foreach (Material material in materials)
            {
                Console.WriteLine("{0} ---- {1}", material.Id, material.Name);
            }

        }
        
        public static void ShowBrands(BusinessContext businessContext)
        {
            List<Brand> brands = businessContext.BrandBusiness.ReadAll();
            foreach (Brand brand in brands)
            {
                Console.WriteLine("{0} ---- {1}", brand.Id, brand.Name);
            }
        }
    }
}
