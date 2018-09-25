//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Bilbakalim.Models
//{
//    public class SoruModel
//    {


//        public Sorular SoruOlustur(Sorular yeniSoru, List<Cevaplar> yeniCevaplar)
//        {

//            try
//            {
//                using (var context = new BilBakalimEntities())
//                {
//                    context.Sorular.Add(yeniSoru);
//                    foreach (var item in yeniCevaplar)
//                    {
//                        context.Cevaplar.Add(item);
//                    }
//                    context.SaveChanges();
//                    return yeniSoru;
//                }
//            }
//            catch (Exception)
//            {

//                throw;
//            }


//        }
//    }
//}