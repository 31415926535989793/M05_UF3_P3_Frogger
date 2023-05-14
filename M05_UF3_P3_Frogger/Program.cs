using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static M05_UF3_P3_Frogger.Utils;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Preparar datos
            List<Lane>  lineas = new List<Lane>();

            lineas.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0, '*', new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Yellow }));
            lineas.Add(new Lane(1, false, ConsoleColor.Blue, true, false, 0.5f, '=', new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lineas.Add(new Lane(2, false, ConsoleColor.Blue, true, false, 0.75f, '=', new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lineas.Add(new Lane(3, false, ConsoleColor.Blue, true, false, 0.75f, '=', new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lineas.Add(new Lane(4, false, ConsoleColor.Blue, true, false, 0.65f, '=', new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lineas.Add(new Lane(5, false, ConsoleColor.Blue, true, false, 0.8f, '=', new List<ConsoleColor> { ConsoleColor.DarkYellow, ConsoleColor.Yellow }));
            lineas.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0, '*', new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Yellow }));
            lineas.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.25f, '╫', new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Red }));
            lineas.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.2f, '╫', new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Red }));
            lineas.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.15f, '╫', new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Red }));
            lineas.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.05f, '╫', new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Red }));
            lineas.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, '╫', new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Red }));
            lineas.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0, '*', new List<ConsoleColor> { ConsoleColor.Cyan, ConsoleColor.Yellow }));

            
            //crear personaje
            Player pj = new Player();
            Vector2Int pos = new Vector2Int(0, 0);
            GAME_STATE state = GAME_STATE.RUNNING;

            while (state == GAME_STATE.RUNNING)
            {

                TimeManager.NextFrame();
                //Inputs
                pos = Utils.Input();


                //Logica
                for (int i = 0; i <= 12; ++i)
                {
                    lineas[i].Update();
                }
                state = pj.Update(pos, lineas);

                //Dibujado
                for (int i = 0; i <= 12; ++i)
                {
                    lineas[i].Draw();
                }
                pj.Draw();
            }
            if (state == GAME_STATE.WIN)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("YOU WON!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU LOST");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
