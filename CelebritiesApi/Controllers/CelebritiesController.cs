using CelebritiesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CelebritiesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelebritiesController : ControllerBase
    {
        private static readonly List<Celebrity> celebrities = new List<Celebrity>
        {
            new Celebrity { Id = 1, Name = "Tarkan", Profession = "Pop Müzik Sanatçısı" },
            new Celebrity { Id = 2, Name = "Sıla", Profession = "Pop Müzik Sanatçısı" },
            new Celebrity { Id = 3, Name = "Kenan İmirzalioğlu", Profession = "Oyuncu" },
            new Celebrity { Id = 4, Name = "Bergüzar Korel", Profession = "Oyuncu" }
        };

        // GET: api/celebrities
        [HttpGet]
        public ActionResult<IEnumerable<Celebrity>> Get()
        {
            return Ok(celebrities);
        }

        // GET: api/celebrities/5
        [HttpGet("{id}")]
        public ActionResult<Celebrity> Get(int id)
        {
            var celebrity = celebrities.FirstOrDefault(c => c.Id == id);
            if (celebrity == null)
            {
                return NotFound();
            }
            return Ok(celebrity);
        }

        // POST: api/celebrities
        [HttpPost]
        public ActionResult<Celebrity> Post([FromBody] Celebrity celebrity)
        {
            celebrity.Id = celebrities.Max(c => c.Id) + 1; // Yeni ID oluştur
            celebrities.Add(celebrity);
            return CreatedAtAction(nameof(Get), new { id = celebrity.Id }, celebrity);
        }

        // PUT: api/celebrities/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Celebrity updatedCelebrity)
        {
            var celebrity = celebrities.FirstOrDefault(c => c.Id == id);
            if (celebrity == null)
            {
                return NotFound();
            }
            celebrity.Name = updatedCelebrity.Name;
            celebrity.Profession = updatedCelebrity.Profession;
            return NoContent();
        }

        // DELETE: api/celebrities/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var celebrity = celebrities.FirstOrDefault(c => c.Id == id);
            if (celebrity == null)
            {
                return NotFound();
            }
            celebrities.Remove(celebrity);
            return NoContent();
        }
    }
}


// Kod Açıklamaları : 
//CelebritiesController sınıfı, ControllerBase sınıfından türetilmiştir ve API isteklerini işler.

// [ApiController]: Bu öznitelik, API özelliklerini etkinleştirir, örneğin model doğrulama ve otomatik olarak HTTP durum kodları döndürür.

// [Route("api/[controller]")]: Bu öznitelik, denetleyicinin URL yolunu belirtir. [controller] kısmı, denetleyicinin adının (Celebrities kısmı) yolun bir parçası olacağını belirtir.

// Get(): Tüm ünlü kişileri listeler.

// Get(int id): Belirli bir ID'ye sahip ünlüyü getirir.

// Post([FromBody] Celebrity celebrity): Yeni bir ünlü kişi ekler.

// Put(int id, [FromBody] Celebrity updatedCelebrity): Mevcut bir ünlüyü günceller.

// Delete(int id): Belirli bir ID'ye sahip ünlüyü siler.