using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandO
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                   map[i, j] = '#';
                }
            }

            bool game = true,
                 flag = true;

            while (game)
            {
                if (flag)
                    Console.WriteLine("Ход первого игрока\n");
                else
                    Console.WriteLine("Ход второго игрока\n");

                PaintMap(map);
                Input(flag, map);
                if ((map[1, 1] != '#' && (map[1, 1] == map[1, 2] && map[1, 2] == map[1, 0])) ||
                    (map[2, 1] != '#' && (map[2, 1] == map[2, 2] && map[2, 2] == map[0, 0])) ||
                    (map[0, 1] != '#' && (map[0, 1] == map[0, 2] && map[0, 2] == map[0, 0])) ||
                    (map[1, 1] != '#' && (map[1, 1] == map[2, 1] && map[2, 1] == map[0, 1])) ||
                    (map[1, 2] != '#' && (map[1, 2] == map[2, 2] && map[2, 2] == map[0, 2])) ||
                    (map[1, 0] != '#' && (map[1, 0] == map[2, 0] && map[2, 0] == map[0, 0])) ||
                    (map[1, 1] != '#' && (map[1, 1] == map[2, 2] && map[2, 2] == map[0, 0])) ||
                    (map[0, 1] != '#' && (map[0, 1] == map[2, 2] && map[2, 2] == map[1, 0])) ||
                    (map[0, 0] == '#' && map[0, 1] == '#' && map[0, 2] == '#' && 
                     map[1, 0] == '#' && map[1, 1] == '#' && map[1, 2] == '#' && 
                     map[2, 0] == '#' && map[2, 1] == '#' && map[2, 2] == '#'))
                {
                    game = false;
                    Console.WriteLine("Game over!");
                    if(map[0, 0] == '#' && map[0, 1] == '#' && map[0, 2] == '#' &&
                     map[1, 0] == '#' && map[1, 1] == '#' && map[1, 2] == '#' &&
                     map[2, 0] == '#' && map[2, 1] == '#' && map[2, 2] == '#')
                        Console.WriteLine("WIN дружба!\n");
                    else if (flag)
                        Console.WriteLine("WIN первый игрок!\n");
                    else
                        Console.WriteLine("WIN второй игрок!\n");
                    Console.Read(); 
                }
                    flag = !flag;
                Console.Clear();
            }
            
            
        }

        static void PaintMap(char[,] map)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"\t{map[i,j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Input(bool flag, char[,] map)
        {
            Console.WriteLine("Введите координаты места, куда хотите сходить:   ");
            int i, j; 

            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            bool check1 = int.TryParse(str1, out i);
            bool check2 = int.TryParse(str2, out j);
            //Console.WriteLine($"{i},{j}");

            while(!check1 || !check2 || map[i - 1,j - 1] != '#')
            {
                Console.WriteLine("Ход неверен. Попробуйте снова!");
                str1 = Console.ReadLine();
                str2 = Console.ReadLine();
                check1 = int.TryParse(str1, out i);
                check2 = int.TryParse(str2, out j);
            }

            if (flag == true)
                map[i - 1, j - 1] = 'X';
            else
                map[i - 1, j - 1] = 'O';

            //Console.Read();
            //flag = !flag;
        }
    }
}
