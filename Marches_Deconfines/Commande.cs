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
    
    public partial class Commande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commande()
        {
            this.Paniers = new HashSet<Panier>();
            this.Paymments = new HashSet<Paymment>();
        }
    
        public int commandeId { get; set; }
        public Nullable<System.DateTime> dateCommande { get; set; }
        public Nullable<System.DateTime> dateLaivraison { get; set; }
        public string lieuLaivraison { get; set; }
        public Nullable<int> categorieId { get; set; }
        public Nullable<int> utilisateurId { get; set; }
        public Nullable<int> lieuLivraisonId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panier> Paniers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paymment> Paymments { get; set; }
        public virtual LieuLivraison LieuLivraison { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}