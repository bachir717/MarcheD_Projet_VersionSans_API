using Marches_Deconfines;
using Marches_Deconfines.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class Valeur
    {
        
        public  static int countelement(this HtmlHelper html)
        {
            //int res = (from e in Panier
            //           select e)
            //          .Count();
            MarcheD14Entities db = new MarcheD14Entities();
            PaniersController PC = new PaniersController();
            int value = PC.Countelement();
            return value;
        }

        public static double? Countprice(this HtmlHelper html)
        {
            MarcheD14Entities db = new MarcheD14Entities();
            PaniersController PC = new PaniersController();
            double? value = PC.CounteSomme();
            return value;
        }
    }
}