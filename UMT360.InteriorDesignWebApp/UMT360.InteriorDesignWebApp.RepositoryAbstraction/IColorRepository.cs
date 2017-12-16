using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IColorRepository
    {
        List<Color> ReadAll();
        void Insert(Color color);
        void Update(Color color);
        void Delete(Guid colorId);
        Color GetById(Guid colorId);
    }
}
