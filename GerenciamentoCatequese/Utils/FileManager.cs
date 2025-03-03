using ClosedXML.Excel;
using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using System.Data;

namespace GerenciamentoCatequese.Utils
{
    public class FileManager : IFileManager
    {

        //public async Task<DataTable> GerarExecel(IEnumerable<RegistroDocumentosFaltantesTabela> registro)
        //{
        //    DataTable dt = new()
        //    {
        //        TableName = "DocumentosFaltantes"
        //    };

        //    dt.Columns.Add("NomeCatequisando", typeof(string));
        //    dt.Columns.Add("Turma", typeof(string));
        //    dt.Columns.Add("Responsavel", typeof(string));
        //    dt.Columns.Add("Telefone Celular do Responsavel", typeof(string));
        //    dt.Columns.Add("Telefone Fixo do Responsavel", typeof(string));
        //    dt.Columns.Add("Documento faltante", typeof(string));
        //    dt.Columns.Add("Local do Documento", typeof(string));
        //    dt.Columns.Add("Prazo para entrega", typeof(string));

        //    foreach (var faltante in registro)
        //    {
        //        dt.Rows.Add
        //        (
        //            faltante.NomeCatequizando,
        //            faltante.DescricaoTurma,
        //            faltante.NomeResponsavel,
        //            faltante.TelefoneResponsavel,
        //            faltante.TelefoneResponsavelFixo,
        //            faltante.DescricaoDocumentosFaltantes,
        //            faltante.LocalidadeDocumento,
        //            faltante.PrazoEntrega
        //        );

        //    }
        //        return dt;
        //}

        //public async Task<MemoryStream> GerarArquivo(DataTable tabela)
        //{
        //    XLWorkbook workbook = new();
        //    workbook.Worksheets.Add(tabela);
        //    workbook.Worksheet("DocumentosFaltantes").Columns("A:H").AdjustToContents();

        //    var memoryStream = new MemoryStream();

        //    workbook.SaveAs(memoryStream);
        //    memoryStream.Position = 0;

        //    return memoryStream;

        //}

    }
}
