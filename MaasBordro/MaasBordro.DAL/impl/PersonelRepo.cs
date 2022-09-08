using MaasBordro.DAL.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordro.DAL.impl
{
    public class PersonelRepo : IPersonelRepo
    { 
        public IEnumerable<TBL_PERSONEL> GetAllPersonel()
        {  
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entityList = entities.TBL_PERSONEL.ToList();
                return entityList;
            }  
        }

        public TBL_PERSONEL GetById(int id)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entity = entities.TBL_PERSONEL.FirstOrDefault(e => e.IND == id);
                return entity;
            }
        }
        public void CreatePersonel(TBL_PERSONEL personel)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                entities.TBL_PERSONEL.Add(personel);
                entities.SaveChanges();
            }
        }

        public TBL_PERSONEL DeletePersonel(int id)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
               
                var entity = entities.TBL_PERSONEL.FirstOrDefault(e => e.IND == id);
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entities.TBL_PERSONEL.Remove(entity);
                    entities.SaveChanges();
                    return entity;
                }
               
            }
        }


        public TBL_PERSONEL UpdatePersonel(int id,TBL_PERSONEL personel)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entity = entities.TBL_PERSONEL.FirstOrDefault(e => e.IND == id);
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entity.AD_SOYAD = personel.AD_SOYAD;
                    entity.ISE_GIRIS_TARIHI = personel.ISE_GIRIS_TARIHI;
                    entity.KAYDEDEN = personel.KAYDEDEN;
                    entity.KAYIT_TARIHI = personel.KAYIT_TARIHI;
                    entity.MIND = personel.MIND;
                    entity.PIND = personel.PIND;
                    entity.SGK = personel.SGK;
                    entity.SIFRE = personel.SIFRE;
                    entity.TC_NO = personel.TC_NO;

                    entities.SaveChanges();

                    return entity;
                }
            }
        }

        public List<TBL_PERSONEL> GetByTcNoAndSifre(string tcNo, string sifre)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entityList = entities.TBL_PERSONEL.Where(p => p.TC_NO == tcNo && p.SIFRE == sifre).ToList();
                return entityList;
            }
        }
    }
}
