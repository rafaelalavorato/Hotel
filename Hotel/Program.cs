using System.Text;
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

Console.OutputEncoding = Encoding.UTF8; // caracteres 

List<Suite> suites = new List<Suite>();
List<Reserva> reservas = new List<Reserva>();

bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("*** Menu Principal ***");
    Console.WriteLine("1 - Cadastrar Suíte");
    Console.WriteLine("2 - Fazer Reserva");
    Console.WriteLine("3 - Calcular Valor da Diária");
    Console.WriteLine("4 - Listar Reservas");
    Console.WriteLine("0 - Sair");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Tipo da suíte: ");
            string tipo = Console.ReadLine();

            Console.Write("Capacidade: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Valor diária: ");
            decimal valor = decimal.Parse(Console.ReadLine());

            suites.Add(new Suite(tipo, capacidade, valor));
            Console.WriteLine("Suíte cadastrada!");
            MostrarMensagemContinua();
            break;

        case "2":
            if (suites.Count == 0)
            {
                Console.WriteLine("Nenhuma suíte cadastrada. Cadastre uma primeiro.");
            }
            else
            {
                Console.WriteLine("Escolha a suíte (pelo índice):");
                for (int i = 0; i < suites.Count; i++)
                {
                    Console.WriteLine($"{i} - {suites[i].TipoSuite} (Cap: {suites[i].Capacidade})");
                }

                int indiceSuite = int.Parse(Console.ReadLine());
                Suite suiteEscolhida = suites[indiceSuite];

                Console.Write("Quantos hóspedes vão se hospedar? ");
                int qtdHospedes = int.Parse(Console.ReadLine());

                List<Pessoa> hospedesReserva = new List<Pessoa>();
                for (int i = 0; i < qtdHospedes; i++)
                {
                    Console.Write($"Digite o nome do hóspede {i + 1}: ");
                    string nomeHospede = Console.ReadLine();
                    hospedesReserva.Add(new Pessoa(nomeHospede));
                }

                Console.Write("Quantos dias reservados? ");
                int dias = int.Parse(Console.ReadLine());

                Reserva novaReserva = new Reserva();
                novaReserva.CadastrarSuite(suiteEscolhida);
                novaReserva.DiasReservados = dias;

                try
                {
                    novaReserva.CadastrarHospedes(hospedesReserva);
                    reservas.Add(novaReserva);
                    Console.WriteLine("Reserva feita com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }

            MostrarMensagemContinua();
            break;

        case "3":
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
            }
            else
            {
                Console.WriteLine("Escolha a reserva (pelo índice):");
                for (int i = 0; i < reservas.Count; i++)
                {
                    var suite = reservas[i].Suite;
                    Console.WriteLine($"{i} - Suíte: {suite.TipoSuite}, Dias: {reservas[i].DiasReservados}");
                }

                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < reservas.Count)
                {
                    var valorTotal = reservas[index].CalcularValorDiaria();
                    Console.WriteLine($"Valor total da diária: {valorTotal:C}");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
            }

            MostrarMensagemContinua();
            break;

        case "4":
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva cadastrada.");
            }
            else
            {
                for (int i = 0; i < reservas.Count; i++)
                {
                    var r = reservas[i];
                    string nomes = string.Join(", ", r.Hospedes.Select(h => h.Nome));
                    Console.WriteLine($"\nReserva {i}:");
                    Console.WriteLine($"  Suíte: {r.Suite.TipoSuite} (Cap: {r.Suite.Capacidade})");
                    Console.WriteLine($"  Hóspedes: {nomes}");
                    Console.WriteLine($"  Dias: {r.DiasReservados}");
                    Console.WriteLine($"  Valor total: {r.CalcularValorDiaria()}");
                }
            }

            MostrarMensagemContinua();
            break;

        case "0":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida!");
            MostrarMensagemContinua();
            break;
    }
}

static void MostrarMensagemContinua()
{
    Console.WriteLine("\nPressione enter para continuar...");
    Console.ReadKey();
}


//Jeito mais simples de cadastrar uma lista de hóspedes e exibir
// Cria os modelos de hóspedes e cadastra na lista de hóspedes
//List<Pessoa> hospedes = new List<Pessoa>();
//Pessoa p1 = new Pessoa(nome: "Hóspede 1");
//Pessoa p2 = new Pessoa(nome: "Hóspede 2");
//Pessoa p3 = new Pessoa(nome: "Hóspede 3");

//hospedes.Add(p1);
//hospedes.Add(p2);
//hospedes.Add(p3);

//// Cria a suíte
//Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

//// Cria uma nova reserva, passando a suíte e os hóspedes
//Reserva reserva = new Reserva(diasReservados: 5);
//reserva.CadastrarSuite(suite);
//reserva.CadastrarHospedes(hospedes);

//// Exibe a quantidade de hóspedes e o valor da diária
//Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
//Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");