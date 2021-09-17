using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Controllers;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno
{
    class Program
    {

        static void Main(string[] args)
        {
            var _repository = new Repository();
            var fareController = new FareController(_repository);


            var op = 1;
            while (op == 1)
            {
                var fare = new Fare();
                fare.Id = Guid.NewGuid();

                Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                var fareValueInput = Console.ReadLine();
                fare.Value = decimal.Parse(fareValueInput);

                Console.WriteLine("Informe o código da operadora para a tarifa:");
                Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                var operatorCodeInput = Console.ReadLine();

                
                fareController.CreateFare(fare, operatorCodeInput);


                Console.WriteLine("Tarifa cadastrada com sucesso! Deseja Incluir novas Tarifas?");
                Console.WriteLine("1 - SIM");
                Console.WriteLine("2 - NÃO");
                op = Convert.ToInt32(Console.ReadLine());
                
            }
        }
    }
}

//Pode cadatrar se nao tiver cadastro
//Pode cadatrar se tiver cadastro e nao estiver ativa
//Pode cadatrar se tiver cadastro e estiver ativa so que > 6 meses

