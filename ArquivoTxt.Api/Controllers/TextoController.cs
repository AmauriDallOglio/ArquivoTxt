using ArquivoTxt.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoTxt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextoController : ControllerBase
    {
        private readonly string caminhoPasta = @"C:\Amauri\GitHub\ArquivoTxt"; // Caminho da pasta
        private readonly string nomeArquivo = "LogApi.txt"; // Nome do arquivo

        public TextoController()
        {
            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }
        }


        [HttpPost]
        public IActionResult SalvarTexto([FromBody] TextoDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Texto))
            {
                return BadRequest("Texto não pode ser vazio.");
            }

            string dataHoraAtual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string linhaParaSalvar = $"{dataHoraAtual} - {request.Texto}{Environment.NewLine}";

            try
            {
                string caminhoArquivo = Path.Combine(caminhoPasta, nomeArquivo);
                System.IO.File.AppendAllText(caminhoArquivo, linhaParaSalvar);
                return Ok($"Texto salvo com sucesso em {caminhoArquivo}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao salvar o arquivo: {ex.Message}");
            }
        }
    }
}
