using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_2024_25.API.Data.Models.Auth;

public class MyAuthenticationToken
{
    [Key]
    public int ID { get; set; }

    public required string Value { get; set; }

    public string IpAddress { get; set; } = string.Empty;

    public DateTime RecordedAt { get; set; } 

    [ForeignKey(nameof(Account))]
    public int AccountId { get; set; }

    public Account? Account { get; set; } 
}
