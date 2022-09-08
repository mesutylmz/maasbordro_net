using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordro.DAL.api
{
    public interface IPersonelRepo
    {
        IEnumerable<TBL_PERSONEL> GetAllPersonel();
        TBL_PERSONEL GetById(int id);
        void CreatePersonel(TBL_PERSONEL personel);
        TBL_PERSONEL UpdatePersonel(int id, TBL_PERSONEL personel);
        TBL_PERSONEL DeletePersonel(int id);
        List<TBL_PERSONEL> GetByTcNoAndSifre(String tcNo,String sifre);
       
    }
}
