using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction.Core;

namespace UMT360.InteriorDesignWebApp.RepositoryFactory
{
    public class Getter
    {
        public static IRepositoryContext GetRepository()
        {
            //Get data from config.
            bool isADONetRepositoryRequested = true;
            if (isADONetRepositoryRequested)
                return new RepositoryContext();

            return default(IRepositoryContext);
        }
    }
}