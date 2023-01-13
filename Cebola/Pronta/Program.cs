// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections;

int seed = DateTime.Now.Millisecond;
Random rand = new Random(seed);

MostrarTempo(8000, 10);
// var count = 0;

// for (int i = 0; i < 1000; i++)
// {
//     var m = GerarMatrizCebola(1000);

//     if (solucao2(m, 1000) != solucao1(m, 1000))
//     {
//         Console.WriteLine("\n");
//         Console.WriteLine(solucao1(m, 1000));
//         Console.WriteLine(solucao2(m, 1000));
//         Console.WriteLine("\n");
//         MostrarMatrizCebola(m);
//         break;
//     }
//     count++;
// }



int solucao1(int[,] mat, int N)
{
    int maior = int.MinValue;
    for (int j = 0; j < N; j++)
    {
        for (int i = 0; i < N; i++)
        {
            if (maior < mat[i, j])
            {
                maior = mat[i, j];
            }
        }
    }
    return maior;
}

int solucao2(int[,] mat, int N)
{

    List<int> corners = new List<int> { mat[0, 0], mat[N - 1, 0], mat[0, N - 1], mat[N - 1, N - 1] };
    var selectedCorner = corners.Max();

    // (int, int) cornes = new (int, int)[]
    // {
    //     (0, 0),
    //     (N, 0),
    //     (0, N),
    //     (N, N)
    // }.MaxBy(t => mat[t.Item1, t.Item2]);

    int dx = 1;
    int dy = 1;
    var x = 0;
    var y = 0;

    switch (corners.IndexOf(selectedCorner))
    {
        case 0:
            break;
        case 1:
            x = N - 1;
            dx = -1;
            break;
        case 2:
            y = N - 1;
            dy = -1;
            break;
        case 3:
            x = N - 1;
            y = N - 1;
            dx = -1;
            dy = -1;
            break;
    }

    var actual = mat[x, y];
    var next = mat[x + dx, y + dy];

    while (next > actual)
    {
        x += dx;
        y += dy;
        actual = next;
        next = mat[x + dx, y + dy];
    }

    int s1 = y != 0 ? mat[x, y - 1] : int.MinValue;
    int s2 = x != N - 1 && y != 0 ? mat[x + 1, y - 1] : int.MinValue;
    int s3 = x != N - 1 ? mat[x + 1, y] : int.MinValue;
    int s4 = x != N - 1 && y != N - 1 ? mat[x + 1, y + 1] : int.MinValue;
    int s5 = y != N - 1 ? mat[x, y + 1] : int.MinValue;
    int s6 = x != 0 && y != N - 1 ? mat[x - 1, y + 1] : int.MinValue;
    int s7 = x != 0 ? mat[x - 1, y] : int.MinValue;
    int s8 = x != 0 && y != 0 ? mat[x - 1, y - 1] : int.MinValue;
    int s9 = mat[x, y];

    List<int> square = new List<int>
    {
        s1, s2, s3, s4, s5, s6, s7, s8, s9
    };

    // (int, int) squarel = new (int, int)[]
    // {
    //     (x, y-1),
    //     (x+1, y-1),
    //     (x+1, y),
    //     (x+1, y+1),
    //     (x, y+1),
    //     (x-1, y+1),
    //     (x-1, y),
    //     (x-1,y-1),
    //     (x, y)
    // }.MaxBy(t => mat[t.Item1, t.Item2]);

    // if(squarel.Item1 > x)
    // {
    //     x++;
    // }

    selectedCorner = square.Max();

    var maxIndex = square.IndexOf(selectedCorner);

    switch (maxIndex)
    {
        case 0:
            y--;
            dx *= dy;
            dy = -1;
            break;

        case 2:
            x++;
            dy *= -dx;
            dx = 1;
            break;

        case 4:
            y++;
            dx *= -dy;
            dy = 1;
            break;

        case 6:
            x--;
            dy *= dx;
            dx = -1;
            break;

        case 1:
            x++;
            y--;
            dx = 1;
            dy = -1;
            break;

        case 3:
            x++;
            y++;
            dx = 1;
            dy = 1;
            break;

        case 5:
            x--;
            y++;
            dx = -1;
            dy = 1;
            break;

        case 7:
            x--;
            y--;
            dx = -1;
            dy = -1;
            break;

        case 8:
            return selectedCorner;
    }

    actual = mat[x, y];

    if (!(x + dx >= N || x + dx < 0 || y + dy >= N || y + dy < 0))
    {
        next = mat[x + dx, y + dy];
        
        while (next > actual)
        {
            x += dx;
            y += dy;
            actual = next;
            if (x + dx >= N || x + dx < 0 || y + dy >= N || y + dy < 0)
                break;
            next = mat[x + dx, y + dy];
        }
    }

    s1 = y != 0 ? mat[x, y - 1] : int.MinValue;
    s2 = x != N - 1 && y != 0 ? mat[x + 1, y - 1] : int.MinValue;
    s3 = x != N - 1 ? mat[x + 1, y] : int.MinValue;
    s4 = x != N - 1 && y != N - 1 ? mat[x + 1, y + 1] : int.MinValue;
    s5 = y != N - 1 ? mat[x, y + 1] : int.MinValue;
    s6 = x != 0 && y != N - 1 ? mat[x - 1, y + 1] : int.MinValue;
    s7 = x != 0 ? mat[x - 1, y] : int.MinValue;
    s8 = x != 0 && y != 0 ? mat[x - 1, y - 1] : int.MinValue;
    s9 = mat[x, y];

    List<int> squares = new List<int>
    {
        s1, s2, s3, s4, s5, s6, s7, s8, s9
    };

    var selectedCorners = squares.Max();

    return selectedCorners;
}

int solucao3(int[,] mat, int N)
{
    return -1;
}

int solucao4(int[,] mat, int N)
{
    return -1;
}


int[,] GerarMatrizCebola(int N)
{
    int[,] mat = new int[N, N];
    int x = rand.Next(N),
        y = rand.Next(N),
        value = rand.Next(500, 1000),
        _x = 0,
        _y = 0;
    mat[x, y] = value;

    int delta = 1;
    int lastMinValue = value;
    int newMinValue = value;
    while (delta < N)
    {
        for (int i = -delta; i <= delta; i++)
        {
            var newValue = lastMinValue - rand.Next(1, 6);
            if (newValue < newMinValue)
                newMinValue = newValue;

            _x = x + i;
            _y = y - delta;
            if (_x < 0 || _x >= N || _y < 0 || _y >= N)
                continue;

            mat[_x, _y] = newValue;
        }

        for (int i = -delta; i <= delta; i++)
        {
            var newValue = lastMinValue - rand.Next(1, 6);
            if (newValue < newMinValue)
                newMinValue = newValue;

            _x = x + i;
            _y = y + delta;
            if (_x < 0 || _x >= N || _y < 0 || _y >= N)
                continue;

            mat[_x, _y] = newValue;
        }

        for (int j = -delta + 1; j < delta; j++)
        {
            var newValue = lastMinValue - rand.Next(1, 6);
            if (newValue < newMinValue)
                newMinValue = newValue;

            _x = x - delta;
            _y = y + j;
            if (_x < 0 || _x >= N || _y < 0 || _y >= N)
                continue;

            mat[_x, _y] = newValue;
        }

        for (int j = -delta + 1; j < delta; j++)
        {
            var newValue = lastMinValue - rand.Next(1, 6);
            if (newValue < newMinValue)
                newMinValue = newValue;

            _x = x + delta;
            _y = y + j;
            if (_x < 0 || _x >= N || _y < 0 || _y >= N)
                continue;

            mat[_x, _y] = newValue;
        }
        delta++;
        lastMinValue = newMinValue;
    }

    return mat;
}

void MostrarMatrizCebola(int[,] mat)
{
    int N = (int)Math.Sqrt(mat.LongLength);
    StringBuilder sb = new StringBuilder();
    for (int j = 0; j < N; j++)
    {
        if (j == 0)
        {
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                    sb.Append("┌");
                else sb.Append("┬");
                sb.Append("───────");
            }
            sb.Append("┐\n");
        }
        else
        {
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                    sb.Append("├");
                else sb.Append("┼");
                sb.Append("───────");
            }
            sb.Append("┤\n");
        }

        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < N; i++)
            {
                sb.Append("│");
                sb.Append("       ");
            }
            sb.Append("|\n");
        }


        for (int i = 0; i < N; i++)
        {
            sb.Append("│");
            sb.Append(mat[i, j].ToString("  000  "));
        }
        sb.Append("|\n");

        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < N; i++)
            {
                sb.Append("│");
                sb.Append("       ");
            }
            sb.Append("|\n");
        }
    }

    for (int i = 0; i < N; i++)
    {
        if (i == 0)
            sb.Append("└");
        else sb.Append("┴");
        sb.Append("───────");
    }
    sb.Append("┘\n");
    Console.WriteLine(sb.ToString());
}

void MostrarTempo(int N, int K)
{
    List<int[,]> list = new List<int[,]>();
    Console.Write($"Gerando {K} matrizes para testes: ");
    for (int k = 0; k < K; k++)
    {
        Console.Write($"{k + 1}.. ");
        list.Add(GerarMatrizCebola(N));
    }
    Console.WriteLine("\n");

    Stopwatch sw = new Stopwatch();

    Console.WriteLine("Testando solucao1...");
    sw.Start();
    foreach (var mat in list)
    {
        solucao1(mat, N);
    }
    sw.Stop();
    Console.WriteLine($"Solução 1 para n = {N}: {(double)sw.ElapsedMilliseconds / (double)K} ms / execução\n");
    sw.Reset();

    Console.WriteLine("Testando solucao2...");
    sw.Start();
    foreach (var mat in list)
    {
        solucao2(mat, N);
    }
    sw.Stop();
    Console.WriteLine($"Solução 2 para n = {N}: {(double)sw.ElapsedMilliseconds / (double)K} ms / execução\n");
    sw.Reset();

    Console.WriteLine("Testando solucao3...");
    sw.Start();
    foreach (var mat in list)
    {
        solucao3(mat, N);
    }
    sw.Stop();
    Console.WriteLine($"Solução 3 para n = {N}: {(double)sw.ElapsedMilliseconds / (double)K} ms / execução\n");
    sw.Reset();

    Console.WriteLine("Testando solucao4...");
    sw.Start();
    foreach (var mat in list)
    {
        solucao4(mat, N);
    }
    sw.Stop();
    Console.WriteLine($"Solução 4 para n = {N}: {(double)sw.ElapsedMilliseconds / (double)K} ms / execução\n");
    sw.Reset();
}