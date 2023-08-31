using Objets100cLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCaisseAPI.Utils
{
    public class OpCompta
    {
        public string Comptenature { get; set; }
        public string Comptecaisse { get; set; }
        public string Libelle { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public string Etat { get; set; }
        public string Sens { get; set; }
        public int Id { get; set; }
        public DateTime dateOperation { get; set; }
        public string journal { get; set; }
    }
    public class importDataToPnm
    {
            // Objet base comptable
            //private static BSCPTAApplication100c oCpta;
            // Emplacement du fichier comptable
            private static string sPathMae = "C:\\Bijou.mae";

            public static bool GenerationEcritureCpta(IPMEncoder mProcessEncoder, BSCPTAApplication100c oCpta)
            {
                try
                {
                    if (oCpta != null ){
                        if(mProcessEncoder != null){
                            if (!mProcessEncoder.CanProcess) RecupError(mProcessEncoder);
                            else mProcessEncoder.Process();
                            return true;
                        }else return false;
                    }else return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                    return false;
                }
                //finally { CloseBase(oCpta); }
            }

            public static IPMEncoder ReglementFacture(OpCompta o, BSCPTAApplication100c oCPTA)
            {
                IBOEcriture3 mEcTiers, mEcCompte;
                double dMnt = 10000;
                try
                {
                    //généralité sur l'écriture
                    IPMEncoder mP = oCPTA.CreateProcess_Encoder();
                // Affectation des propriétés globales
                // Journal
                mP.bAnalytiqueAuto = false;
                    // Date
                    mP.Date = new DateTime(2020, 3, 22);
                    mP.Journal = oCPTA.FactoryJournal.ReadNumero("BEU");
                    // Numéro de pièce
                    mP.EC_Piece = mP.Journal.get_NextEC_Piece(new DateTime(2020, 3, 22));  //[new DateTime(2020, 3, 22)];
                mP.EC_Reference = "";
                mP.EC_RefPiece = "";
                

                    // Intitulé
                    

                    //ligne 1
                    // Création de l'écriture tiers
                    mEcTiers = (IBOEcriture3)mP.FactoryEcritureIn.Create();
                    // Affectation compte général
                    mEcTiers.CompteG = oCPTA.FactoryCompteG.ReadNumero("4010000");
                    // Affectation compte tiers
                    mEcTiers.Tiers = oCPTA.FactoryTiers.ReadNumero("HOLDI");
                mEcTiers.EC_Intitule = "Reglement Facture";
                // Affectation sens de l'écriture
                mEcTiers.EC_Sens = EcritureSensType.EcritureSensTypeDebit;
                    // Affectation du montant
                    mEcTiers.EC_Montant = dMnt;
                    // Ajout de l'écriture au processus (écriture mémoire non persistante)
                    mEcTiers.WriteDefault();

                    //ligne 2
                    // Création de l'écriture générale
                    mEcCompte = (IBOEcriture3)mP.FactoryEcritureIn.Create();
                    // Affectation compte général
                    mEcCompte.CompteG = oCPTA.FactoryCompteG.ReadNumero("5120");
                    // Affectation sens de l'écriture
                    mEcCompte.EC_Sens = EcritureSensType.EcritureSensTypeCredit;
                    // Affectation du montant
                    mEcCompte.EC_Montant = dMnt;
                    // Ajout de l'écriture au processus (écriture mémoire non persistante)
                    mEcCompte.WriteDefault();

                    return mP;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                    return null;
                }
            }
        public static IPMEncoder EcriturePiece(OpCompta o, BSCPTAApplication100c oCPTA)
        {
            try
            {
                //généralité sur l'écriture
                IPMEncoder mP = oCPTA.CreateProcess_Encoder();
                // Affectation des propriétés globales
                // Journal
                mP.bAnalytiqueAuto = false;
                // Date
                mP.Date = o.dateOperation;
                mP.Journal = oCPTA.FactoryJournal.ReadNumero(o.journal);
                // Numéro de pièce
                mP.EC_Piece = mP.Journal.get_NextEC_Piece(o.dateOperation);  //[new DateTime(2020, 3, 22)];
                mP.EC_Reference = "";
                mP.EC_RefPiece = "";



                return mP;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return null;
            }
        }

        public static IPMEncoder EcritureLigne(OpCompta o, IPMEncoder mP, BSCPTAApplication100c oCPTA)
        {
            IBOEcriture3 ecl1, ecl2;
            try
            {
                //ligne 1
                // Création de l'écriture tiers
                ecl1 = (IBOEcriture3)mP.FactoryEcritureIn.Create();
                // Affectation compte général
                ecl1.CompteG = oCPTA.FactoryCompteG.ReadNumero(o.Comptenature);
                // Affectation compte tiers
                //mEcTiers.Tiers = oCPTA.FactoryTiers.ReadNumero("HOLDI");
                ecl1.EC_Intitule = o.Libelle;
                // Affectation sens de l'écriture
                ecl1.EC_Sens = o.Sens == "Encaissement" ? EcritureSensType.EcritureSensTypeDebit : EcritureSensType.EcritureSensTypeCredit;
                // Affectation du montant
                ecl1.EC_Montant = (double)o.Credit;
                // Ajout de l'écriture au processus (écriture mémoire non persistante)
                ecl1.WriteDefault();

                //ligne 2
                // Création de l'écriture tiers
                ecl2 = (IBOEcriture3)mP.FactoryEcritureIn.Create();
                // Affectation compte général
                ecl2.CompteG = oCPTA.FactoryCompteG.ReadNumero(o.Comptecaisse);
                // Affectation compte tiers
                //mEcTiers.Tiers = oCPTA.FactoryTiers.ReadNumero("HOLDI");
                ecl2.EC_Intitule = o.Libelle;
                // Affectation sens de l'écriture
                ecl2.EC_Sens = o.Sens == "Encaissement" ? EcritureSensType.EcritureSensTypeCredit : EcritureSensType.EcritureSensTypeDebit;
                // Affectation du montant
                ecl2.EC_Montant = (double)o.Credit;
                // Ajout de l'écriture au processus (écriture mémoire non persistante)
                ecl2.WriteDefault();

                return mP;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return null;
            }
        }

        public static void RecupError(IPMEncoder mP)
            {
                try
                {
                /*
                    // Boucle sur les erreurs contenues dans la collection
                    for (int i = 1; i <= mP.Errors.Count; i++)
                    {
                        // Récupération des éléments erreurs
                        IFailInfo iFail = mP.Errors.Item(i);

                        // Récupération du numéro d'erreur, de l'indice et de la description de l'erreur
                        Console.WriteLine("Code Erreur : " + iFail.ErrorCode + " Indice : " + iFail.Indice +
                            " Description : " + iFail.Text);
                    }*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            public static BSCPTAApplication100c OpenBase(string sUid = "<Administrateur>", string sPwd = "")
            {
                try
                {
                BSCPTAApplication100c BaseCpta = new BSCPTAApplication100c();
                // Affectation de l'emplacement du fichier comptable
                BaseCpta.Name = sPathMae;
                    // Affectation du code utilisateur
                    BaseCpta.Loggable.UserName = sUid;
                    // Affectation du mot de passe
                    BaseCpta.Loggable.UserPwd = sPwd;
                    // Ouverture de la base comptable
                    BaseCpta.Open();
                    return BaseCpta;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ouverture du fichier mae : " + ex.Message);
                    return null;
                }
            }

            public static bool CloseBase(BSCPTAApplication100c BaseCpta)
            {
                try
                {
                    // Si la base est ouverte, alors fermeture de la base
                    if (BaseCpta.IsOpen) BaseCpta.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la fermeture de la base : " + ex.Message);
                    return false;
                }
            }
        }
    
}
