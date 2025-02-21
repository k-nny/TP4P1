using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace TP4P1.Models.EntityFramework;

[PrimaryKey("UtilisateurId", "FilmId")]
[Table("t_j_notation_not")]
public partial class Notation
{
    [Key]
    [Column("utl_id")]
    public int UtilisateurId { get; set; }

    [Key]
    [Column("flm_id")]
    public int FilmId { get; set; }

    [Column("not_note")]
    [Range(0, 5,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Note { get; set; }

    [ForeignKey("UtilisateurId")]
    [InverseProperty(nameof(Utilisateur.NotesUtilisateur))]
    public virtual Utilisateur? UtilisateurNotant { get; set; }

    [ForeignKey("FilmId")]
    [InverseProperty(nameof(Film.NotesFilm))]
    public virtual Film? FilmNote { get; set; }
}