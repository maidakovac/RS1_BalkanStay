using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;

[ApiController]
[Route("[controller]/[action]")]
public class ContactController : ControllerBase
{
    private readonly ApplicationDbContext _DbContext;

    public ContactController(ApplicationDbContext _DbContext)
    {

        this._DbContext = _DbContext;
    }
    [HttpGet]
    public IActionResult GetMessages()
    {
        var messages = _DbContext.ContactMessages.ToList();
        return Ok(messages);
    }

    [HttpPost]
    public IActionResult SendMessage([FromBody] ContactFormDto formData)
    {
        if (formData == null || string.IsNullOrWhiteSpace(formData.Name) ||
            string.IsNullOrWhiteSpace(formData.Email) || string.IsNullOrWhiteSpace(formData.Message))
        {
            return BadRequest(new { error = "All fields are required" });
        }

        var message = new ContactMessage
        {
            Name = formData.Name,
            Email = formData.Email,
            Country = formData.Country,
            Message = formData.Message
        };

        _DbContext.ContactMessages.Add(message);
        _DbContext.SaveChanges(); 

        return Ok(new { success = "Message saved!" });
    }

   
}

public class ContactFormDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Message { get; set; }
}
