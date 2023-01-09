// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections;

int seed = DateTime.Now.Millisecond;
Random rand = new Random(seed);

// MostrarTempo(6, 100);

// var m = GerarMatrizCebola(8);
// MostrarMatrizCebola(m);
// Console.WriteLine(solucao1(m, 8));
// Console.WriteLine(solucao2(m, 8));

var count=0;

for (int i = 0; i < 1000; i++)
{
    var m = GerarMatrizCebola(8);

    if(solucao2(m, 8) != solucao1(m, 8))
    {
        Console.WriteLine(solucao2(m, 8));
        MostrarMatrizCebola(m);
        break;
    }
    count++;
}
Console.WriteLine(count);


// for (int i = 0; i < 1000; i++)
// {
//     var m = GerarMatrizCebola(i);

//     if(solucao2(m, i) != solucao1(m, i))
//     {
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
            if (maior < mat[i,j])
            {
                maior = mat[i,j];
            }
        }
    }
    return maior;
}

int solucao2(int[,] mat, int N)
{
    // MostrarMatrizCebola(mat);

    N -= 1;
    List<int> corners = new List<int> { mat[0, 0], mat[N, 0], mat[0, N], mat[N, N] };
    var selectedCorner = corners.Max();


    int x = 1;
    int y = 1;
    var pos_x = 0;
    var pos_y = 0;

    switch (corners.IndexOf(selectedCorner))
    {
        case 0:
            break;
        case 1:
            pos_x = N;
            x = -1;
            break;
        case 2:
            pos_y = N;
            y = -1;
            break;
        case 3:
            pos_x = N;
            pos_y = N;
            x = -1;
            y = -1;
            break;
    }

    var next = mat[pos_x + x, pos_y + y];
    var actual = mat[pos_x, pos_y];
    var pos_x_s = 0;
    var pos_y_s = 0;
    var whi = false;

    var i = 0;
    while(next > actual)
    {
        whi = true;
        pos_x_s = pos_x + (x * i);
        pos_y_s = pos_y + (y * i);

        actual = mat[pos_x_s, pos_y_s];
        next = mat[pos_x_s + x, pos_y_s + y];
        
        // Console.WriteLine(next + " " + actual);
        // Console.WriteLine("Rodou");
        i++;
    }

    if(whi)
    {
        // Console.WriteLine("Quebrou");
    }
    else
    {
        // Console.WriteLine(selectedCorner);
        pos_x_s = pos_x;
        pos_y_s = pos_y;
    }

    List<int> square = new List<int> { pos_y_s!=0 ? mat[pos_x_s, pos_y_s-1] : int.MinValue,
    pos_x_s!=N && pos_y_s!=0 ? mat[pos_x_s+1, pos_y_s-1] : int.MinValue,
    pos_x_s!=N ? mat[pos_x_s+1, pos_y_s] : int.MinValue,
    pos_x_s!=N && pos_y_s!=N ? mat[pos_x_s+1, pos_y_s+1] : int.MinValue,
    pos_y_s!=N ? mat[pos_x_s, pos_y_s+1] : int.MinValue,
    pos_x_s!=0 && pos_y_s!=N ? mat[pos_x_s-1, pos_y_s+1] : int.MinValue,
    pos_x_s!=0 ? mat[pos_x_s-1, pos_y_s] : int.MinValue,
    pos_x_s!=0 && pos_y_s!=0 ? mat[pos_x_s-1, pos_y_s-1] : int.MinValue,
    mat[pos_x_s, pos_y_s]
    };

    var selectedCorner_s = square.Max();
    Console.WriteLine(selectedCorner_s);
    var x_s = 1;
    var y_s = -1;
    Console.WriteLine(square.IndexOf(selectedCorner_s));

    switch (square.IndexOf(selectedCorner_s))
    {
        case 0:
            pos_y_s--;
            break;

        case 1:
            break;

        case 2:
            pos_x_s++;
            break;

            //3

        case 4:
            pos_y_s++;
            x_s = -1;
            y_s = 1;
            break;

        case 5:
            x_s = -1;
            y_s = 1;
            break;

        case 6:
            pos_x_s--;
            x_s = -1;
            y_s = 1;
            break;
        
        //7

        case 8:
            // Console.WriteLine(selectedCorner_s);
            return selectedCorner_s;
    }    

    var actual_s = mat[pos_x_s, pos_y_s];
    
    if (pos_x_s + x_s < 0 || pos_y_s + y_s < 0 || pos_x_s + x_s < N || pos_y_s + y_s < N)
    {
        return actual_s;
    }
    var next_s = mat[pos_x_s + x_s, pos_y_s + y_s];

    i = 1;
    Console.WriteLine(next_s);
    while(next_s > actual_s) //do while
    {
        if (pos_x_s + (x_s * i) + x_s < 0 || pos_y_s + (y_s * i) + y_s < 0 || pos_x_s + (x_s * i) + x_s < N || pos_y_s + (y_s * i) + y_s < N)
        {
            return actual_s;
        }

        actual_s = mat[pos_x_s + (x_s * i), pos_y_s + (y_s * i)];
        Console.WriteLine(actual_s);
        next_s = mat[pos_x_s + (x_s * i) + x_s, pos_y_s + (y_s * i) + y_s];
        Console.WriteLine(next_s);
        i++;
    }
    return actual_s;
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