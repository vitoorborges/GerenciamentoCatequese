using ClosedXML.Excel;
using GerenciamentoCatequese.Interfaces;
using GerenciamentoCatequese.Models;
using System.Data;

namespace GerenciamentoCatequese.Utils
{
    public class FileManager : IFileManager
    {

        public async Task<DataTable> GerarExecelCompleto(IEnumerable<CatequisandoRelatorio> relatorioCompleto)
        {
            DataTable dt = new()
            {
                TableName = "RelatorioCatequisandoCompleto"
            };

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nome do Catequisando", typeof(string));
            dt.Columns.Add("Turma", typeof(string));
            dt.Columns.Add("Data de Nascimento", typeof(string));
            dt.Columns.Add("UF de Naturalidade", typeof(string));
            dt.Columns.Add("Município de Naturalidade", typeof(string));
            dt.Columns.Add("Batizado", typeof(string));
            dt.Columns.Add("Data do Batismo", typeof(string));
            dt.Columns.Add("UF do Batismo", typeof(string));
            dt.Columns.Add("Município do Batismo", typeof(string));
            dt.Columns.Add("Paróquia do Batismo", typeof(string));
            dt.Columns.Add("Eucaristia", typeof(string));
            dt.Columns.Add("Data da Eucaristia", typeof(string));
            dt.Columns.Add("UF da Eucaristia", typeof(string));
            dt.Columns.Add("Município da Eucaristia", typeof(string));
            dt.Columns.Add("Paróquia da Eucaristia", typeof(string));
            dt.Columns.Add("Participa de Pastoral", typeof(string));
            dt.Columns.Add("Descrição da Pastoral", typeof(string));
            dt.Columns.Add("CEP", typeof(string));
            dt.Columns.Add("UF do Endereço", typeof(string));
            dt.Columns.Add("Logradouro", typeof(string));
            dt.Columns.Add("Bairro", typeof(string));
            dt.Columns.Add("Cidade", typeof(string));
            dt.Columns.Add("Número", typeof(string));
            dt.Columns.Add("Complemento", typeof(string));
            dt.Columns.Add("E-mail", typeof(string));
            dt.Columns.Add("Telefone Residencial", typeof(string));
            dt.Columns.Add("Telefone Celular", typeof(string));
            dt.Columns.Add("Nome do Responsavel", typeof(string));
            dt.Columns.Add("Telefone Celular do Responsavel", typeof(string));
            dt.Columns.Add("Parentesco do Responsavel", typeof(string));

            foreach (var item in relatorioCompleto)
            {
                dt.Rows.Add
                (
                    item.IdCatequisando,
                    item.NomeCatequisando,
                    item.DescricaoTurma,
                    item.DataNascimento,
                    item.UFNaturalidade,
                    item.MunicipioNaturalidade,
                    item.Batizado,
                    item.DataBatismo,
                    item.UFBatismo,
                    item.MunicipioBatismo,
                    item.ParoquiBatismo,
                    item.Eucaristia,
                    item.DataEucaristia,
                    item.UFEucatistia,
                    item.MunicipioEucaristia,
                    item.ParoquiaEucaristia,
                    item.Pastoral,
                    item.DescricaoPastoral,
                    item.CepEndereco,
                    item.UFEndereco,
                    item.LogradouroEndereco,
                    item.BairroEndereco,
                    item.CidadeEndereco,
                    item.NumeroEndereco,
                    item.ComplementoEndereco,
                    item.Email,
                    item.TelefoneResidencial,
                    item.TelefoneCelular,
                    item.NomeResponsavel,
                    item.CelularResponsavel,
                    item.Parentesco
                );
            }

            return dt;
        }

        public async Task<DataTable> GerarExcelFrequencia(IEnumerable<RelatorioFrequencia> relatorioFrequencia)
        {
            DataTable dt = new()
            {
                TableName = "RelatorioFrequencia"
            };

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nome do Catequisando", typeof(string));
            dt.Columns.Add("Data de Nascimento", typeof(string));
            dt.Columns.Add("Nome do Responsável", typeof(string));
            dt.Columns.Add("Telefone Celular do Responsável", typeof(string));
            dt.Columns.Add("Idade", typeof(string));
            dt.Columns.Add("Turma", typeof(string));
            dt.Columns.Add("Data da frequência", typeof(string));

            foreach (var item in relatorioFrequencia)
            {
                dt.Rows.Add
                (
                    item.IdCatequisando,
                    item.NomeCatequisando,
                    item.DataNascimento,
                    item.NomeResponsavel,
                    item.TelefoneCelular,
                    item.Idade,
                    item.DescricaoTurma
                );
            }

            return dt;
        }


        public async Task<DataTable> GerarExcelFrequenciaCrismaAdulto(IEnumerable<RelatorioFrequencia> relatorioFrequencia)
        {
            DataTable dt = new()
            {
                TableName = "RelatorioFrequencia"
            };

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nome do Catequisando", typeof(string));
            dt.Columns.Add("Telefone Celular", typeof(string));
            dt.Columns.Add("Idade", typeof(string));
            dt.Columns.Add("Data da frequência", typeof(string));

            foreach (var item in relatorioFrequencia)
            {
                dt.Rows.Add
                (
                    item.IdCatequisando,
                    item.NomeCatequisando,
                    item.TelefoneCelular,
                    item.Idade
                );
            }

            return dt;
        }

        public async Task<DataTable> GerarExcelResponsaveis(IEnumerable<RelatorioResponsaveis> relatorioFrequencia)
        {
            DataTable dt = new()
            {
                TableName = "RelatorioResponsaveis"
            };

            dt.Columns.Add("Nome do Catequisando", typeof(string));
            dt.Columns.Add("Turma", typeof(string));
            dt.Columns.Add("Parentesco do primeiro Responsavel", typeof(string));
            dt.Columns.Add("Nome do primeiro Responsavel", typeof(string));
            dt.Columns.Add("Telefone do primeiro Responsavel", typeof(string));
            dt.Columns.Add("Parentesco do segundo Responsavel", typeof(string));
            dt.Columns.Add("Nome do segundo Responsavel", typeof(string));
            dt.Columns.Add("Telefone do segundo Responsavel", typeof(string));

            foreach (var item in relatorioFrequencia)
            {
                dt.Rows.Add
                (
                    item.NomeCatequisando,
                    item.DescricaoTurma,
                    item.ParentescoResponsavel1,
                    item.Responsavel1,
                    item.TelefoneResponsavel1,
                    item.ParentescoResponsavel2,
                    item.Responsavel2,
                    item.TelefoneResponsavel2
                );
            }

            return dt;
        }

        public async Task<DataTable> GerarExcelPagamentoTaxa(IEnumerable<RelatorioPagamentoTaxa> relatorioPagamento)
        {
            DataTable dt = new()
            {
                TableName = "RelatorioResponsaveis"
            };

            dt.Columns.Add("Nome do Catequisando", typeof(string));
            dt.Columns.Add("Turma", typeof(string));
            dt.Columns.Add("Parcela", typeof(string));
            dt.Columns.Add("Data do pagamento", typeof(string));
            dt.Columns.Add("Valor do pagamento", typeof(string));
            dt.Columns.Add("Nome do responsável", typeof(string));

            foreach (var item in relatorioPagamento)
            {
                dt.Rows.Add
                (
                    item.NomeCatequisando,
                    item.DescricaoTurma,
                    item.Parcela,
                    item.DataPagamento,
                    item.ValorPagamento,
                    item.NomeResponsavel
                );
            }

            return dt;
        }

        public async Task<MemoryStream> GerarArquivo(DataTable tabela)
        {
            XLWorkbook workbook = new();
            var ws = workbook.Worksheets.Add(tabela);
            ws.Columns().AdjustToContents();

            var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            memoryStream.Position = 0;

            return memoryStream;
        }


    }
}
