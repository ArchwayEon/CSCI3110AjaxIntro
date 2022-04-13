using System.ComponentModel.DataAnnotations;

namespace CSCI3110AjaxIntro.Models.Entities;

public class User
{
    [Key, StringLength(20)]
    public string UserName { get; set; } = String.Empty;
    [StringLength(20)]
    public string RoleName { get; set; } = String.Empty;
    [StringLength(20)]
    public string Password { get; set; } = String.Empty;
}

