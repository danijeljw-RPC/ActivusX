using System.ComponentModel.DataAnnotations;

namespace ActivusX.WebApp.Models.ViewModels;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Provide email address")]
    public string? Username { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Provide password")]
    public string? Password { get; set; }
}
