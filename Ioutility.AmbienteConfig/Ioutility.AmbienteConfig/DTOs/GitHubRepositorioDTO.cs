namespace Ioutility.AmbienteConfig.DTOs
{
    public class GitHubRepositorioDTO
    {
        public GitHubRepositorioDTO()
        {
            NomeRepositorio = "";
            PossuiDockerfile = false;
        }
        public string NomeRepositorio { get; set; }
        public bool PossuiDockerfile { get; set; }
        public string? EnderecoDockerfile { get; set; }

    }
}
