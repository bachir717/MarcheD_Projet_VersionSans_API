//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marches_Deconfines
{
    using System;
    using System.Collections.Generic;
    
    public partial class Panier
    {
        public int panierId { get; set; }
        public Nullable<double> prixArticle { get; set; }
        public Nullable<int> cantite { get; set; }
        public Nullable<int> commandeId { get; set; }
        public Nullable<int> articleId { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Commande Commande { get; set; }
    }
}