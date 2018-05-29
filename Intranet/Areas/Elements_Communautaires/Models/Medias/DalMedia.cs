using System;
using System.Collections.Generic;
using System.Linq;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
using Intranet.Areas.Elements_Generaux.Models.Fractions;
using Intranet.Models;

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
            Fraction fractionComposantCommunautaireTrouvee = bdd.Fractions.First(fraction => fraction.Libelle == "Média");
            // Création de l'élément de type Média, puis du média
            if (fractionComposantCommunautaireTrouvee != null)
            {
                Element element = bdd.Elements.Add(new Element { ElementCommunautaire = true, ElementGeneral = false });
                bdd.Medias.Add(new Media { Titre = titre, Description = description, Chemin = chemin, Element = element, Fraction = fractionComposantCommunautaireTrouvee });
                bdd.SaveChanges();
            }
        }

        public void Modifier(int id, string titre, string description, string chemin)
        {
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.Element.Id == id);
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
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.Element.Id == id);
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