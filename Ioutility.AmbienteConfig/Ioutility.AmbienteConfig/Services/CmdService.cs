using System.Diagnostics;

namespace Ioutility.AmbienteConfig.Services
{
    public class CmdService : IDisposable
    {
        private readonly Process _cmd;
        private bool _jaNavegouParaPastaComRepositorios = false;
        public CmdService()
        {
            _cmd = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            _cmd.StartInfo = info;
            _cmd.Start();
        }

        public void ExecutarComando(string comando)
        {
            _cmd.StandardInput.WriteLineAsync(comando).Wait();            

        }

        public void NavegarParaPastaComRepositorios()
        {
            if (_jaNavegouParaPastaComRepositorios) throw new Exception("Não deve navegar para pasta de reposotorios mais de uma vez. Caso seja necessario navegar entre pastas, navegue de forma manual com o metodo executar comando.");

            _jaNavegouParaPastaComRepositorios = true;
            ExecutarComando("cd ../../../../../../");
        }
        public void Dispose()
        {
            _cmd.StandardInput.Flush();
            _cmd.StandardInput.Close();
        }
    }
}
 