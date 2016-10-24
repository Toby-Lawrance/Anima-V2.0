using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anima
{
    public class ScreenArray
    {
        public Screen[] Arr;


        public ScreenArray()
        {
            Arr = new Screen[Screen.AllScreens.Length];
            Arr = Screen.AllScreens;
            Arr = SortArrayScreens(Arr);
        }

        enum Direction
        {
            X,Y
        }

        private Screen[] SortArrayScreens(Screen[] S)
        {

                for (int j = 0; j < S.Length - 1; j++)
                {
                    if (CompareScreens(S[j], S[j+1],Direction.X) == Options.Greater)
                    {
                        Screen Temp = S[j];
                        S[j] = S[j + 1];
                        S[j + 1] = Temp;
                    }
                }

            //bool ChangesMade;
            //int i = 0;
            //do {
            //    ChangesMade = false;
            //    for (int j = 0; j < S[i].Length - 1; j++)
            //    {
            //        if (CompareScreens(S[i][j], S[i][j + 1], Direction.Y) == Options.Greater)
            //        {
            //            S[i + 1][j] = PopAndShift(ref S[i],j);
            //            ChangesMade = true;
            //        } else if (CompareScreens(S[i][j], S[i][j + 1], Direction.Y) == Options.Less)
            //        {
            //            S[i + 1][j] = PopAndShift(ref S[i], j+1);
            //            ChangesMade = true;
            //        }
            //    }

            //    i++;
            //} while (ChangesMade == true && i < ArrSize - 1);


            return S;
        }

        private Screen PopAndShift(ref Screen[] S, int index)
        {
            Screen Out = S[index];

            for (int i = index; i < S.Length - 1; i++)
            {
                S[index] = S[index + 1];
            }
            return Out;
        }

        enum Options
        {
            Greater,Equal,Less
        }

        private Options CompareScreens(Screen S1, Screen S2, Direction D)
        {
            if (D == Direction.X)
            {
                if(S1.WorkingArea.X == S2.WorkingArea.X) { return Options.Equal; } else if (S1.WorkingArea.X > S2.WorkingArea.X) { return Options.Greater; } else { return Options.Less; }
            } 
            else
            {
                if (S1.WorkingArea.Y == S2.WorkingArea.Y) { return Options.Equal; } else if (S1.WorkingArea.Y > S2.WorkingArea.Y) { return Options.Greater; } else { return Options.Less; }
            }
            
        }
    }
}
