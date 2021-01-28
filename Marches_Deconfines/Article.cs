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
    
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            this.Photos = new HashSet<Photo>();
            this.Paniers = new HashSet<Panier>();
        }
    
        public int articleId { get; set; }
        public string libelle { get; set; }
        public Nullable<int> Prix { get; set; }
        public Nullable<int> cantite { get; set; }
        public string articleDescreption { get; set; }
        public string etat { get; set; }
        public string photo { get; set; }
        public Nullable<int> categorieId { get; set; }
        public Nullable<int> utilisateurid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panier> Paniers { get; set; }
        public virtual Categorie Categorie { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
