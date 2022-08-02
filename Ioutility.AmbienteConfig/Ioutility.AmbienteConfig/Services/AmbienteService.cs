using Ioutility.AmbienteConfig.Repositorys;

namespace Ioutility.AmbienteConfig.Services
{
    public class AmbienteService : IDisposable
    {
        private readonly Repository _repository = new();
        private readonly CmdService _cmdService = new();

        public AmbienteService()
        {
            _cmdService.NavegarParaPastaComRepositorios();
        }

        public void ClonarRepositorios()
        {
            var repositorios = _repository.Buscar();
            foreach (var repositorio in repositorios)
            {
                _cmdService.ExecutarComando(repositorio.ObterComandoClone());
            }
        }
        public void PullRepositorios()
        {
            var repositorios = _repository.Buscar();
            foreach (var repositorio in repositorios)
            {
                _cmdService.ExecutarComando("cd " + repositorio.NomeRepositorio);
                _cmdService.ExecutarComando("git pull");
                _cmdService.ExecutarComando("cd ../");
            }
        }

        public void BuildarImagensDocker()
        {
            var repositorios = _repository.BuscarComDocckerfile();
            foreach (var repositorio in repositorios)
            {
                _cmdService.ExecutarComando("cd " + repositorio.NomeRepositorio);
                if (repositorio.DockerfilePossuiEndereco)
                    _cmdService.ExecutarComando("cd " + repositorio.EnderecoDockerfile);

                _cmdService.ExecutarComando(repositorio.ObterComandoDockerBuild());
                _cmdService.ExecutarComando("cd ../");
                if (repositorio.DockerfilePossuiEndereco)
                   _cmdService.ExecutarComando("cd ../");
            }

        }

        public void Dispose()
        {
            _cmdService.Dispose();
        }
    }
}
