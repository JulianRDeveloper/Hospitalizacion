using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class FamilaresModel : PageModel
    {

         private readonly IRepositorioFamiliarDesignado _repoFamiliares;
        public IEnumerable<FamiliarDesignado> ListFamiliares {get;set;}
        public FamilaresModel(IRepositorioFamiliarDesignado repositorio_Familiar){
            _repoFamiliares=repositorio_Familiar;
        }

        public void OnPost(){
            ListFamiliares=_repoFamiliares.GetAllFamiliares();
        }
        public void OnGet()
        {
            ListFamiliares=_repoFamiliares.GetAllFamiliares();
        }
    }
}
