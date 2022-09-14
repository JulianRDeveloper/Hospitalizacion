using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class MedicosModel : PageModel
    {

        private readonly IRepositorioMedico _repoMedico;
        public IEnumerable<Medico> ListMedicos {get;set;}
        public MedicosModel(IRepositorioMedico repositorio_Medico){
            _repoMedico=repositorio_Medico;
        }

        public void OnPost(){
            ListMedicos=_repoMedico.GetAllMedicos();
        }
        public void OnGet()
        {
            ListMedicos=_repoMedico.GetAllMedicos();
        }
    }
}
