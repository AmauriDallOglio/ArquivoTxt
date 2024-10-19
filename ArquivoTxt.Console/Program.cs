namespace ArquivoTxt.Console
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string caminhoPasta = @"C:\Amauri\GitHub\ArquivoTxt"; 
            string nomeArquivo = "logExecucao.txt"; 
            string caminhoArquivo = Path.Combine(caminhoPasta, nomeArquivo); 

            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }

            while (true) 
            {
                Console.WriteLine("Digite o texto que deseja salvar em um arquivo .txt (ou digite 'Sair' para terminar):");
                string texto = Console.ReadLine();

                if (texto.Equals("Sair", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                string dataHoraAtual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string linhaParaSalvar = $"{dataHoraAtual} - {texto}{Environment.NewLine}";

                try
                {
                    File.AppendAllText(caminhoArquivo, linhaParaSalvar);
                    Console.WriteLine($"Texto salvo com sucesso em {caminhoArquivo}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao salvar o arquivo: {ex.Message}");
                }
            }
            Console.WriteLine("Programa encerrado.");
        }
    }
}
