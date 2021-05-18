using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GSB_CS_AIY
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private ConnexionSql maConnexion;
        private MySqlCommand oCom;
        private DataTable dt;
        private String anneeMois;
        private String moisActuel;
        private String AnneeActuel;
        private int jourActuel;

        private string lc = "localhost";
        private string bdd = "gsb-v1";
        private string login = "root";
        private string mdp = "";


        private void Form1_Load(object sender, EventArgs e)
        {

            //   connexion à la BDD


            maConnexion = ConnexionSql.getInstance(lc, bdd, login, mdp);
            maConnexion.openConnection();


            //   Utilisation des méthodes de Gestin Date

            GestionDate gestionDate = new GestionDate();

            jourActuel = gestionDate.getJour();

            anneeMois = gestionDate.getAnnee() + gestionDate.getMoisPrecedent();

            affiche();

            maConnexion.closeConnection();

        }


        /// <summary>
        ///   Permet de vérifier si on se situe entre le 1er et le 10 du mois
        ///   si l'état est 'CR' alors on passe à 'CL'
        /// </summary>

        public void majCR() 
        {
            try
            {
                if (jourActuel >= 1 && jourActuel <= 10)
                {
                    String req = "UPDATE fichefrais SET idEtat = 'CL' WHERE idEtat = 'CR' AND mois =" + anneeMois;

                    oCom = maConnexion.reqExec(req);
                    oCom.ExecuteNonQuery();

                    affiche();
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        ///   Permet de vérifier si on se situe entre le 20 et le 30 du mois
        ///   si l'état est 'VA' alors on passe à 'RB'
        /// </summary>

        public void majRB()
        {
            try {
                if (jourActuel >= 20 && jourActuel <= 31)
                {
                    String req = "UPDATE fichefrais SET idEtat = 'RB' WHERE idEtat = 'VA' AND mois =" + anneeMois;

                    oCom = maConnexion.reqExec(req);
                    oCom.ExecuteNonQuery();

                    affiche();
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///   Permet d'afficher sous forme de tableau (DataGridView) les informations de la requete
        /// </summary>


        public void affiche()
        {
            dt = new DataTable();

            dateMoisPrecedent.Text = anneeMois;


            //   Affiche les fichesfrais du mois et de l'année en question
            
               
            String req = "Select * From fichefrais where mois ="+ anneeMois;
            oCom = maConnexion.reqExec(req);

            //   Permet de lire la BDD
            MySqlDataReader reader = oCom.ExecuteReader();

            //   Parcour le nom des colonnes
            //   Rempli le DataTable avec le nom des colonnes
            for (int i = 0; i <= reader.FieldCount - 1; i++)
            {
                dt.Columns.Add(reader.GetName(i));
            }

            //   Parcour le DataRow qui permet de remplir le DtataTable
            while (reader.Read())
            {

                DataRow dr = dt.NewRow();

                for (int i = 0; i <= reader.FieldCount - 1; i++)
                {
                    dr[i] = reader.GetValue(i);
                }
                
                //   Ajoute la ligne récupéré et recommence la boucle si il y en a une autre à lire
                dt.Rows.Add(dr);
            }
            
            //   Copie le DataTable rempli dans le DataGridView
            dgv.DataSource = dt;
            reader.Close();
        }
        

        /// <summary>
        ///    Timer qui relance toutes les 10 secondes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            maConnexion.openConnection();
            majCR();
            majRB();

            maConnexion.closeConnection();
        }

    }
}
