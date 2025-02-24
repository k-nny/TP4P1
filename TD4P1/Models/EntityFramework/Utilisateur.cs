using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;

namespace TD4P1.Models.EntityFramework;

[Table("t_e_utilisateur_utl")]
[Index(nameof(Mail), IsUnique = true)]
public partial class Utilisateur
{
    [Key]
    [Column("utl_id")]
    public int UtilisateurId { get; set; }

    [Column("utl_nom")]
    [StringLength(50)]
    public string? Nom { get; set; }

    [Column("utl_prenom")]
    [StringLength(100)]
    public string? Prenom { get; set; }

    [Column("utl_mobile", TypeName = "char(10)")]
    [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Le téléphone doit être composé de 10 chiffres")]
    public string? Mobile { get; set; }

    [Required]
    [Column("utl_mail")]
    [EmailAddress(ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
    public string? Mail { get; set; }

    [Required]
    [Column("utl_pwd")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,20}$", ErrorMessage ="Le mot de passe doit contenir entre 12 et 20 caractères avec au moins 1 lettre majuscule, 1 chiffre et 1 caractère spécial")]
    [StringLength(64), NotNull]
    public string? Pwd { get; set; }

    [Column("utl_rue")]
    [StringLength(200)]
    public string? Rue { get; set; }

    [Column("utl_cp", TypeName ="char(5)")]
    [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres")]
    public string? CodePostal { get; set; }

    [Column("utl_ville")]
    [StringLength(50)]
    public string? Ville { get; set; }

    [Column("utl_pays")]
    [StringLength(50)]
    public string? Pays { get; set; }

    [Column("utl_latitude")]
    public float? Latitude { get; set; }

    [Column("utl_longitude")]
    public float? Longitude { get; set; }

    [Column("utl_datecreation", TypeName = "date")]
    public DateTime DateCreation { get; set; }

    [InverseProperty(nameof(Notation.UtilisateurNotant))]
    public virtual ICollection<Notation> NotesUtilisateur { get; set; } = new List<Notation>();
}