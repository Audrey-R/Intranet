using System;
using System.Collections.Generic;
using System.Linq;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Areas.Composants.Models.Operations ;
using Intranet.Models;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Medias
{
    public class DalMedia 
    {
        private BddContext bdd;

        public DalMedia()
        {
            bdd = new BddContext();
        }

        public void Creer(string titre, string description, string chemin)
        {
            // Recherche de la fraction "Média"
            Fraction rechercheMediaDansFractions = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains("Média"));
           
            //Création de l'élément de type Média
            Element_Communautaire element = bdd.ElementsCommunautaires.Add(new Element_Communautaire { Etat = Element.Etats.Publié });
            
            if (rechercheMediaDansFractions == null)
            {
                // Création de la fraction "Média"
                Fraction fraction = bdd.Fractions.Add(new Fraction { Libelle = "Média", Element = element });
                bdd.SaveChanges();
            }

            // Nouvelle recherche de la fraction "Média"
            Fraction fractionMediaTrouvee = bdd.Fractions.FirstOrDefault(fraction => fraction.Libelle.Contains("Média"));

            if (rechercheMediaDansFractions != null || fractionMediaTrouvee != null)
            {
                element.Fraction = fractionMediaTrouvee;
                bdd.Medias.Add(new Media { Titre = titre, Description = description, Chemin = chemin, Element = element});
                bdd.Operations.Add(new Operation { Element = element, Type_Operation = Operation.Operations.Création });
                bdd.SaveChanges();
            }
        }

        public void Modifier(int id, string titre, string description, string chemin)
        {
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.Element.IdElement == id);
            if (mediaTrouve != null)
            {
                mediaTrouve.Titre = titre;
                mediaTrouve.Description = description;
                mediaTrouve.Chemin = chemin;

                bdd.SaveChanges();
            }
        }

        public void Supprimer(int id)
        {
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.Element.IdElement == id);
            if (mediaTrouve != null)
            {
                bdd.Medias.Remove(mediaTrouve);
                bdd.Elements.Remove(mediaTrouve.Element);
                bdd.SaveChanges();
            }
        }

        public List<Media> Lister()
        {
            return bdd.Medias.ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}