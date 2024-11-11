using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace PetShop.Controllers
{
    public class AnimalController : Controller
    {
        private readonly PetShopContext _context;

        public AnimalController(PetShopContext context)
        {
            _context = context;
        }

        // Method to fetch breed list from API
        public async Task<List<SelectListItem>> GetDogBreedsAsync()
        {
            var breedList = new List<SelectListItem>();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetStringAsync("https://dog.ceo/api/breeds/list/all");

                    if (response != null)
                    {
                        var jsonResponse = JsonDocument.Parse(response);
                        var message = jsonResponse.RootElement.GetProperty("message");

                        foreach (var breed in message.EnumerateObject())
                        {
                            string breedName = breed.Name;

                            if (breed.Value.GetArrayLength() > 0)
                            {
                                foreach (var subBreed in breed.Value.EnumerateArray())
                                {
                                    string fullBreedName = $"{subBreed} {breedName}";
                                    breedList.Add(new SelectListItem { Text = fullBreedName, Value = fullBreedName });
                                }
                            }
                            else
                            {
                                breedList.Add(new SelectListItem { Text = breedName, Value = breedName });
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data was received from the API.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching breed list: {ex.Message}");
                }
            }

            return breedList;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var petshopContext = _context.Animais.Include(m => m.Clientes);
            return View(await _context.Animais.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animais
                .Include(m => m.Clientes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Nome", animal.ClientesId);
            return View(animal);
        }

        // GET: Animal/Create
        public async Task<IActionResult> Create()
        {
            ViewData["BreedList"] = await GetDogBreedsAsync();
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,tipo,raca,nomeAnimal,Idade,ClientesId")] Animais animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreedList"] = await GetDogBreedsAsync();
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Nome", animal.ClientesId);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animais.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            ViewData["BreedList"] = await GetDogBreedsAsync();
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Nome", animal.ClientesId);
            return View(animal);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,tipo,raca,nomeAnimal,Idade,ClientesId")] Animais animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["BreedList"] = await GetDogBreedsAsync();
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Nome", animal.ClientesId);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animais
                .Include(m => m.Clientes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animais.FindAsync(id);
            if (animal != null)
            {
                _context.Animais.Remove(animal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animais.Any(e => e.Id == id);
        }
    }
}
