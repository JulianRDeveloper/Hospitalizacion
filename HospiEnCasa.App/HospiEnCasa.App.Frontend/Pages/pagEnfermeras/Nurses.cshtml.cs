using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class NursesModel : PageModel
    {
        private readonly IRepositorioEnfermera _repoNurses;
        public IEnumerable<Enfermera> ListNurses {get;set;}
        public NursesModel(IRepositorioEnfermera repositorio_Enfermera){
            _repoNurses=repositorio_Enfermera;
        }

        public void OnPost(){
            ListNurses=_repoNurses.GetAllEnfermeras();
        }
        public void OnGet()
        {
            ListNurses=_repoNurses.GetAllEnfermeras();
        }
    }
}
