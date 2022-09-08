using MaasBordro.DAL.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaasBordro.DAL.impl
{
    public class BordroRepo : IBordroRepo
    {
        public void CreateBordro(TBL_BORDRO bordro)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                entities.TBL_BORDRO.Add(bordro);
                entities.SaveChanges();
            }
        }

        public TBL_BORDRO DeleteBordro(int id)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {

                var entity = entities.TBL_BORDRO.FirstOrDefault(e => e.IND == id);
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entities.TBL_BORDRO.Remove(entity);
                    entities.SaveChanges();
                    return entity;
                }

            }
        }

        public IEnumerable<TBL_BORDRO> GetAllBordro()
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entityList = entities.TBL_BORDRO.ToList();
                return entityList;
            }
        }

        public TBL_BORDRO GetById(int id)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entity = entities.TBL_BORDRO.FirstOrDefault(e => e.IND == id);
                return entity;
            }
        }

        public List<TBL_BORDRO> GetByPindAndDind(string pind, string dind)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entityList = entities.TBL_BORDRO.Where(b => b.PIND.ToString() == pind && b.DIND.ToString() == dind).ToList();
                return entityList;
            }
        }

        public TBL_BORDRO UpdateBordro(int id, TBL_BORDRO bordro)
        {
            using (WEBBORDROEntities entities = new WEBBORDROEntities())
            {
                var entity = entities.TBL_BORDRO.FirstOrDefault(e => e.IND == id);
                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entity.AGI = bordro.AGI;
                    entity.AGI_HARIC_UCRET = bordro.AGI_HARIC_UCRET;
                    entity.AILE = bordro.AILE;
                    entity.AVANS = bordro.AVANS;
                    entity.COCUK_UCRETI = bordro.COCUK_UCRETI;
                    entity.DAMGA_VERGISI = bordro.DAMGA_VERGISI;
                    entity.DIGER_KAZANC = bordro.DIGER_KAZANC;
                    entity.DIND = bordro.DIND;
                    entity.FAZLA_MESAI_SAAT = bordro.FAZLA_MESAI_SAAT;
                    entity.FAZLA_MESAI_UCRET = bordro.FAZLA_MESAI_UCRET;
                    entity.GELIR_VERGISI = bordro.GELIR_VERGISI;
                    entity.GUN = bordro.GUN;
                    entity.GUN_UCRET = bordro.GUN_UCRET;
                    entity.GVM_AYLIK = bordro.GVM_AYLIK;
                    entity.GVM_TOPLAM = bordro.GVM_TOPLAM;
                    entity.HAFTASONU_MESAI_GUNU = bordro.HAFTASONU_MESAI_GUNU;
                    entity.HAFTASONU_MESAI_UCRETI = bordro.HAFTASONU_MESAI_UCRETI;
                    entity.ICRA_KESINTISI = bordro.ICRA_KESINTISI;
                    entity.ISSIZLIK_PRIMI = bordro.ISSIZLIK_PRIMI;
                    entity.KALAN_GELIR_VERGISI = bordro.KALAN_GELIR_VERGISI;
                    entity.KAYDEDEN = bordro.KAYDEDEN;
                    entity.KAYIT_TARIHI = bordro.KAYIT_TARIHI;
                    entity.MIND = bordro.MIND;
                    entity.NAFAGA_UCRETI = bordro.NAFAGA_UCRETI;
                    entity.NET_ISTIHKAK = bordro.NET_ISTIHKAK;
                    entity.NORMAL_KAZANC = bordro.NORMAL_KAZANC;
                    entity.NORMAL_UCRET = bordro.NORMAL_UCRET;
                    entity.OTO_KAT_BE = bordro.OTO_KAT_BE;
                    entity.OZEL_KESINTI = bordro.OZEL_KESINTI;
                    entity.PIND = bordro.PIND;
                    entity.PRIM = bordro.PRIM;
                    entity.RAPOR_GUN = bordro.RAPOR_GUN;
                    entity.RAPOR_UCRETI = bordro.RAPOR_UCRETI;
                    entity.SENDIKA_KESINTISI = bordro.SENDIKA_KESINTISI;
                    entity.SSK_MATRAHI = bordro.SSK_MATRAHI;
                    entity.SSK_PRIMI = bordro.SSK_PRIMI;
                    entity.TATIL_MESAI_GUN = bordro.TATIL_MESAI_GUN;
                    entity.TATIL_MESAI_UCRET = bordro.TATIL_MESAI_UCRET;
                    entity.TOPLAM_KAZANC = bordro.TOPLAM_KAZANC;
                    entity.YAKACAK_UCRETI = bordro.YAKACAK_UCRETI;
                    entity.YEMEK_GUNU = bordro.YEMEK_GUNU;
                    entity.YEMEK_UCRETI = bordro.YEMEK_UCRETI;


                    entities.SaveChanges();
                    return entity;
                }
            }
        }
    }
}
