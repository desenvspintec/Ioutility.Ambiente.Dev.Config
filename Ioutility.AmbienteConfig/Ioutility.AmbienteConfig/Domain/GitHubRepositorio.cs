using Ioutility.AmbienteConfig.Repositorys;

namespace Ioutility.AmbienteConfig.Domain
{
    public class GitHubRepositorio
    {


        public GitHubRepositorio(string nomeRepositorio, bool possuiDockerfile, string? enderecoDockerfile, bool? configuradorDeAmbiente)
        {
            NomeRepositorio = nomeRepositorio;
            PossuiDockerfile = possuiDockerfile;
            EnderecoDockerfile = enderecoDockerfile;
            if (configuradorDeAmbiente.HasValue)
                ConfiguradorDeAmbiente = (bool)configuradorDeAmbiente;
        }
        public string NomeRepositorio { get; private set; }
        public bool PossuiDockerfile { get; private set; }
        public string? EnderecoDockerfile { get; private set; }
        public bool ConfiguradorDeAmbiente { get; set; }


        public bool DockerfilePossuiEndereco { get => EnderecoDockerfile != null && EnderecoDockerfile.Length > 0; }
        public string HttpUrl { get => Constante.ENDERECO_PARA_CLONE + NomeRepositorio ; }
        public string NomeImagem { get => NomeRepositorio.ToLower() ; }

        public string ObterComandoClone()
        {
            return "git clone " + HttpUrl;
        }

        public string ObterComandoDockerBuild()
        {
            return $"docker build -t {NomeImagem} .";
        }

    }
}
