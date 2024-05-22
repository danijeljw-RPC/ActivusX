using System.ComponentModel.DataAnnotations;

namespace ActivusX.Shared.Models.MSAD;

public class ActiveDirectoryUser
{
    [Key]
    public Guid Id { get; set; } // Unique identifier

    [Required]
    [MaxLength(256)]
    public string UserName { get; set; } = null!; // samAccountName

    [Required]
    [MaxLength(256)]
    public string DisplayName { get; set; } = null!; // displayName

    [MaxLength(256)]
    public string? GivenName { get; set; } // givenName

    [MaxLength(256)]
    public string? Surname { get; set; } // sn

    [MaxLength(256)]
    [EmailAddress]
    public string? Email { get; set; } // mail

    [MaxLength(50)]
    public string? PhoneNumber { get; set; } // telephoneNumber

    [MaxLength(256)]
    public string? Department { get; set; } // department

    [MaxLength(256)]
    public string? Title { get; set; } // title

    [MaxLength(256)]
    public string? Manager { get; set; } // manager

    [MaxLength(256)]
    public string? DistinguishedName { get; set; } // distinguishedName

    [Required]
    [MaxLength(256)]
    public string UserPrincipalName { get; set; } = null!; // userPrincipalName (UPN)

    public bool AccountEnabled { get; set; } // userAccountControl (enabled/disabled status)

    [MaxLength(50)]
    public string? EmployeeId { get; set; } // employeeId

    [MaxLength(50)]
    public string? Office { get; set; } // physicalDeliveryOfficeName

    [MaxLength(256)]
    public string? City { get; set; } // l (city)

    [MaxLength(256)]
    public string? State { get; set; } // st (state)

    [MaxLength(256)]
    public string? Country { get; set; } // c (country)

    [MaxLength(256)]
    public string? PostalCode { get; set; } // postalCode
}

