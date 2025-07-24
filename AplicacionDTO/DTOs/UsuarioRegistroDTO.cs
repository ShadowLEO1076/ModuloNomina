using System.ComponentModel.DataAnnotations;

public class UsuarioRegistroDTO
{
    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(20)]
    public string Cedula { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Contraseña { get; set; }

    [Required]
    [StringLength(50)]
    public string Rol { get; set; }
}