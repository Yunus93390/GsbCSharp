using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_CS_AIY
{
    public class GestionDate
    {
        //Récupère le mois actuel

        public String getMois() {
            DateTime dtAct = DateTime.Now;
            String dateAct = dtAct.ToString("MM");

            return dateAct;
        }

        //Récupère le mois précédent

        public String getMoisPrecedent()
        {
            DateTime dtAct = DateTime.Now;
            String dateAct = dtAct.AddMonths(-1).ToString("MM");

            return dateAct;
        }

        //Récupère l'année précédente (pour pouvoir utliser les données de la base)
        
        public String getAnnee()
        {
            DateTime dtAct = DateTime.Now;
            String dateAct = dtAct.AddYears(-1).ToString("yyyy");

            return dateAct;
        }
        
        //Récupère le jour actuel
        
        public int getJour()
        {
            DateTime dtAct = DateTime.Now;
            String dateAct = dtAct.ToString("dd");
            int date = Convert.ToInt32(dateAct);

            return date;
        }
    }
}
