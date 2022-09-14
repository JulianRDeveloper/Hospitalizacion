using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class ListModel : PageModel
    {
        private string[] personas= {"Pepito", "Manuel", "Jose"};
        public List<string> ListaPersonas {get; set;}
        public void OnGet()
        {
            ListaPersonas = new List<string>();
            ListaPersonas.AddRange(personas);
    }
}
}
