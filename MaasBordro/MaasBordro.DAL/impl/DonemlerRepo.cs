using MaasBordro.DAL.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordro.DAL.impl
{
    public class DonemlerRepo : IDonemlerRepo
    {
        public void CreateDonemler(TBL_DONEMLER donemler)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                entities.TBL_DONEMLER.Add(donemler);
                entities.SaveChanges();
            }
        }

        public TBL_DONEMLER DeleteDonemler(int id)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {

                var entity = entities.TBL_DONEMLER.FirstOrDefault(e => e.IND == id);
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entities.TBL_DONEMLER.Remove(entity);
                    entities.SaveChanges();
                    return entity;
                }

            }
        }

        public IEnumerable<TBL_DONEMLER> GetAllDonemler()
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entityList = entities.TBL_DONEMLER.ToList();
                return entityList;
            }
        }

        public TBL_DONEMLER GetById(int id)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entity = entities.TBL_DONEMLER.FirstOrDefault(e => e.IND == id);
                return entity;
            }
        }

        public TBL_DONEMLER UpdateDonemler(int id, TBL_DONEMLER donemler)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entity = entities.TBL_DONEMLER.FirstOrDefault(e => e.IND == id);
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entity.DIND = donemler.DIND;
                    entity.DONEM = donemler.DONEM;
                    entity.KAYDEDEN = donemler.KAYDEDEN;
                    entity.KAYIT_TARIHI = donemler.KAYIT_TARIHI;

                    entities.SaveChanges();
                    return entity;
                }
            }
        }
    }
}
