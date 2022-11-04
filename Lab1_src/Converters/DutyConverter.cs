using Lab1_src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_src.Converters;

internal static class DutyConverter
{
    public static Duty? ToDuty(this string input)
    {
        if (input == null) return null;
        int difficulty;
        string[] strings = input.Split(',');

        if (strings.Length != 2) return null;
        
        foreach(var str in strings) str.Trim();

        if (!int.TryParse(strings[1],out difficulty)) return null;
        if(difficulty < 1 || difficulty > 5) return null;

        return new Duty(strings[0], (DutyDifficulty)difficulty);
    }

    public static int[]? ToIndexArray(this string input)
    {
        if (input == null) return null;

        var strIndexes = input.Split(',');
        int[] indexes = new int[strIndexes.Length];

        for(int i = 0; i < strIndexes.Length; i++)
        {
            if (!int.TryParse(strIndexes[i], out indexes[i])) return null;
        }

        return indexes;
    }
}
