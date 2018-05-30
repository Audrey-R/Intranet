using System;
using System.Collections.Generic;
using System.Linq;
using Intranet.Areas.Composants.Models.BDD;
using Intranet.Areas.Composants.Models.Elements;
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
                Element_Communautaire element = bdd.ComposantsCommunautaires.Add(new Element_Communautaire {  Fraction_Element = fractionComposantCommunautaireTrouvee });
                bdd.Medias.Add(new Media { Titre = titre, Description = description, Chemin = chemin, ElementCommunautaire = element });
                bdd.SaveChanges();
            }
        }

        public void Modifier(int id, string titre, string description, string chemin)
        {
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.ElementCommunautaire.Id == id);
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
            Media mediaTrouve = bdd.Medias.FirstOrDefault(media => media.ElementCommunautaire.Id == id);
            if (mediaTrouve != null)
            {
                bdd.Medias.Remove(mediaTrouve);
                bdd.Elements.Remove(mediaTrouve.ElementCommunautaire);
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