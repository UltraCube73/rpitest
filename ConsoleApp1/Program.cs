int count(int[] a, int[] b, int cut_length, int iter)
{
    int counter = 0;
    for (int i = 0; i < a.Length; i++)
    {
        for (int j = cut_length * iter; j < cut_length * iter + cut_length; j++)
        {
            if (a[i] == b[j]) counter++;
        }
    }
    Console.WriteLine($"Отрезок: {iter + 1}, попаданий: {counter}");
    return counter;
}

Console.Write("Количество чисел в массиве: ");
int n = Convert.ToInt32(Console.ReadLine());
int[] a = new int[n];
for (int i = 0; i < n; i++)
{
    a[i] = Convert.ToInt32(Console.ReadLine());
}
int min = a[0];
int min_index = 0;
int max = a[0];
int max_index = 0;
for (int i = 0; i < n; i++)
{
    if (a[i] > max)
    {
        max = a[i];
        max_index = i;
    }
    if (a[i] < min)
    {
        min = a[i];
        min_index = i;
    }
}
int fi = min_index;
int li = max_index;
if (fi > li) { fi = max_index; li = min_index; }
int[] b = new int[li - fi + 1];
for (int i = fi; i <= li; i++)
{
    b[i - fi] = a[i];
}
for (int i = 0; i < b.Length; i++)
{
    for (int j = 0; j < b.Length - 1; j++)
    {
        if (b[j] > b[j + 1])
        {
            int z = b[j];
            b[j] = b[j + 1];
            b[j + 1] = z;
        }
    }
}
int cut_length = (li - fi) / 5;
Program p = new Program();
Console.WriteLine((li - fi) / 5);
for (int i = 0; i < b.Length; ++i)
{
    Console.Write(b[i]);
    Console.Write(" ");
}
Console.WriteLine();
for (int i = 0; i < 5; ++i)
{
    count(a, b, cut_length, i);
}
Console.ReadLine();
