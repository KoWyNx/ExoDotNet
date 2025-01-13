using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class ContactController : Controller
{
    private static List<Contact> _contacts = new List<Contact>
    {
        new Contact { Id = 1, Name = "Test", Email = "test@test.fr", Phone = "123456789" },
        new Contact { Id = 2, Name = "Super Test", Email = "supertest@supertest.fr", Phone = "987654321" }
    };

    public IActionResult GetAllContact()
    {
        ViewBag.Message = "Liste des contacts";

        ViewData["Count"] = _contacts.Count;

        return View(_contacts); 
    }

    public IActionResult GetOneContact(int id)
    {
        var contact = _contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null)
        {
            var firstContact = _contacts.FirstOrDefault(c => c.Id == 1);
            return View(firstContact);
        }

        ViewData["Title"] = $"Détails du contact {contact.Name}";

        ViewBag.Description = "Informations détaillées pour le contact sélectionné.";

        return View(contact); 
    }
    public IActionResult AddContact()
    {
        return View(); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddContact(Contact contact)
    {
        if (!ModelState.IsValid)
        {
            return View(contact); 
        }

        contact.Id = _contacts.Any() ? _contacts.Max(c => c.Id) + 1 : 1;
        _contacts.Add(contact);

        return RedirectToAction(nameof(GetAllContact)); 
    }
}