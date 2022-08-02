using Ioutility.AmbienteConfig.Repositorys;

namespace Ioutility.AmbienteConfig.Helpers
{
    public class Helper
    {
        public string ObterComandoParaClonarRepositorio(string repositorio)
        {
            return Constante.ENDERECO_PARA_CLONE + repositorio + ".git";
        }
    }
}
