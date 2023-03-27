using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models;

public class Propietarios
{
    [Key]//---> Para indicar que es clave primaria.
	[Display(Name = "Propietario#")]//---> Para que figure en la cabecera de la tabla con el nombre designado en "".
    public int? Id_Propietario { get; set; }

    [Required]//---> para indicar los campos obligatorios.
    public string? DNI { get; set; }

    [Required]
    public string? Apellido { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public string? Telefono { get; set; }

    [Required, EmailAddress]//---> EmailAddress: valida que se ingrese un email.
    public string? Email { get; set; }
}
