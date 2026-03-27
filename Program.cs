using System;
using System.Collections.Generic;
/*
Neste sistema foram aplicadas três heurísticas de Nielsen:

- Visibilidade do status do sistema (1):
  Linhas aproximadas: 17–22 (exibição do cardápio),
  linha 46 ("Item adicionado ao pedido"),
  e linhas 68–72 (resumo do pedido).

- Controle e liberdade do usuário (3):
  Linhas aproximadas: 49–52 (menu de opções),
  linhas 54–58 (remoção do último item),
  e linhas 59–64 (cancelamento do pedido).

- Prevenção de erros (5):
  Linhas aproximadas: 24–28 (validação do código com TryParse),
  linhas 34–38 (validação da quantidade),
  e linhas 30–33 (verificação se o produto existe).
*/
class Program
{
    static Dictionary<int, string> produtos = new Dictionary<int, string>()
    {
        {1, "Coxinha"},
        {2, "Pastel"},
        {3, "Suco"}
    };

    static void Main()
    {
        List<(int codigo, int quantidade)> pedido = new List<(int, int)>();
        bool rodando = true;

        Console.WriteLine("=== Cantina ===");

        while (rodando)
        {
            
            Console.WriteLine("\nCardápio:");
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.Key} - {p.Value}");
            }

            Console.WriteLine("\nDigite o código do produto (0 para finalizar):");

            
            if (!int.TryParse(Console.ReadLine(), out int codigo))
            {
                Console.WriteLine("Entrada inválida! Digite apenas números.");
                continue;
            }

            if (codigo == 0)
            {
                break;
            }

            if (!produtos.ContainsKey(codigo))
            {
                Console.WriteLine("Produto não existe.");
                continue;
            }

            Console.WriteLine("Digite a quantidade:");

            
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                continue;
            }

            pedido.Add((codigo, quantidade));

        
            Console.WriteLine("Item adicionado ao pedido!");

        
            Console.WriteLine("\nDeseja:");
            Console.WriteLine("1 - Continuar");
            Console.WriteLine("2 - Remover último item");
            Console.WriteLine("3 - Cancelar pedido");

            string opcao = Console.ReadLine();

            if (opcao == "2" && pedido.Count > 0)
            {
                pedido.RemoveAt(pedido.Count - 1);
                Console.WriteLine("Último item removido.");
            }
            else if (opcao == "3")
            {
                pedido.Clear();
                Console.WriteLine("Pedido cancelado.");
                rodando = false;
            }
        }

        
        Console.WriteLine("\nResumo do pedido:");
        foreach (var item in pedido)
        {
            Console.WriteLine($"{produtos[item.codigo]} x {item.quantidade}");
        }

        Console.WriteLine("Pedido finalizado.");
    }
}