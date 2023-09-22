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
                        Console.WriteLine("Inserisci il nome del videogioco che vuoi inserire:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Inserisci òla descrizione del videogioco che vuoi inserire:");
                        string overview = Console.ReadLine();

                        Console.WriteLine("Inserisci la data di rilascio del videogioco che vuoi inserire:");
                        DateTime realease_date = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Inserisci la software house del videogioco che vuoi inserire:");
                        long software_house = long.Parse(Console.ReadLine());

                        Videogioco nuovoVideogioco = new Videogioco()
                        {
                            Name = name,
                            Overview = overview,
                            Release_date = realease_date,
                            Software_houseId = software_house
                        };

                        using (VideogameContext db = new VideogameContext())
                        {
                            try
                            {
                                db.Add(nuovoVideogioco);
                                db.SaveChanges();

                                Console.WriteLine("Il videogioco è stato aggiunto");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;
                    case 2:

                        Console.WriteLine("Inserisci l'ID del gioco che vuoi trovare");
                        long gameid = long.Parse(Console.ReadLine());

                        using (VideogameContext db = new VideogameContext())
                        {
                            Videogioco videogioco = db.Videogiochi.FirstOrDefault(videogioco => videogioco.VideogameId == gameid);
                            if (videogioco != null)
                            {
                                Console.WriteLine($"Nome: {videogioco.Name}");
                                Console.WriteLine($"Descrizione: {videogioco.Overview}");
                                Console.WriteLine($"Data di rilascio: {videogioco.Release_date}");
                                Console.WriteLine($"Id della software house: {videogioco.Software_houseId}");
                            }
                            else
                            {
                                Console.WriteLine("Nessun videogioco presente nel database appartente a quel id...Se vuoi puoi contattate la casa produttrice e inserirlo all'interno del database con il tasto 1");
                            }
                        }
                        break;
                    case 3:

                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        return;
                        break;
                }
            }
        }
    }
}