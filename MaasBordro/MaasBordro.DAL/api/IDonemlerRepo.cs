using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordro.DAL.api
{
    public interface IDonemlerRepo
    {
        IEnumerable<TBL_DONEMLER> GetAllDonemler();
        TBL_DONEMLER GetById(int id);
        void CreateDonemler(TBL_DONEMLER donemler);
        TBL_DONEMLER UpdateDonemler(int id, TBL_DONEMLER donemler);
        TBL_DONEMLER DeleteDonemler(int id);
       
    }
}
