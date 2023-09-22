namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel gestionale gamestop!");

            while (true)
            {
                Console.WriteLine($@"
1: Inserire un nuovo videogioco;
2: Ricercare un videogioco per il suo ID;
3: ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
4: Cancellare un videogioco;
5: Inserisci una nuova Software House
6: Esci dal gestionale;
");
                Console.Write("Inserisci l'opzione desiderata --> ");
                int opzioneSelezionata = int.Parse(Console.ReadLine());
                switch (opzioneSelezionata)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }
            }
        }
    }
}