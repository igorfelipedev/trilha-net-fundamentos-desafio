using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafioEstacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string? placa = Console.ReadLine();

            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Você não forneceu uma placa válida.");
                return;
            }

            if (veiculos.Any(v => v.Equals(placa.ToUpper())))
            {
                Console.WriteLine("Já existe um veículo com essa placa.");
            }
            else
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine("Veículo estacionado com sucesso!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string? placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa?.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string? horaDigitada = Console.ReadLine();
                if (!int.TryParse(horaDigitada, out int horas))
                {
                    Console.WriteLine("Você não forneceu um número válido para as horas.");
                    return;
                }
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                if (placa != null)
                {
                    veiculos.Remove(placa.ToUpper());
                }
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos == null || !veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Os veículos estacionados são:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }
    }
}