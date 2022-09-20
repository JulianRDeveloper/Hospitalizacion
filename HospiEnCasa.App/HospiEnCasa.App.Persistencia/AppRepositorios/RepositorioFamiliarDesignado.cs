using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioFamiliarDesignado : IRepositorioFamiliarDesignado
    {
        // <summary>
        // Referencia al contexto del paciente
        // </summary>
        private readonly AppContext _appContext;
        // <summary>
        // Metodo constructor que utiliza
        // Inyeccion de dependencias para indicar el contexto a utilizar
        // </summary>
        // <param name="appContext"></param>//
        public RepositorioFamiliarDesignado(AppContext appContext){
            _appContext=appContext;
        }
        
        FamiliarDesignado IRepositorioFamiliarDesignado.AddFamiliar(FamiliarDesignado familiar)
        {
            var FamiliarAdicionado= _appContext.FamiliaresDesignados.Add(familiar);
            _appContext.SaveChanges();
            return FamiliarAdicionado.Entity; 
        }

        void IRepositorioFamiliarDesignado.DeleteFamiliar(int idFamiliar) // ojo con la posicion del return
        {
            var familiarEncontrado= _appContext.FamiliaresDesignados.FirstOrDefault(p=>p.Id==idFamiliar);
            if(familiarEncontrado==null)
                return;
            _appContext.FamiliaresDesignados.Remove(familiarEncontrado); 
            _appContext.SaveChanges();
        }

        IEnumerable<FamiliarDesignado> IRepositorioFamiliarDesignado.GetAllFamiliares()
        {
            return (IEnumerable<FamiliarDesignado>)_appContext.FamiliaresDesignados;
        }

        FamiliarDesignado IRepositorioFamiliarDesignado.GetFamiliar(int Id)
        {
            return _appContext.FamiliaresDesignados.FirstOrDefault(p=> p.Id == Id);
        }

        FamiliarDesignado IRepositorioFamiliarDesignado.UpdateFamiliar(FamiliarDesignado familiar)
        {
            var familiarEncontrado = _appContext.FamiliaresDesignados.SingleOrDefault(p=> p.Id == familiar.Id);
            if(familiar!=null){
                familiarEncontrado.Nombre=familiar.Nombre;
                familiarEncontrado.Apellidos=familiar.Apellidos;
                familiarEncontrado.NumeroTelefono=familiar.NumeroTelefono;
                //familiarEncontrado.Genero=familiar.Genero;

                familiarEncontrado.Parentesco=familiar.Parentesco;
                familiarEncontrado.Correo=familiar.Correo;

                _appContext.SaveChanges();
            }
            return familiarEncontrado;
        }
    }
}