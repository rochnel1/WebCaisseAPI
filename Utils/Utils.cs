using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Objets100cLib;

namespace WebCaisseAPI.Utils
{
    public static class Utils
    {
        public static string OuvertureFermetureBaseCpta(string path= @"C:\Bijou.mae", string login = "<Administrateur>", string mdp = "")
        {
            BSCPTAApplication100c BaseCpta = new BSCPTAApplication100c();
            if (OuvreBaseCpta(BaseCpta, path, login, mdp))
            {
                //return "Base comptable ouverte !";
                if (FermeBaseCpta(BaseCpta))
                    return "Base de données comptable ouverte et fermée !";
            }
            return "Erreur de connexion";

        }
        static Boolean OuvreBaseCpta(BSCPTAApplication100c BaseCpta, String NomBaseCpta, String Utilisateur = "<Administrateur>", String MotDePasse = "")
        {
            try
            {
                BaseCpta.Name = NomBaseCpta;
                BaseCpta.Loggable.UserName = Utilisateur;
                BaseCpta.Loggable.UserPwd = MotDePasse;
                BaseCpta.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur en ouverture de base comptable : {0}", ex.Message);
                return false;
            }
        }

        static Boolean FermeBaseCpta(BSCPTAApplication100c BaseCpta)
        {
            try
            {
                BaseCpta.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur en fermeture de base comptable : {0}", ex.Message);
                return false;
            }
        }
    }
}
