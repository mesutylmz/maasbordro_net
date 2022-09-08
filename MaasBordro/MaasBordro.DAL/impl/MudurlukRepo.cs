using MaasBordro.DAL.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordro.DAL.impl
{
    public class MudurlukRepo : IMudurlukRepo
    {
        public void CreateMudurluk(TBL_MUDURLUK mudurluk)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                entities.TBL_MUDURLUK.Add(mudurluk);
                entities.SaveChanges();
            }
        }

        public TBL_MUDURLUK DeleteMudurluk(int id)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {

                var entity = entities.TBL_MUDURLUK.FirstOrDefault(e => e.IND == id);
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entities.TBL_MUDURLUK.Remove(entity);
                    entities.SaveChanges();
                    return entity;
                }

            }
        }

        public IEnumerable<TBL_MUDURLUK> GetAllMudurluk()
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entityList = entities.TBL_MUDURLUK.ToList();
                return entityList;
            }
        }

        public TBL_MUDURLUK GetById(int id)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entity = entities.TBL_MUDURLUK.FirstOrDefault(e => e.IND == id);
                return entity;
            }
        }

        public TBL_MUDURLUK UpdateMudurluk(int id, TBL_MUDURLUK mudurluk)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entity = entities.TBL_MUDURLUK.FirstOrDefault(e => e.IND == id);
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entity.MIND = mudurluk.MIND;
                    entity.MUDURLUGU = mudurluk.MUDURLUGU;

                    entities.SaveChanges();
                    return entity;
                }
            }
        }
    }
}
