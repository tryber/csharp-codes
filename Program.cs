class PlayingWithArrays
{
    public static void muldiDimArrays()
    {
        // Somente instanciamos o array mais externo neste primeiro passo
        // Repare que apenas o primeiro colchetes contém números
        int[][] jaggedArray = new int[4][];

        // Agora precisamos instanciar um novo array para cada posição do array mais externo
        jaggedArray[0] = new int[4] { 6, 6, 6, 6 };
        jaggedArray[1] = new int[3] { 6, 6, 6 };
        jaggedArray[2] = new int[5] { 6, 6, 6, 6, 6 };
        jaggedArray[3] = new int[2] { 6, 6 };
    }
}