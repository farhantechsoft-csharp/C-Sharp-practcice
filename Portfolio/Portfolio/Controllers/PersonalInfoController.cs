using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Entities;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonalInfoController(ApplicationDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var personalInfo = await _context.PersonalInfos.ToListAsync();


            return View(personalInfo);
        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(PersonalinfoVm personalinfo)
        {
            if (ModelState.IsValid)
            {
                var entity = new PersonalInfo();
                entity.FullName = personalinfo.FullName;
                entity.Title = personalinfo.Title;
                entity.Email = personalinfo.Email;
                entity.Phone = personalinfo.Phone;
                entity.Address = personalinfo.Address;
                entity.Website = personalinfo.Website;
                entity.LinkedIn = personalinfo.LinkedIn;
                entity.GitHub = personalinfo.GitHub;
                entity.Bio = personalinfo.Bio;
                


                if (personalinfo.profilephoto != null)
                {
                    string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uplaods");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string filename = Guid.NewGuid().ToString() + "_"+Path.GetExtension(personalinfo.profilephoto.FileName);
                    string filePath = Path.Combine(folder, filename);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await personalinfo.profilephoto.CopyToAsync(stream);
                    }
                    entity.ProfileImageUrl = filename;
                }
            }
            //_context.PersonalInfos.Add(entity);
            await _context.SaveChangesAsync();
            return View(personalinfo);
        }

    }

}
