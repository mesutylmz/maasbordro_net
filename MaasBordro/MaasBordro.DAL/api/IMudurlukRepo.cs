using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordro.DAL.api
{
    public interface IMudurlukRepo
    {
        IEnumerable<TBL_MUDURLUK> GetAllMudurluk();
        TBL_MUDURLUK GetById(int id);
        void CreateMudurluk(TBL_MUDURLUK mudurluk);
        TBL_MUDURLUK UpdateMudurluk(int id, TBL_MUDURLUK mudurluk);
        TBL_MUDURLUK DeleteMudurluk(int id);
       
    }
}
