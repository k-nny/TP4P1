using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace TP4P1.Models.EntityFramework;

[PrimaryKey("utl_id", "flm_id")]
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
    public int Note
    {
        get { return Note; }
        set { 
            if (value < 0 || value>5) throw new ArgumentOutOfRangeException("La note doit être comprise entre 0 et 5");
            Note = value; 
            }
    }

    [ForeignKey("UtilisateurId")]
    [InverseProperty(nameof(Utilisateur.NotesUtilisateur))]
    public virtual Utilisateur? UtilisateurNotant { get; set; }

    [ForeignKey("FilmId")]
    [InverseProperty(nameof(Film.NotesFilm))]
    public virtual Film? FilmNote { get; set; }
}