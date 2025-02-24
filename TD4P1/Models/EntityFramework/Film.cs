using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace TD4P1.Models.EntityFramework;

[Table("t_e_film_flm")]
[Index(nameof(Titre), IsUnique = false)]
public partial class Film
{
    [Key]
    [Column("flm_id")]
    public int FilmId { get; set; }

    [Column("flm_titre")]
    [StringLength(100), NotNull]
    public string? Titre { get; set; }

    [Column("flm_resume")]
    public string? Resume { get; set; }

    [Column("flm_datesortie", TypeName = "date")]
    public DateTime DateSortie { get; set; }

    [Column("flm_duree")]
    
    public decimal Duree { get; set; }

    [Column("flm_genre")]
    [StringLength(30)]
    public string? Genre { get; set; }

    [InverseProperty(nameof(Notation.FilmNote))]
    public virtual ICollection<Notation> NotesFilm { get; set; } = new List<Notation>();
}
