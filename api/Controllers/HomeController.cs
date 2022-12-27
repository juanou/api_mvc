using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;

namespace Api.Controllers
{
    // Clase de controlador MVC
    public class HomeController : Controller
    {
        // Acción del controlador para mostrar el ID
        public async Task<ActionResult> Index()
        {
            // Crea una nueva instancia de HttpClient
            using (var client = new HttpClient())
            {
                // Establece la dirección URL de la API
                client.BaseAddress = new Uri("https://rickandmortyapi.com/api");

                // Envía una solicitud GET a la API
                HttpResponseMessage response = await client.GetAsync("https://rickandmortyapi.com/api/character/2");

                // Si la solicitud es exitosa, lee el contenido de la respuesta
                if (response.IsSuccessStatusCode)
                {
                    string id = await response.Content.ReadAsStringAsync();
                    ViewBag.Id = id;
                }
            }

            // Muestra la vista
            return View();
        }
    }
}