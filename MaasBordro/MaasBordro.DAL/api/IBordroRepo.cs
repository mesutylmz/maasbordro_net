using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordro.DAL.api
{
    public interface IBordroRepo
    {
        IEnumerable<TBL_BORDRO> GetAllBordro();
        TBL_BORDRO GetById(int id);
        void CreateBordro(TBL_BORDRO bordro);
        TBL_BORDRO UpdateBordro(int id, TBL_BORDRO bordro);
        TBL_BORDRO DeleteBordro(int id);
        List<TBL_BORDRO> GetByPindAndDind(String pind,String dind);
       
    }
}
