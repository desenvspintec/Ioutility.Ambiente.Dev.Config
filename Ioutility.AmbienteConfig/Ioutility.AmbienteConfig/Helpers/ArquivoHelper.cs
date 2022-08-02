namespace Pulsati.Core.Domain.Helpers
{
    public class ArquivoHelper
    {
        public const string NOME_PASTA_TEMPORARIA = "tmp/";
        public const string NOME_PASTA_LIXEIRA = "lixeira/";
        public static void Criar(string caminho, string conteudo)
        {
            var fileInfo = new FileInfo(caminho);
            if (fileInfo.Exists)
                fileInfo.Delete();
            if (!fileInfo.Directory!.Exists)
                fileInfo.Directory.Create();
            fileInfo.Create().Close();
            File.WriteAllText(caminho, conteudo);
        }
        /// <summary>
        /// Cria um novo arquivo, grava a matriz de bytes especificada no arquivo e fecha o arquivo. Se o arquivo de destino já existir, ele será substituído.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="nomeArquivoComDiretorio"></param>
        public static void ConvertBytesParaArquivo(byte[] bytes, string nomeArquivoComDiretorio)
        {
            Criar(nomeArquivoComDiretorio, "");
            File.WriteAllBytes(nomeArquivoComDiretorio, bytes);
        }

        public static void Excluir(string caminho)
        {
            var fileInfo = new FileInfo(caminho);
            fileInfo.Delete();
        }
        public static void Renomear(string caminho, string novoNome)
        {
            var fileInfo = new FileInfo(caminho);
            fileInfo.MoveTo(fileInfo.Directory + "/" + novoNome);
        }


        public static DirectoryInfo ObterDiretorioArquivosTemporario()
        {
            var diretorioApp = ObterDiretorioAppComArquivosStaticos();
            var diretorioTemporario = new DirectoryInfo(diretorioApp + "/" +NOME_PASTA_TEMPORARIA);
            if (!diretorioTemporario.Exists)
                diretorioTemporario.Create();

            return diretorioTemporario;
        }
        public static string ObterDiretorioApp()
        {
            return Directory.GetCurrentDirectory() + "/";
        }
        public static string ObterDiretorioAppComArquivosStaticos()
        {
            return ObterDiretorioApp() + ObterDiretorioArquivosStaticos();
        }

        public static string ObterDiretorioArquivosStaticos()
        {
            return "wwwroot/" ;
        }

        public static string LerArquivo(string diretorio, bool utilizarDiretorioBaseDeArquivosStaticos = true)
        {
            if (utilizarDiretorioBaseDeArquivosStaticos)
                diretorio = ObterDiretorioAppComArquivosStaticos() + diretorio;
            return File.ReadAllText(diretorio);
        }

        public static string LerArquivoDoDiretorioPadraoStatico(string diretorio)
        {
            return LerArquivo(diretorio);
        }
        public static string LerArquivoDoDiretorioPadraoJson(string arquivo)
        {
            return LerArquivoDoDiretorioPadraoStatico("jsons/" + arquivo);
        }
        public const string SEPARADOR_STRING_EM_LIST = ",,,";
    }
}
