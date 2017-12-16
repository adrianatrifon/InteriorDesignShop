using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp
{
    class Program
    {
        static void Main(string[] args)
        {     
           
            Console.Clear();
            /*
            Console.WriteLine("---------------------ColorRepository TEST----------------------------\n");

            using (RepositoryContext repositoryContext = new RepositoryContext())
            {                
                ColorRepository colorRepository = RepositoryContext.ColorRepository;
                Color color = new Color();
                Guid id = Guid.NewGuid();
                color.Id = id;
                color.Name = "TestColor";
                Color color1 = new Color() { Id = id, Name = "TestColor1" };

                Console.WriteLine("---------Insert------------");
                colorRepository.Insert(color);
                ShowColors();



                Console.WriteLine("---------Update------------");
                colorRepository.Update(color1);

                ShowColors();


                Console.WriteLine("---------Delete------------");
                colorRepository.Delete(color.Id);

                ShowColors();


                Console.WriteLine("---------GetById------------");
                Color color2 = new Color() { Id = id, Name = "TestColor2" };
                colorRepository.Insert(color2);
                ShowColors();

                Console.WriteLine("-------------------------------------------------");
                Color color3 = colorRepository.GetById(color2.Id);
                Console.WriteLine("{0}  {1}", color3.Id, color3.Name);
                colorRepository.Delete(color3.Id);

                Console.WriteLine("---------------------MaterialRepository TEST----------------------------\n");
                //List<Material> materials = new List<Material>();
                MaterialRepository materialRepository = RepositoryContext.MaterialRepository;
                Material material = new Material();
                Guid id1 = Guid.NewGuid();
                material.Id = id1;
                material.Name = "TestMaterial";
                Material material1 = new Material() { Id = id1, Name = "TestMaterial1" };

                Console.WriteLine("---------Insert------------");
                materialRepository.Insert(material);
                ShowMaterials();


                Console.WriteLine("---------Update------------");
                materialRepository.Update(material1);
                ShowMaterials();


                Console.WriteLine("---------Delete------------");
                materialRepository.Delete(material.Id);

                ShowMaterials();


                Console.WriteLine("---------GetById------------");
                Material material2 = new Material() { Id = id, Name = "TestMaterial2" };
                materialRepository.Insert(material2);

                ShowMaterials();

                Console.WriteLine("-------------------------------------------------");
                Material material3 = materialRepository.GetById(material2.Id);
                Console.WriteLine("{0}  {1}", material3.Id, material3.Name);
                materialRepository.Delete(material3.Id);
                */
                Console.WriteLine("---------------------Brand Repository TEST----------------------------\n");
            //List<Brand> brands = new List<Brand>();
            using (BusinessContext businessContext = new BusinessContext())
            {
                ShowBrands(businessContext);
                //BrandBusiness brandBusiness = new BrandBusiness();
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
        /*
        public static void ShowColors()
        {
            List<Color> colors = RepositoryContext.ColorRepository.ReadAll();
            //colors = colorRepository.ReadAll();

            foreach (Color col in colors)
            {
                Console.WriteLine("{0} ---- {1}", col.Id, col.Name);
            }

        }
        public static void ShowMaterials()
        {
            List<Material> materials = RepositoryContext.MaterialRepository.ReadAll();
            //colors = colorRepository.ReadAll();

            foreach (Material material in materials)
            {
                Console.WriteLine("{0} ---- {1}", material.Id, material.Name);
            }

        }
        */
        public static void ShowBrands(BusinessContext businessContext)
        {
            List<Brand> brands = businessContext.BrandBusiness.ReadAll();
                //colors = colorRepository.ReadAll();

            foreach (Brand brand in brands)
            {
                Console.WriteLine("{0} ---- {1}", brand.Id, brand.Name);
            }

        }


    }
}
