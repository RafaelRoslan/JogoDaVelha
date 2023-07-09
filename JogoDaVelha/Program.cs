using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class JogoDaVelha
    {
        public enum Jogador {X, O};
        public enum EstadoJogo {Xganhou, Oganhou, Velha, EmJogo};
        
        public char[] tabuleiro = new char[8];
        EstadoJogo estadoDoJogo;


        int turno   = 0;
        int op      = 0;
        int x       = 0;
        int o       = 0;
        int v       = 0;

        char peca   = ' ';

        static void Main(string[] args)
        {
            JogoDaVelha jogo = new JogoDaVelha();
            jogo.Jogar();
        }

        public void Jogar()
        {
            int op = 0;
            do
            {
                
                Titulo();
                Console.WriteLine("     MENU:\n\n");
                Console.WriteLine("     1 - Jogar\n" +
                                  "     2 - Estatistica\n" +
                                  "     3 - Sair\n\n");

                Console.Write("     Digite sua opcao: ");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    case 1:
                        ResetarJogo();
                        estadoDoJogo = EstadoJogo.EmJogo;
                        Partida();
                        break;
                    case 2:
                        Estatistica();
                        break;
                    default:
                        Console.WriteLine("     Opcao invalida");
                        break;
                }

            } while (op != 3);

        }

        public void Partida()
        {
            do
            {
                Console.Clear();
                Titulo();

                turno++;

                peca = (turno % 2 == 0) ? char.Parse(Jogador.X.ToString()) : char.Parse(Jogador.O.ToString());
                Console.WriteLine("     Turno {0}: \n" +
                                  "     Jogador:{1}\n\n", turno, peca);
                op = DesenharOpcao();
                ExecutarAcao(op, peca);

                estadoDoJogo = Verificar(tabuleiro,peca);

                if (turno == 9 && estadoDoJogo == EstadoJogo.EmJogo) { estadoDoJogo = EstadoJogo.Velha; }

            } while (estadoDoJogo == EstadoJogo.EmJogo);

            switch (estadoDoJogo)
            {
                case EstadoJogo.Xganhou:
                    Console.WriteLine("\n\n" +
                                      "---------------------" +
                                      "|    X GANHOU !!    |" +
                                      "---------------------");
                    x++;
                    break;

                case EstadoJogo.Oganhou:
                    Console.WriteLine("\n\n" +
                                      "---------------------" +
                                      "|    O GANHOU !!    |" +
                                      "---------------------");
                    o++;
                    break;

                default:
                    Console.WriteLine("\n\n" +
                                      "---------------------" +
                                      "|    DEU VELHA #!   |" +
                                      "---------------------");
                    v++;
                    break;
            }

            Console.Write("\n\nAperte qualquer tecla para continuar...");
            Console.ReadLine();
        }

        public void Estatistica()
        {
            Titulo();
            Console.WriteLine("     VITORIAS :");
            Console.WriteLine("      > X : {0}",x);
            Console.WriteLine("      > O : {0}\n",o);
            Console.WriteLine("     VELHAS : {0}\n\n",v);

            Console.Write("     Aperte qualquer tecla para retornar...");
            Console.ReadLine();

        }

        public int DesenharOpcao()
        {
            char op;
            do
            {
               
                Console.Write("     {0}|{1}|{2}   Digite uma\n" +
                              "     {3}|{4}|{5}   das opcoes ao lado.\n" +
                              "     {6}|{7}|{8}   \n\n", tabuleiro[0], tabuleiro[1], tabuleiro[2],
                                                         tabuleiro[3], tabuleiro[4], tabuleiro[5],
                                                         tabuleiro[6], tabuleiro[7], tabuleiro[8]);

                Console.Write("     Digite uma opcao: ");
                op = char.Parse(Console.ReadLine());
            } while(op < '1' || op > '9');
            return op;


        }

        public EstadoJogo Verificar(char[] tabuleiro, char peca)
        {
            
                        

            return EstadoJogo.EmJogo;
        }

        public void Titulo()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|       X - Jogo da Velha - O         |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\n\n");
        }

        public void ExecutarAcao(int acao, char peca)
        {
            int x = 0;
            int y = 0;

            switch (acao)
            {
                case 2:
                    y = 1;
                    break;
                case 3:
                    y = 2;
                    break;
                case 4:
                    x = 1;
                    break;
                case 5:
                    x = 1;
                    y = 1;
                    break;
                case 6:
                    x = 1;
                    y = 2;
                    break;
                case 7:
                    x = 2;
                    break;
                case 8:
                    x = 2;
                    y = 1;
                    break;
                case 9:
                    x = 2;
                    y = 2;
                    break;
            }

            
            tabuleiro[x, y] = peca;
        }

        public void ResetarJogo()
        {
            int cont = 0;

            turno = 0;
            for(int i=0; i<9; i++)
            {
                cont++;
                tabuleiro[i] = char.Parse(cont.ToString());
            }
        }

    }
}
