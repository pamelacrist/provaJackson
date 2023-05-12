using System;
using System.IO;

namespace App
{
    class Program
    {
      
        public static void Main(string[] args)
        {
            // declarando as variaveis
            int linhas = 0;  
            String nomeArquivo = "valores.txt"; // arquivo de onde vem os valores
            String nomeArquivoOrdenado = "ordenados.txt"; // arquivo de onde vem os valores
            int[] numeros; 
            // pega a quantidade de linhas, lendo o arquivo linha por linha.  
            foreach (string line in System.IO.File.ReadLines(@nomeArquivo))
            {  
                linhas++;  
            }  
            // inicia o vetor de inteiro
            numeros = new int[linhas];  
            int counter = 0; 
            // le linha por linha do arquivo e pega o valor 
            foreach (string line in System.IO.File.ReadLines(@nomeArquivo))
            {  
                //transforma de string para int
                numeros[counter] = int.Parse(line); 
                counter++;
            } 

            // loop para adicionar os numeros do array na Collection lista de numeros
            List<int> listaDeNumeros = numeros.ToList();

            //ordenação de array
            for (int indice = 1; indice < linhas; indice++) {
                // valor da linha
                int valorLinha = numeros[indice];

                // posição no array -1 para começar com a posicão anterior
                int posicao = indice - 1; 

                // entra no loop do while ate que a posicao seje maior ou igual a 0
                // e o valor da linha seja menor que o valor da posicao anterior
                while (posicao >= 0 && valorLinha < numeros[posicao]) {
                    numeros[posicao + 1] = numeros[posicao];// adiciona o numero maior na posicao acima do numero atual
                    posicao--; // decrementar a posição até chegar no 0
                }

                numeros[posicao + 1] = valorLinha;// adiciona o valor da linha atual na nova posição com base no valor
                                                // da variavel posicao + 1 para definir a posição atual
            }
            
            Console.WriteLine("Ordenando com Array"); 
            // exibe o array de linhas ordenado teste
            for (int numAtual = 0; numAtual < linhas; numAtual++) {
                Console.WriteLine(numeros[numAtual]);
            }
            
            Console.WriteLine("Ordenando com Collection List");
            listaDeNumeros.Sort(); // funcao de ordenacao de Collections
            foreach (int num in listaDeNumeros) {
                Console.WriteLine(num);
            }
            // funçao para escrever dados em arquivo
            File.WriteAllLines(nomeArquivoOrdenado,listaDeNumeros.Select(x=>x.ToString()));
            // Suspend the screen.  
            Console.ReadLine();  
        
        }
    }
}