using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class SVsModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;

        [BindProperty]
        public Paciente Paciente {get;set;}
        public IEnumerable<SignoVital> SVs {get;set;}
        public SVsModel(IRepositorioPaciente repositorio_Paciente){
            _repoPaciente=repositorio_Paciente;
        }

        public void OnGet(int? Id)
        {
            if(Id.HasValue){
                Paciente= _repoPaciente.GetPaciente(Id.Value);
            }
            if(Paciente==null){
                RedirectToPage("../Shared/Error");
            }else{
                SVs= _repoPaciente.GetSVs(Id.Value);
            }
            //return Page();           
        }

        //  public IActionResult OnPost(string findBar){
        //     //ListPacientes=_repoPaciente.GetAllPacientes();
        //     Console.WriteLine(findBar);
        //     FindedPacientes= _repoPaciente.FiltroNombres(findBar);
        //     return Page();
        // }
    }
}
