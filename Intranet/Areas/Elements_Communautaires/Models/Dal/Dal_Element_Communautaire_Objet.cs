using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using Intranet.Areas.Composants.Models;
using Intranet.Areas.Elements_Communautaires.ViewModels;
using Intranet.Areas.Elements_Generaux.Models;

namespace Intranet.Areas.Elements_Communautaires.Models.Dal
{
    public class Dal_Element_Communautaire_Objet : IDal_Element_Communautaire_Objet
    {
        private BddContext Bdd { get; set; }

        public Dal_Element_Communautaire_Objet()
        {
            Bdd = new BddContext();
        }

        public virtual IEnumerable<Entite> Lister<Entite>(Entite table)
            where Entite : Element_Communautaire_Objet
        {
            try
            {
                    return Bdd.Set<Entite>()
                            .Include(c => c.Element)
                            .Include(c => c.Categorie)
                            .Include(x => x.ListeMediasAssocies)
                            .Where(c => c.Element.Etat != Element.Etats.Masqué)
                            .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AjouterLog(Element_Communautaire_Objet element)
        {
            try
            {
                DbEntityEntry tuple = RetournerTupleElement(element);
                //Enregistrement de logs pour chaque propriété de l'élément communautaire
                foreach (string prop in tuple.CurrentValues.PropertyNames)
                {
                    DateTime dateLog = DateTime.UtcNow;
                    string nomEntite = element.GetType().Name;
                    string operation = "Crée";
                    string valeurActuelle = Convert.ToString(tuple.CurrentValues[prop]) ;
                    string valeurOriginale = string.Empty;
                    string clePrimaire = element.Element.Id.ToString();

                    Bdd.Logs.Add(new Log
                    {
                        Entite = nomEntite,
                        ClePrimaire = clePrimaire,
                        Propriete = prop,
                        AncienneValeur = valeurOriginale,
                        NouvelleValeur = valeurActuelle,
                        Operation = operation,
                        DateLog = dateLog
                    });
                    Bdd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Exception message = new Exception("L'enregistrement d'un log d'élément communautaire a échoué", ex);
                throw message;
            }
            Bdd.SaveChanges();
        }

        private void AjouterLog(Element_General_Objet element)
        {
            try
            {
                Bdd.Logs.Add(new Log
                {
                    Entite = element.GetType().Name,
                    AncienneValeur = string.Empty,
                    NouvelleValeur = element.Libelle,
                    DateLog = DateTime.UtcNow,
                    ClePrimaire = element.Element.Id.ToString(),
                    Operation = "Créé"
                });
            }
            catch (Exception ex)
            {
                Exception message = new Exception("L'enregistrement d'un log d'élément général a échoué", ex);
                throw message;
            }
            Bdd.SaveChanges();
        }

        public virtual void Creer<ViewModel>(ViewModel model, Element_Communautaire_Objet elementCommunautaireACreer) where ViewModel : Element_Communautaire_ViewModel
        {
            try
            {
                #region Cration des instances
                //Création d'une instance de l'élément à créer et du viewmodel (type dynamique)
                dynamic instanceElementACreer = Activator.CreateInstance(elementCommunautaireACreer.GetType());
                dynamic viewModelEntite = Activator.CreateInstance(model.GetType());
                viewModelEntite = model;
                #endregion

                #region Categorie associée à l'élément à créer
                //Gestion de la categorie liée à l'élément à créer, si elle existe
                int categorieId = viewModelEntite.Categorie;
                if (viewModelEntite.Categorie != null)
                {
                    Categorie categorieElementACreer = Bdd.Categories.Include(c => c.Element).Where(x => x.Element.Id == categorieId).FirstOrDefault();
                    instanceElementACreer.Categorie = categorieElementACreer;
                }
                #endregion

                #region Media à créer
                //Gestion du média lié, si il existe
                HttpPostedFileBase fichierMedia = viewModelEntite.FichierMedia;
                string urlMedia = viewModelEntite.UrlMedia;
                Media mediaCree = null;
                if (viewModelEntite.FichierMedia != null || viewModelEntite.UrlMedia != null)
                {
                    // Création de l'élément communautaire auquel sera liée le média
                    Element_Communautaire elementMedia = Bdd.ElementsCommunautaires.Add(new Element_Communautaire());
                    Media mediaACreer = new Media();
                    Fraction fractionMedia = Bdd.Fractions.FirstOrDefault(f => f.Libelle.Contains("Media"));
                    if (fractionMedia == null)
                    {
                        // Création de l'élément de type Fraction
                        Element_General elementFraction = Bdd.ElementsGeneraux.Add(new Element_General());
                        elementFraction.Fraction = null;

                        // Création de la fraction de l'élément à créer si elle n'existe pas
                        Fraction fractionACreer = Bdd.Fractions.Add(new Fraction { Libelle = "Media", Element = elementFraction });
                        fractionMedia = fractionACreer;

                        Bdd.SaveChanges();
                        // Enregistrement du log de création de la fraction
                        if (fractionACreer != null)
                            AjouterLog(fractionACreer);
                    }
                    elementMedia.Fraction = fractionMedia;
                    mediaACreer.Titre = viewModelEntite.TitreMedia;
                    mediaACreer.Description = viewModelEntite.DescriptionMedia;
                    mediaACreer.Element = elementMedia;
                    if(viewModelEntite.FichierMedia != null)
                    {
                        // Extraction du nom du fichier joint
                        var nomFichier = Path.GetFileName(viewModelEntite.FichierMedia.FileName);
                        // Enregistrement du fichier dans ~/Content/Img
                        string chemin = HttpContext.Current.Server.MapPath("~/Content/Img/"+ nomFichier);
                        viewModelEntite.FichierMedia.SaveAs(chemin);
                        Uri uri = new Uri(chemin);
                        string dernierSegmentChemin = uri.Segments.Last();
                        mediaACreer.Chemin = dernierSegmentChemin;
                    }
                    else if(viewModelEntite.UrlMedia != null)
                    {
                        //Enregistrement de l'URL du média dans la BDD
                        mediaACreer.Chemin = viewModelEntite.UrlMedia;
                    }

                    mediaCree = Bdd.Medias.Add(mediaACreer);
                    Bdd.SaveChanges();
                    // Enregistrement du log de création du média
                    if (mediaCree != null) { }
                        AjouterLog(mediaCree);
                }
                #endregion

                #region Fraction associée à l'élément communautaire à créer et à lier
                // Recherche de la fraction concernée par l'élément à créer 
                string libelleFractionElementACreer = instanceElementACreer.GetType().Name;
                Fraction fractionElementGeneral = Bdd.Fractions.FirstOrDefault(f => f.Libelle.Contains(libelleFractionElementACreer));

                if (fractionElementGeneral == null)
                {
                    // Création de l'élément de type Fraction
                    Element_General elementFraction = Bdd.ElementsGeneraux.Add(new Element_General());
                    elementFraction.Fraction = null;

                    // Création de la fraction de l'élément à créer si elle n'existe pas
                    Fraction fractionACreer = Bdd.Fractions.Add(new Fraction { Libelle = libelleFractionElementACreer, Element = elementFraction });
                    fractionElementGeneral = fractionACreer;

                    Bdd.SaveChanges();
                    // Enregistrement du log de création de la fraction
                    if (fractionACreer != null)
                        AjouterLog(fractionACreer);
                }
                #endregion
                
                #region Création de l'élément dans la BDD
                // Création de l'élément communautaire auquel sera liée le futur élément créée
                Element_Communautaire element = Bdd.ElementsCommunautaires.Add(new Element_Communautaire());
                element.Fraction = fractionElementGeneral;
                instanceElementACreer.Element = element;
                instanceElementACreer.Titre = viewModelEntite.Titre;
                instanceElementACreer.Description = viewModelEntite.Description;
                
                //Enregistrement de l'élément créé dans la BDD
                DbSet tableElementACreerEnBdd = Bdd.Set(instanceElementACreer.GetType());
                tableElementACreerEnBdd.Add(instanceElementACreer);
                Bdd.SaveChanges();

                DbEntityEntry tuple = RetournerTupleElement(instanceElementACreer);
                //Enregistrement de logs pour chaque propriété de l'élément communautaire
                foreach (string prop in tuple.CurrentValues.PropertyNames)
                {
                    string result = prop;
                    instanceElementACreer.GetType().GetProperty(prop).SetValue(instanceElementACreer, tuple.CurrentValues[prop], null);
                }
                Bdd.SaveChanges();

                // Enregistrement du log de création de l'élément
                if (instanceElementACreer != null)
                    AjouterLog((Element_Communautaire_Objet)instanceElementACreer);
                #endregion

                #region Association du média créé à l'élément créé
                int id = instanceElementACreer.Element.Id;
                Element_Communautaire_Objet elementCommunautaireALier = Bdd.Ressources.Single(u => u.Element.Id == id);
                if (mediaCree != null && instanceElementACreer != null)
                {
                    instanceElementACreer.ListeMediasAssocies.Add(mediaCree);
                    //Media mediaALier = Bdd.Medias.Single(u => u.Element.Id == mediaCree.Element.Id);
                    //elementCommunautaireALier.ListeMediasAssocies.Add(mediaALier);
                }
                #endregion

                #region association des thèmes à l'élément créé
                Element elementALier = Bdd.Elements.Single(u => u.Id == element.Id);
                foreach (var theme in model.ListeThemesSelectionnes)
                {
                    Theme themeALier = Bdd.Themes.Single(r => r.Id == theme.Id);
                    elementALier.ListeThemesAssocies.Add(themeALier);
                }
                Bdd.SaveChanges();
                #endregion
            }
            catch (Exception ex)
            {
                Exception message = new Exception("L'enregistrement a échoué", ex);
                throw message;
            }
        }

        public virtual void Modifier<ViewModel>(ViewModel model, Element_Communautaire_Objet elementCommunautaireAModifier) where ViewModel : Element_Communautaire_ViewModel
        {
            try
            {
                //Création d'une instance de l'élément à comparer (type dynamique)
                dynamic instanceElementAComparer = Activator.CreateInstance(elementCommunautaireAModifier.GetType());
                dynamic elementAModifier = RetournerElementCommunautaireTrouve(instanceElementAComparer, elementCommunautaireAModifier.Element.Id);
                
                if (elementAModifier != null)
                {
                    //Modification du titre
                    if (elementAModifier.Titre != model.Titre)
                        elementAModifier.Titre = model.Titre;
                        

                    //Modification de la description
                    if (elementAModifier.Description != model.Description)
                        elementAModifier.Description = model.Description;
                        

                    //Modification de la categorie
                    if (elementAModifier.Categorie.Id != model.Categorie)
                    {
                        Categorie CategorieViewModel = Bdd.Categories.FirstOrDefault(c => c.Id == model.Categorie);
                        elementAModifier.Categorie = CategorieViewModel;
                    }

                    //Modification des thèmes associés
                    if (elementAModifier.Element.ListeThemesAssocies != model.ListeThemesSelectionnes)
                    {
                        elementAModifier.Element.ListeThemesAssocies.Clear();
                        elementAModifier.Element.ListeThemesAssocies = model.ListeThemesSelectionnes;
                    }

                    //Modification des médias associés
                    foreach(Media media in model.ListeMediasAssocies)
                    {
                        //Modification des médias existants
                        if (elementAModifier.ListeMediasAssocies.Contains(media))
                        {
                            Media mediaTrouve = Bdd.Medias.FirstOrDefault(m=> m.Id == media.Id);
                            if (mediaTrouve.Titre != media.Titre)
                                mediaTrouve.Titre = media.Titre;

                            if (mediaTrouve.Description != media.Description)
                                mediaTrouve.Description = media.Description;

                            if (mediaTrouve.Chemin != media.Chemin)
                                mediaTrouve.Chemin = media.Chemin;
                        }

                        //Suppression d'un média

                        

                        //Ajout d'un média


                    }
                    //Récupération du tuple de l'élément visé dans sa table
                    DbEntityEntry tupleElement = RetournerTupleElement(elementAModifier);
                    //Récupération du tuple de l'élément lié dans sa table
                        Element elementLie = elementAModifier.Element;
                        Element elementLieTrouve = Bdd.Elements.FirstOrDefault(e=> e.Id == elementLie.Id);
                        DbEntityEntry tupleElementLieElement = Bdd.Entry(elementLieTrouve);
                        //Modification des états trackés dans la sauvegarde de données, pour chaque tuple
                        tupleElement.State = EntityState.Modified;
                        tupleElementLieElement.State = EntityState.Modified;

                        Bdd.SaveChanges();
                   // }
                }
            }
            catch (Exception ex)
            {
                Exception message = new Exception("La modification a échouée", ex);
                throw message;
            }
        }

        public virtual void Supprimer(Element_Communautaire_Objet element)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                Exception message = new Exception("La suppression a échouée", ex);
                throw message;
            }
        }

        public virtual void Masquer(Element_Communautaire_Objet element)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                Exception message = new Exception("Le masquage a échoué", ex);
                throw message;
            }
        }

        public Entite RetournerElementCommunautaireTrouve<Entite>(Entite element, int? id)
        where Entite : Element_Communautaire_Objet
        {
            if (element != null && id != null)
            {
                return Bdd.Set<Entite>()
                .Include(x => x.Element)
                .Include(x=> x.Categorie)
                .Include(x=> x.ListeMediasAssocies)
                .Where(x => x.Element.Id == id)
                .Select(x => x)
                .FirstOrDefault();
            }
            return null;
        }

        public Element RetournerElementLie(int? id)
        {
            return Bdd.Set<Element>()
                .Where(x => x.Id == id)
                .Select(x => x)
                .FirstOrDefault();
        }

        private DbEntityEntry<Entite> RetournerTupleElement<Entite>(Entite element)
            where Entite : Element_Communautaire_Objet
        {
            
            return Bdd.Entry(element);
        }

        private DbEntityEntry<Entite> RetournerTupleElementLieElement<Entite>(Entite element)
            where Entite : Element
        {
            return Bdd.Entry(element);
        }

        public void Dispose()
        {
            Bdd.Dispose();
        }
    }
}