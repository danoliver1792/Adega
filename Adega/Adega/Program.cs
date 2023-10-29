using System;
using System.Data;
using System.Data.SqlClient;

namespace Adega
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Server=DANRLEI\\MSSQLSERVER01;Database=ADEGA;User Id=DANRLEI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    Console.WriteLine("Escolha a operacao: ");
                    Console.WriteLine("1. Inserir Vinho");
                    Console.WriteLine("2. Atualizar Vinho");
                    Console.WriteLine("3. Recuperar Vinho");
                    Console.WriteLine("4. Listar Vinhos");
                    Console.WriteLine("5. Excluir Vinho");

                    int operacao = int.Parse(Console.ReadLine());

                    switch (operacao)
                    {
                        case 1:
                            InserirVinho(connection);
                            break;
                        case 2:
                            AtualizarVinho(connection);
                            break;
                        case 3:
                            RecuperarVinho(connection);
                            break;
                        case 4:
                            ListarVinhos(connection);
                            break;
                        case 5:
                            ExcluirVinho(connection);
                            break;
                        default:
                            Console.WriteLine("Operacao Invalida. Tente Novamente");
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        static void InserirVinho(SqlConnection connection)
        {
            Console.Write("Nome do Vinho: ");
            string nomeVinho = Console.ReadLine();

            Console.Write("Valor da Garrafa: ");
            decimal valorGarrafa = decimal.Parse(Console.ReadLine());

            Console.Write("Pais de Origem: ");
            string paisOrigem = Console.ReadLine();

            Console.Write("Data de Fabricacao (AAAA-MM-DD): ");
            DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

            Console.Write("Quantidade em Estoque: ");
            int quantidadeEstoque = int.Parse(Console.ReadLine());

            // chamando a procedure para inserir um novo vinho
            InserirNovoVinho(connection, nomeVinho, valorGarrafa, paisOrigem, dataFabricacao, quantidadeEstoque);

            Console.WriteLine("Vinho Inserido com Sucesso");
        }

        static void AtualizarVinho(SqlConnection connection)
        {
            Console.Write("Codigo do Vinho: ");
            int vinhoId = int.Parse(Console.ReadLine());

            Console.Write("Novo Valor da Garrafa: ");
            decimal novoValor = decimal.Parse(Console.ReadLine());

            Console.Write("Nova Quantidade em Estoque: ");
            int novaQuantidade = int.Parse(Console.ReadLine());

            AtualizarVinho(connection, vinhoId, novoValor, novaQuantidade);

            Console.WriteLine("Vinho Atualizado com Sucesso");
        }

        static void RecuperarVinho(SqlConnection connection)
        {
            Console.Write("Codigo do Vinho: ");
            int vinhoId = int.Parse(Console.ReadLine());

            RecuperarVinho(connection, vinhoId);
        }

        static void ListarVinhos(SqlConnection connection)
        {
            ListarVinhos(connection);
        }

        static void ExcluirVinho(SqlConnection connection)
        {
            Console.Write("Codigo do Vinho: ");
            int vinhoId = int.Parse(Console.ReadLine());

            ExcluirVinho(connection, vinhoId);

            Console.WriteLine("Vinho Excluido com Sucesso");
        }

       // funcoes para chamar as procedures
       static void InserirNovoVinho(SqlConnection connection, string nome, decimal valor, string paisOrigem, DateTime Fabricacao, int quantidadeEstoque)
        {
            using (SqlCommand command = new SqlCommand("InserirVinho", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // configurando os parametros da procedure
                command.Parameters.Add(new SqlParameter("@nomeVinho", SqlDbType.NVarChar, 255)).Value = nome;
                command.Parameters.Add(new SqlParameter("@valorGarrafa", SqlDbType.Decimal)).Value = valor;
                command.Parameters.Add(new SqlParameter("paisOrigem", SqlDbType.NVarChar, 255)).Value = paisOrigem;
                command.Parameters.Add(new SqlParameter("dataFabricacao", SqlDbType.DateTime)).Value = dataFabricacao;
                command.Parameters.Add(new SqlParameter("@quantidadeEstoque", SqlDbType.Int)).Value = quantidadeEstoque;

                command.ExecuteNonQuery();
            }
        }
    }
}
