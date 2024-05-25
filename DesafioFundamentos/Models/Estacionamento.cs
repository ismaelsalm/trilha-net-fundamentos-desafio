namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            if (veiculos.Any(x => x == placa)){
                Console.WriteLine("O veículo já está cadastrado como estacionado.");
                return;
            }

            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = 0;
                bool horaValida = false;
                while (!horaValida)
                {
                    string entrada = Console.ReadLine().ToUpper();
                    if(entrada == "SAIR"){
                        Console.WriteLine("Regressando ao menu.");
                        return;
                    }

                    if(int.TryParse(entrada, out horas)){
                        horaValida = true;
                    }
                    else{
                        Console.WriteLine("Insira um numero de horas válido!, ou digite \"SAIR\" para voltar ao menu.");
                    }
                }
                
                decimal valorTotal = precoInicial + precoPorHora * horas;      
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
