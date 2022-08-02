using Ioutility.AmbienteConfig.Domain;
using Ioutility.AmbienteConfig.DTOs;
using Newtonsoft.Json;
using Pulsati.Core.Domain.Helpers;

namespace Ioutility.AmbienteConfig.Repositorys
{
    public class Repository
    {

        public IEnumerable<GitHubRepositorio> Buscar(string palavraChave = "")
        {
            var repositorios = ObterGitHubRepositorys();
            return repositorios.Where(gitHubRepo => gitHubRepo.NomeRepositorio.Contains(palavraChave));
        }

        public IEnumerable<GitHubRepositorio> BuscarComDocckerfile(string palavraChave = "")
        {
            var repositorios = Buscar(palavraChave) ;
            return repositorios.Where(repo => repo.PossuiDockerfile);
        }

        private IEnumerable<GitHubRepositorio> ObterGitHubRepositorys()
        {
            string jsonRepositorys = ObterConteudoJsonRepository();
            var repositorys = ConverterJsonRepositoryParaDomain(jsonRepositorys);
            return repositorys;
        }
        private static IEnumerable<GitHubRepositorio> ConverterJsonRepositoryParaDomain(string jsonRepositorys)
        {
            IEnumerable<GitHubRepositorioDTO> dtos;
            try
            {
                dtos = JsonConvert.DeserializeObject<IEnumerable<GitHubRepositorioDTO>>(jsonRepositorys)!.ToList();
            }
            catch (Exception erro)
            {
                throw new Exception("não foi possivel converter o conteudo do arquivo JSON em lista de GitHubRepositoryDTO. Conteudo do arquivo: " + jsonRepositorys, erro);
            }

            return dtos.Select(dto => new GitHubRepositorio(dto.NomeRepositorio, dto.PossuiDockerfile, dto.EnderecoDockerfile)).ToList(); 
        }
        private static string ObterConteudoJsonRepository()
        {
            string jsonRepositorys;
            try
            {
                jsonRepositorys = ArquivoHelper.LerArquivo("Repositorys/repositorys.json", false);
            }
            catch (Exception erro)
            {
                throw new Exception("não foi possivel ler o arquivo de repositorys", erro);
            }

            return jsonRepositorys;
        }
    }
}
